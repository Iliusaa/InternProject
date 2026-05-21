# T34 - Implement North Exit Lock

Task ID: T34
Source MVP card: MVP-012
Title: Implement locked north exit and room advance trigger
Owner agent: [[Coder]]
Status: pending

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
