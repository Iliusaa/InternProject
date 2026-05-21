# T33 - Implement Room Manager

Task ID: T33
Source MVP card: MVP-011
Title: Implement first playable room manager
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T32.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T32_Coder-Implement-Grunt-Chase-Stackspire.md`

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

