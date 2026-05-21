# T34 - Implement North Exit Lock

Task ID: T34
Source MVP card: MVP-012
Title: Implement locked north exit and room advance trigger
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Rooms/NorthExit.cs`.
- Updated `InternUnity/Assets/Scripts/Rooms/RoomManager.cs`.
- Added `NorthExit` trigger object to `InternUnity/Assets/Scenes/Game.unity`.
- Exit starts locked and rejects player trigger attempts while locked.
- Exit subscribes to `RoomManager.RoomCleared` and unlocks after all enemies die.
- Exit calls `RoomManager.AdvanceRoom()` when the Player enters while unlocked.
- `RoomManager.AdvanceRoom()` increments `CurrentRoomNumber` and respawns the first-slice Grunt set.
- Added `RoomManager.RoomAdvanced` event so NorthExit relocks after advance.
- No score grant was added for advancing.
- Added locked/unlocked visual state using generated sprites and tint fallback.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/world/doors/` plus `ui/feedback/`.
- Used `Intern/Assets/Generated/MVP/world/doors/world_north_exit_locked.png`.
- Used `Intern/Assets/Generated/MVP/ui/feedback/ui_door_indicator_locked.png`.
- Used `Intern/Assets/Generated/MVP/ui/feedback/ui_door_indicator_unlocked.png`.
- Imported those assets into `InternUnity/Assets/Generated/MVP/...` as single sprites.

## Verification

- Validated `NorthExit.cs` with Unity script validation: 0 errors, 0 warnings.
- Revalidated `RoomManager.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Game.unity` has NorthExit wired to RoomManager, trigger collider, state renderer, locked sprite, and unlocked sprite.
- Verified exit starts locked.
- Verified locked exit rejects player advance.
- Verified exit unlocks after room clear.
- Verified entering unlocked exit increments room number from `1` to `2`.
- Verified exit relocks after room advance.
- Verified advancing respawns 2 Grunts for the next room.
- Verified a locked post-advance trigger does not increment room number again.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T22.
- T33.

## Required Inputs / Docs
- `GDD.md`
- `Knowledge/decisions.md` decision `D02`
- `Core/Conventions.md`
- `Tasks/Open/T33_Coder-Implement-Room-Manager-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating north-exit placeholder visuals, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/world/doors/` plus `ui/feedback/`.
- Prefer generated locked/unlocked exit or door indicator assets when they preserve trigger clarity and portrait gameplay readability.
- In the task report, state which generated asset was used or why placeholders remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Rooms/NorthExit.cs`.
- Add locked/unlocked state, starting locked.
- Subscribe to RoomManager room-clear event and unlock.
- Ignore or reject player trigger while locked.
- Notify RoomManager on unlocked player trigger.
- Add placeholder visual/debug state for locked/unlocked.
- Update RoomManager to increment room number and respawn first-slice enemies on advance.

## Acceptance Criteria
- Exit starts locked.
- Player cannot advance through locked exit.
- Exit unlocks after all enemies die.
- Entering unlocked exit increments room number.
- Advancing does not grant score by itself.
