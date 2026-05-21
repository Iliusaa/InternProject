"""Reusable bridge from external agents to MCP for Unity.

The bridge intentionally lives outside the Unity project. It uses the local
MCP for Unity HTTP server debug/CLI surface:

- GET  /health
- GET  /api/instances
- POST /api/command

The Unity package owns the editor-side WebSocket connection. This module owns
agent-side command routing, retries, logging, and convenient wrappers.
"""

from __future__ import annotations

import argparse
import json
import logging
import os
import socket
import sys
import time
import urllib.error
import urllib.request
from dataclasses import dataclass
from typing import Any


LOG = logging.getLogger("unity_mcp_bridge")


class UnityMcpBridgeError(RuntimeError):
    """Base bridge error."""


class UnityMcpConnectionError(UnityMcpBridgeError):
    """Raised when the MCP for Unity server cannot be reached."""


class UnityMcpCommandError(UnityMcpBridgeError):
    """Raised when Unity or the MCP server rejects a command."""


@dataclass(frozen=True)
class UnityMcpBridgeConfig:
    """Runtime configuration for the Unity MCP bridge."""

    host: str = "127.0.0.1"
    port: int = 8080
    timeout_seconds: float = 30.0
    retry_count: int = 3
    retry_delay_seconds: float = 0.5
    unity_instance: str | None = None

    @property
    def base_url(self) -> str:
        return f"http://{self.host}:{self.port}"

    @classmethod
    def from_env(cls) -> "UnityMcpBridgeConfig":
        return cls(
            host=os.environ.get("UNITY_MCP_HOST", "127.0.0.1"),
            port=int(os.environ.get("UNITY_MCP_HTTP_PORT", "8080")),
            timeout_seconds=float(os.environ.get("UNITY_MCP_TIMEOUT", "30")),
            retry_count=int(os.environ.get("UNITY_MCP_RETRIES", "3")),
            retry_delay_seconds=float(os.environ.get("UNITY_MCP_RETRY_DELAY", "0.5")),
            unity_instance=os.environ.get("UNITY_MCP_INSTANCE") or None,
        )


