"""Minimal Unity MCP bridge examples.

Run from the repository root:

    python Intern/Bridge/examples/unity_bridge_examples.py
"""

from __future__ import annotations

import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
sys.path.insert(0, str(ROOT))

from Bridge.unity_mcp_bridge import UnityMcpBridge  # noqa: E402


def show(label: str, value: object) -> None:
    print(f"\n## {label}")
    print(json.dumps(value, indent=2, sort_keys=True))


def main() -> int:
    bridge = UnityMcpBridge()

    show("status", bridge.wait_until_ready())
    show("active scene", bridge.command("manage_scene", {"action": "get_active"}))
    show("hierarchy", bridge.command("manage_scene", {"action": "get_hierarchy", "pageSize": 25}))
    show("assets", bridge.search_assets(filter_type="Scene", page_size=10))
    show("console", bridge.read_console(count=10))

    # Mutating example. Uncomment when you want to verify write/control flow.
    # created = bridge.create_gameobject("AgentBridgeProbe", primitive_type="Cube", position=[0, 0, 0])
    # show("created GameObject", created)
    # show("deleted GameObject", bridge.delete_gameobject("AgentBridgeProbe", search_method="by_name"))

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
