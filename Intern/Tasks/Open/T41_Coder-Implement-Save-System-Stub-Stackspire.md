# T41 - Implement Save System Stub

Task ID: T41
Source MVP card: MVP-019
Title: Implement save system stub for MVP progression values
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T23.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T23_Coder-Audit-Unity-Baseline-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Save/SaveData.cs`.
- Create `Assets/Scripts/Save/SaveService.cs`.
- Use PlayerPrefs or local JSON for stub persistence.
- Store high score, total banked coins, upgrade levels, and class special flags.
- Load defaults when no save exists.
- Add get/set methods for high score and banked coins.
- Add editor debug reset method or `SaveDebugControls`.

## Acceptance Criteria
- Save data loads with default values on first run.
- High score can be set and saved.
- Total banked coins can be set and saved.
- Data persists after stopping and starting Play Mode if using PlayerPrefs, or after app restart if built.
- Save reset clears stored values.
- Save service does not depend on UI scene objects.