class UnityMcpBridge:
    """HTTP bridge for controlling and inspecting Unity through MCP for Unity."""

    def __init__(self, config: UnityMcpBridgeConfig | None = None) -> None:
        self.config = config or UnityMcpBridgeConfig.from_env()

    def health(self) -> dict[str, Any]:
        """Return MCP server health."""
        return self._request("GET", "/health")

    def list_instances(self) -> dict[str, Any]:
        """Return active Unity editor plugin sessions."""
        return self._request("GET", "/api/instances")

    def ping(self) -> dict[str, Any]:
        """Verify command path from agent to MCP server to Unity and back."""
        return self.command("ping", {})

    def editor_state(self) -> dict[str, Any]:
        """Read editor readiness, play mode, compile, and reload state."""
        return self.command("get_editor_state", {})

    def read_console(self, count: int = 20, log_type: str | None = None) -> dict[str, Any]:
        """Read recent Unity console entries."""
        params: dict[str, Any] = {"action": "get", "count": count}
        if log_type:
            params["logType"] = log_type
        return self.command("read_console", params)

    def inspect_scene(
        self,
        *,
        include_transform: bool = True,
        page_size: int = 100,
        cursor: int = 0,
        max_nodes: int = 200,
    ) -> dict[str, Any]:
        """Read active scene and top-level hierarchy information."""
        active = self.command("manage_scene", {"action": "get_active"})
        hierarchy = self.command(
            "manage_scene",
            {
                "action": "get_hierarchy",
                "includeTransform": include_transform,
                "pageSize": page_size,
                "cursor": cursor,
                "maxNodes": max_nodes,
            },
        )
        return {"active_scene": active, "hierarchy": hierarchy}

    def create_gameobject(
        self,
        name: str,
        *,
        primitive_type: str | None = None,
        position: list[float] | None = None,
        components: list[str] | None = None,
    ) -> dict[str, Any]:
        """Create a Unity GameObject."""
        params: dict[str, Any] = {"action": "create", "name": name}
        if primitive_type:
            params["primitiveType"] = primitive_type
        if position is not None:
            params["position"] = position
        if components:
            params["componentsToAdd"] = components
        return self.command("manage_gameobject", params)

    def modify_gameobject(self, target: str | int, **updates: Any) -> dict[str, Any]:
        """Modify a Unity GameObject by name, path, or instance ID."""
        params = {"action": "modify", "target": target}
        params.update({key: value for key, value in updates.items() if value is not None})
        return self.command("manage_gameobject", params)

    def delete_gameobject(self, target: str | int, search_method: str | None = None) -> dict[str, Any]:
        """Delete a Unity GameObject by name, path, or instance ID."""
        params: dict[str, Any] = {"action": "delete", "target": target}
        if search_method:
            params["searchMethod"] = search_method
        return self.command("manage_gameobject", params)

    def find_gameobjects(
        self,
        search_term: str,
        *,
        search_method: str = "by_name",
        include_inactive: bool = False,
        page_size: int = 50,
        cursor: int = 0,
    ) -> dict[str, Any]:
        """Search scene GameObjects."""
        return self.command(
            "find_gameobjects",
            {
                "searchMethod": search_method,
                "searchTerm": search_term,
                "includeInactive": include_inactive,
                "pageSize": page_size,
                "cursor": cursor,
            },
        )

    def manage_component(
        self,
        action: str,
        target: str | int,
        component_type: str,
        **params: Any,
    ) -> dict[str, Any]:
        """Add, remove, or set component properties."""
        payload: dict[str, Any] = {
            "action": action,
            "target": target,
            "componentType": component_type,
        }
        payload.update({key: value for key, value in params.items() if value is not None})
        return self.command("manage_components", payload)

    def set_play_mode(self, enabled: bool) -> dict[str, Any]:
        """Enter or exit Unity play mode."""
        return self.command("manage_editor", {"action": "play" if enabled else "stop"})

    def search_assets(
        self,
        *,
        path: str = "Assets",
        search_pattern: str | None = None,
        filter_type: str | None = None,
        page_size: int = 25,
        page_number: int = 1,
    ) -> dict[str, Any]:
        """Query Unity AssetDatabase through the MCP asset tool."""
        return self.command(
            "manage_asset",
            {
                "action": "search",
                "path": path,
                "searchPattern": search_pattern,
                "filterType": filter_type,
                "pageSize": page_size,
                "pageNumber": page_number,
                "generatePreview": False,
            },
        )

    def command(self, tool_name: str, params: dict[str, Any] | None = None) -> dict[str, Any]:
        """Send a raw Unity MCP command."""
        payload: dict[str, Any] = {"type": tool_name, "params": params or {}}
        if self.config.unity_instance:
            payload["unity_instance"] = self.config.unity_instance

        response = self._request("POST", "/api/command", payload)
        hint = _find_hint(response)
        if hint == "retry":
            raise UnityMcpConnectionError(f"Unity requested retry for {tool_name}: {response}")
        if _is_error_response(response):
            raise UnityMcpCommandError(f"Unity command failed for {tool_name}: {response}")
        return response

    def wait_until_ready(self, timeout_seconds: float = 20.0) -> dict[str, Any]:
        """Poll until health, instance list, ping, and editor state are available."""
        deadline = time.monotonic() + timeout_seconds
        last_error: Exception | None = None
        while time.monotonic() < deadline:
            try:
                health = self.health()
                instances = self.list_instances()
                ping = self.ping()
                editor = self.editor_state()
                return {
                    "health": health,
                    "instances": instances,
                    "ping": ping,
                    "editor_state": editor,
                }
            except UnityMcpBridgeError as exc:
                last_error = exc
                time.sleep(self.config.retry_delay_seconds)
        raise UnityMcpConnectionError(f"Unity MCP did not become ready: {last_error}")

    def _request(
        self,
        method: str,
        path: str,
        payload: dict[str, Any] | None = None,
    ) -> dict[str, Any]:
        url = f"{self.config.base_url}{path}"
        body = None
        headers = {"Accept": "application/json"}
        if payload is not None:
            body = json.dumps(payload).encode("utf-8")
            headers["Content-Type"] = "application/json"

        request = urllib.request.Request(url, data=body, headers=headers, method=method)
        last_error: Exception | None = None

        for attempt in range(1, self.config.retry_count + 1):
            try:
                LOG.debug("%s %s payload=%s", method, url, payload)
                with urllib.request.urlopen(request, timeout=self.config.timeout_seconds) as response:
                    data = response.read().decode("utf-8")
                parsed = json.loads(data) if data else {}
                LOG.debug("%s %s response=%s", method, url, parsed)
                return parsed
            except (urllib.error.URLError, TimeoutError, socket.timeout) as exc:
                last_error = exc
                LOG.warning(
                    "Unity MCP request failed on attempt %s/%s: %s",
                    attempt,
                    self.config.retry_count,
                    exc,
                )
                if attempt < self.config.retry_count:
                    time.sleep(self.config.retry_delay_seconds * attempt)
            except urllib.error.HTTPError as exc:
                detail = exc.read().decode("utf-8", errors="replace")
                raise UnityMcpConnectionError(f"HTTP {exc.code} from {url}: {detail}") from exc

        raise UnityMcpConnectionError(f"Cannot reach Unity MCP at {url}: {last_error}")


