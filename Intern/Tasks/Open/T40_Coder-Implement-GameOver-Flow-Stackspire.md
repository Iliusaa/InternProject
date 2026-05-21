# T40 - Implement GameOver Flow

Task ID: T40
Source MVP card: MVP-018
Title: Implement basic GameOver flow and run stats transfer
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T30.
- T34.
- T35.
- T36.

## Required Inputs / Docs
- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Core/Conventions.md`
- `Tasks/Open/T30_Coder-Implement-Player-Health-Damage-Stackspire.md`
- `Tasks/Open/T34_Coder-Implement-North-Exit-Lock-Stackspire.md`
- `Tasks/Open/T35_Coder-Implement-Run-Coin-Counter-Stackspire.md`
- `Tasks/Open/T36_Coder-Implement-Run-Score-Counter-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating GameOver placeholder UI panels/icons, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/ui/menus/`, `ui/panels/`, `ui/buttons/`, `ui/icons/`, and `screens/`.
- Prefer generated GameOver/result UI assets when they preserve dynamic text readability and portrait safe-area layout.
- Treat full-screen mockups as visual references unless they are technically suitable as temporary backgrounds.
- In the task report, state which generated assets were used or why placeholders remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Run/RunResult.cs`.
- Create runtime holder for the last run result.
- Create `Assets/Scripts/Run/RunEndController.cs`.
- Subscribe to `PlayerHealth` death event.
- On death, collect score, rooms climbed, current-run coins, killed-by source, and placeholder total banked coins.
- Load GameOver scene.
- Create `Assets/Scripts/UI/GameOverBinder.cs`.
- Wire Restart to ClassSelect and Main Menu to MainMenu.

## Acceptance Criteria
- Player death loads GameOver.
- GameOver shows final score.
- GameOver shows rooms climbed.
- GameOver shows current-run coins.
- GameOver shows killed-by source.
- Death in Room 1 before north exit shows Rooms Climbed 0.
- Restart returns to ClassSelect.
