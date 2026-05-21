# T33 - Implement Room Manager

Task ID: T33
Source MVP card: MVP-011
Title: Implement first playable room manager
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Rooms/RoomManager.cs`.
- Added `RoomManager` to `InternUnity/Assets/Scenes/Game.unity`.
- Added serialized Grunt enemy prefab reference.
- Added serialized spawn point list with two Room 1 Grunt spawn points.
- Added serialized player target reference so spawned Grunts chase the scene Player.
- Tracks `CurrentRoomNumber`, starting at `1`.
- Spawns exactly 2 Grunts for Room 1.
- Tracks active spawned enemies.
- Subscribes to `EnemyBase.Died`.
- Fires `RoomCleared` exactly once when all active enemies are dead.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/world/rooms/` plus `world/props/`.
- Found `world_floor_tile_stone_default.png` and `world_torch_prop_lit.png`.
- No room placeholder visual was created for this task because the deliverable only required room spawning/tracking and scene spawn points; adding floor/prop art here would not improve the manager behavior or acceptance criteria.

## Verification

- Validated `RoomManager.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Game.unity` has `RoomManager` with Grunt prefab, Player target, and 2 spawn points wired.
- Verified current room number starts at `1`.
- Verified Room 1 spawns exactly 2 Grunts.
- Verified active enemy count starts at 2 after spawning.
- Verified room clear does not fire before both Grunts die.
- Verified room clear fires exactly once after both Grunts die.
- Verified repeated death/damage after room clear does not fire a second clear event.
- Checked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T32.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T32_Coder-Implement-Grunt-Chase-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating room placeholder visuals, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/world/rooms/` or `world/props/`.
- Use generated floor/room/prop assets only when they improve orientation without hiding enemies, projectiles, exits, or joystick-safe gameplay space.
- In the task report, state which generated asset was used or why placeholders remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Rooms/RoomManager.cs`.
- Add serialized enemy prefab reference and spawn point list.
- Spawn exactly 2 Grunts for Room 1.
- Track active spawned enemies.
- Subscribe to enemy death events.
- Fire room clear event once when all enemies are dead.
- Track current room number starting at 1.

## Acceptance Criteria
- Room 1 spawns exactly 2 Grunts.
- RoomManager tracks active enemies.
- Room clear event fires exactly once when both Grunts die.
- Current room number starts at 1.