def _find_hint(value: Any) -> str | None:
    if isinstance(value, dict):
        if isinstance(value.get("hint"), str):
            return value["hint"]
        for child in value.values():
            hint = _find_hint(child)
            if hint:
                return hint
    return None


def _is_error_response(value: dict[str, Any]) -> bool:
    if value.get("status") == "error":
        return True
    result = value.get("result")
    if isinstance(result, dict):
        return result.get("success") is False or result.get("status") == "error"
    return False


def _load_json(value: str | None) -> dict[str, Any]:
    if not value:
        return {}
    parsed = json.loads(value)
    if not isinstance(parsed, dict):
        raise argparse.ArgumentTypeError("--params must be a JSON object")
    return parsed


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description="Agent bridge for MCP for Unity")
    parser.add_argument("--host", default=os.environ.get("UNITY_MCP_HOST", "127.0.0.1"))
    parser.add_argument("--port", type=int, default=int(os.environ.get("UNITY_MCP_HTTP_PORT", "8080")))
    parser.add_argument("--instance", default=os.environ.get("UNITY_MCP_INSTANCE"))
    parser.add_argument("--timeout", type=float, default=float(os.environ.get("UNITY_MCP_TIMEOUT", "30")))
    parser.add_argument("--verbose", action="store_true")

    sub = parser.add_subparsers(dest="command_name", required=True)
    sub.add_parser("status")
    sub.add_parser("instances")
    sub.add_parser("scene")

    call = sub.add_parser("call")
    call.add_argument("tool")
    call.add_argument("--params", default="{}")

    create = sub.add_parser("create-gameobject")
    create.add_argument("name")
    create.add_argument("--primitive")

    play = sub.add_parser("play-mode")
    play.add_argument("state", choices=["on", "off"])

    return parser


def main(argv: list[str] | None = None) -> int:
    parser = build_parser()
    args = parser.parse_args(argv)
    logging.basicConfig(
        level=logging.DEBUG if args.verbose else logging.INFO,
        format="%(asctime)s %(levelname)s %(name)s: %(message)s",
    )

    bridge = UnityMcpBridge(
        UnityMcpBridgeConfig(
            host=args.host,
            port=args.port,
            timeout_seconds=args.timeout,
            unity_instance=args.instance,
        )
    )

    if args.command_name == "status":
        result = bridge.wait_until_ready()
    elif args.command_name == "instances":
        result = bridge.list_instances()
    elif args.command_name == "scene":
        result = bridge.inspect_scene()
    elif args.command_name == "call":
        result = bridge.command(args.tool, _load_json(args.params))
    elif args.command_name == "create-gameobject":
        result = bridge.create_gameobject(args.name, primitive_type=args.primitive)
    elif args.command_name == "play-mode":
        result = bridge.set_play_mode(args.state == "on")
    else:
        parser.error(f"Unknown command {args.command_name}")
        return 2

    print(json.dumps(result, indent=2, sort_keys=True))
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
