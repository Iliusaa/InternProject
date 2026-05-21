# T35 - Implement Run Coin Counter

Task ID: T35
Source MVP card: MVP-013
Title: Implement current-run coin counter
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T33.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T33_Coder-Implement-Room-Manager-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Run/RunCoinCounter.cs`.
- Subscribe to enemy death events from RoomManager or spawned enemies.
- Add 1 current-run coin per enemy death.
- Expose coin changed event.
- Reset current-run coins on new run start.
- Add debug inspector display or log.

## Acceptance Criteria
- Each enemy death adds +1 current-run coin.
- Current-run coin count updates immediately on enemy death.
- Current-run coins can reset at run start.
- No pickup interaction is required.

