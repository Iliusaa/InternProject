# T36 - Implement Run Score Counter

Task ID: T36
Source MVP card: MVP-014
Title: Implement run score from enemy kills and room clears
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T33.
- T34.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T33_Coder-Implement-Room-Manager-Stackspire.md`
- `Tasks/Open/T34_Coder-Implement-North-Exit-Lock-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Run/RunScoreCounter.cs`.
- Subscribe to enemy death events.
- Add +20 score per enemy death.
- Subscribe to room clear event.
- Add +25 score once on room clear.
- Expose score changed event.
- Reset score on new run start.

## Acceptance Criteria
- Each enemy death adds +20 score immediately.
- Room clear adds +25 score once.
- Entering north exit adds no score.
- Clearing Room 1 with 2 Grunts results in 65 score.

