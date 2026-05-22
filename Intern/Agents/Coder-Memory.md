---
type: InstanceFrame
owner: "[[Coder]]"
---
# Coder-Memory

> Write rule: append to **Recent**. Move oldest to **Archive** when Recent exceeds 3 entries.

## Recent
- 2026-05-22 - Completed `T39` Warrior attack prototype: created `WarriorAttack.cs`, wired it to Player and `PlayerInputReader` in `Game.unity`, imported/generated slash feedback under `InternUnity/Assets/Generated/MVP/vfx/`, and verified play-mode arc damage against in-front, behind, and multi-target enemies with console clean.
- 2026-05-22 - Completed `T40` GameOver flow: added `RunResult`, `LastRunResult`, `RunEndController`, and `GameOverBinder`; wired `Game.unity` death handling to capture score, rooms climbed, coins, banked coins, and killed-by source; rebuilt `GameOver.unity` with generated stat panel/button art and dynamic labels; verified lethal death loads GameOver, Room 1 death shows 0 rooms climbed, Restart returns to ClassSelect, Main Menu returns to MainMenu, and console clean.
- 2026-05-22 - Completed `T41` save system stub: added `SaveData`, `SaveService`, and `SaveDebugControls`; PlayerPrefs JSON persistence now stores high score, banked coins, upgrade levels, and class special flags; `RunEndController` now deposits score and coins through `SaveService`; verified defaults, persistence across Play Mode stop/start, reset, and console clean.

## Archive
- 2026-05-22 - Completed `T38` class selection state: added `PlayerClassId`, runtime `ClassSelectionState`, `ClassSelectionController`, and `SelectedClassDebugDisplay`; wired ClassSelect Warrior/Archer/Mage buttons and Start button; added Game scene debug class label; verified play-mode class button selection and console clean.
- 2026-05-21 - Completed `Coder-Check-UnityMCP-Connection-Stackspire`: verified MCP for Unity HTTP server `127.0.0.1:8080`, active `InternUnity@4aeccd3d152bab5d`, editor idle state, scene/asset/console reads, and temporary create/delete command flow. Added reusable external bridge under `Bridge/` with .NET runnable CLI and Python reference. Restored the temporary scene serialization probe back to tracked content.
- 2026-05-20 - Completed `Coder-Update-Unity-Gitignore-Stackspire`: created root `.gitignore` with Unity-generated folder, IDE, crash/debug, and OS ignore rules; verified `Library/` is ignored and `.meta`, `ProjectSettings/`, and package manifest files remain trackable. No scripts were written.
- 2026-05-21 - Completed `T28` player input reader: created `PlayerInputReader.cs`, exposed movement/aim/attack-held properties, wired it to `MovementJoystick` and `AimJoystick` in `Game.unity`, added Unity Input System editor fallback for WASD/arrow keys/Space/Left Ctrl/mouse, and verified script validation plus console clean.
- 2026-05-21 - Completed `T43` generated asset audit for completed `T##` tasks: imported generated primary button and joystick base sprites into `InternUnity/Assets/Generated/`, assigned them to scene navigation/debug buttons and `VirtualJoystick` base visuals, preserved UI callbacks/touch zones/layouts, documented missing `ui_joystick_thumb`, and verified no Unity console errors or warnings.

## Scripts Registry
| Script | Path | Task | Status |
|--------|------|------|--------|
| `PlayerInputReader` | `InternUnity/Assets/Scripts/Input/PlayerInputReader.cs` | `T28` | active |
| `PlayerClassId` | `InternUnity/Assets/Scripts/Classes/PlayerClassId.cs` | `T38` | active |
| `ClassSelectionState` | `InternUnity/Assets/Scripts/Classes/ClassSelectionState.cs` | `T38` | active |
| `ClassSelectionController` | `InternUnity/Assets/Scripts/Classes/ClassSelectionController.cs` | `T38` | active |
| `SelectedClassDebugDisplay` | `InternUnity/Assets/Scripts/Classes/SelectedClassDebugDisplay.cs` | `T38` | active |
| `WarriorAttack` | `InternUnity/Assets/Scripts/Combat/WarriorAttack.cs` | `T39` | active |
| `RunResult` | `InternUnity/Assets/Scripts/Run/RunResult.cs` | `T40` | active |
| `LastRunResult` | `InternUnity/Assets/Scripts/Run/LastRunResult.cs` | `T40` | active |
| `RunEndController` | `InternUnity/Assets/Scripts/Run/RunEndController.cs` | `T40` | active |
| `GameOverBinder` | `InternUnity/Assets/Scripts/UI/GameOverBinder.cs` | `T40` | active |
| `SaveData` | `InternUnity/Assets/Scripts/Save/SaveData.cs` | `T41` | active |
| `SaveService` | `InternUnity/Assets/Scripts/Save/SaveService.cs` | `T41` | active |
| `SaveDebugControls` | `InternUnity/Assets/Scripts/Save/SaveDebugControls.cs` | `T41` | active |

## Bugs Fixed
*(accumulate here — never archive, prevents repeating mistakes)*

## Lessons
*(project-validated knowledge — overrides the professional KB in `Agents/X.md` when there is a conflict. Never archive. Append with session number.)*
