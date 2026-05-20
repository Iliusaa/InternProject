# Coder Handoff - Check UnityMCP Server Connection

Target agent: [[Coder]]
Source: [[PM]]
Date: 2026-05-18
Deadline session: next [[Coder]] session

## Task

Verify that the Stackspire Unity project can connect to the UnityMCP server before implementation work continues.

## Inputs

- `Agents/Coder.md`
- `Core/Conventions.md`
- UnityMCP endpoint from project environment: `localhost:8080`
- Unity project workspace: `C:\Users\user\Intern\Intern`
- UnityMCP editor resources/tools, starting with editor state and console reads

## Scope

- Perform a read-only UnityMCP connectivity check.
- Confirm whether a Unity Editor instance is active for this project.
- Confirm whether the editor is ready for tools or blocked by compilation, domain reload, missing instance, or connection failure.
- Check recent Unity console errors relevant to MCP/editor readiness.
- Do not implement gameplay, UI, art, scene, prefab, or script changes.

## Suggested Checks

- Read Unity editor state, such as `mcpforunity://editor/state`, if available.
- Read project or active-scene info through UnityMCP, such as active scene or project info.
- Call a read-only UnityMCP tool such as console read or editor telemetry ping.
- If multiple Unity instances are available, identify the active instance and whether it matches Stackspire.

## Required Output

- Append a `## Coder Report` section to this task card with:
  - connection result: connected or not connected
  - active Unity instance/project, if detected
  - editor readiness state and blocking reasons, if available
  - recent console errors or a note that none were found
  - exact MCP resources/tools used for the check
- If the connection is verified and no setup blocker remains, move this card to `Tasks/Done/`.
- If the connection fails or editor setup blocks tool use, leave this card in `Tasks/Open/` and create a PM blocker handoff in `Tasks/Open/`.

## Acceptance Criteria

- UnityMCP server reachability is verified with at least one successful UnityMCP resource or tool response, or the failure mode is clearly documented.
- Active Unity instance/project status is documented.
- Editor readiness and console status are documented.
- No project assets, scenes, prefabs, or scripts are changed as part of this check.
