# T41 - Implement Save System Stub

Task ID: T41
Source MVP card: MVP-019
Title: Implement save system stub for MVP progression values
Owner agent: [[Coder]]
Status: pending

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Save/SaveData.cs`.
- Created `InternUnity/Assets/Scripts/Save/SaveService.cs`.
- Created `InternUnity/Assets/Scripts/Save/SaveDebugControls.cs`.
- Used `PlayerPrefs` with JSON payload key `Stackspire.MVP.SaveData.v1` for stub persistence.
- Save data stores high score, total banked coins, four global upgrade levels, and three class special flags.
- Defaults load with zero high score, zero banked coins, level 0 upgrades, and unbought class specials.
- Added get/set methods for high score and total banked coins.
- Added upgrade level and class special get/set helpers.
- Added reset through `SaveService.ResetSave()` and `SaveDebugControls` context menu.
- Updated `RunEndController` to deposit completed run score and current-run coins through `SaveService.DepositRunResult()`.

## Verification

- Validated `SaveData.cs`, `SaveService.cs`, `SaveDebugControls.cs`, and updated `RunEndController.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified first-run defaults after `ResetSave()`.
- Verified high score can be set, saved, and loaded.
- Verified total banked coins can be set, saved, and loaded.
- Verified upgrade level and class special state can be set, saved, and loaded.
- Verified `DepositRunResult()` updates high score and adds current-run coins to total banked coins.
- Verified save reset clears high score and total banked coins.
- Verified Play Mode persistence across stop/start: high score `321` and banked coins `45` reloaded after restarting Play Mode.
- Reset the test save after verification.
- Rechecked Unity console after implementation and Play Mode tests: 0 errors, 0 warnings.

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
