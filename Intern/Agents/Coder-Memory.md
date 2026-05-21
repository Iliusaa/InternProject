---
type: InstanceFrame
owner: "[[Coder]]"
---
# Coder-Memory

> Write rule: append to **Recent**. Move oldest to **Archive** when Recent exceeds 3 entries.

## Recent
- 2026-05-21 - Completed `T28` player input reader: created `PlayerInputReader.cs`, exposed movement/aim/attack-held properties, wired it to `MovementJoystick` and `AimJoystick` in `Game.unity`, added Unity Input System editor fallback for WASD/arrow keys/Space/Left Ctrl/mouse, and verified script validation plus console clean.
- 2026-05-21 - Completed `T43` generated asset audit for completed `T##` tasks: imported generated primary button and joystick base sprites into `InternUnity/Assets/Generated/`, assigned them to scene navigation/debug buttons and `VirtualJoystick` base visuals, preserved UI callbacks/touch zones/layouts, documented missing `ui_joystick_thumb`, and verified no Unity console errors or warnings.
- 2026-05-21 - Completed `Coder-Check-UnityMCP-Connection-Stackspire`: verified MCP for Unity HTTP server `127.0.0.1:8080`, active `InternUnity@4aeccd3d152bab5d`, editor idle state, scene/asset/console reads, and temporary create/delete command flow. Added reusable external bridge under `Bridge/` with .NET runnable CLI and Python reference. Restored the temporary scene serialization probe back to tracked content.

## Archive
- 2026-05-20 - Completed `Coder-Update-Unity-Gitignore-Stackspire`: created root `.gitignore` with Unity-generated folder, IDE, crash/debug, and OS ignore rules; verified `Library/` is ignored and `.meta`, `ProjectSettings/`, and package manifest files remain trackable. No scripts were written.

## Scripts Registry
| Script | Path | Task | Status |
|--------|------|------|--------|
| `PlayerInputReader` | `InternUnity/Assets/Scripts/Input/PlayerInputReader.cs` | `T28` | active |

## Bugs Fixed
*(accumulate here — never archive, prevents repeating mistakes)*

## Lessons
*(project-validated knowledge — overrides the professional KB in `Agents/X.md` when there is a conflict. Never archive. Append with session number.)*
