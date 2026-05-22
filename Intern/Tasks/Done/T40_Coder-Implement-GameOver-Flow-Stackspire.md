# T40 - Implement GameOver Flow

Task ID: T40
Source MVP card: MVP-018
Title: Implement basic GameOver flow and run stats transfer
Owner agent: [[Coder]]
Status: pending

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Run/RunResult.cs`.
- Created `InternUnity/Assets/Scripts/Run/LastRunResult.cs` as the runtime holder for the latest run result.
- Created `InternUnity/Assets/Scripts/Run/RunEndController.cs`.
- Added `RunEndController` to `InternUnity/Assets/Scenes/Game.unity` and wired it to `PlayerHealth`, `RunScoreCounter`, `RunCoinCounter`, and `RoomManager`.
- `RunEndController` subscribes to `PlayerHealth.Died`, captures final score, rooms climbed, current-run coins, killed-by source, and placeholder total banked coins, then loads `GameOver`.
- Created `InternUnity/Assets/Scripts/UI/GameOverBinder.cs`.
- Rebuilt `InternUnity/Assets/Scenes/GameOver.unity` with a portrait Canvas, dynamic stat labels, Restart, and Main Menu buttons.
- Restart returns to `ClassSelect`.
- Main Menu returns to `MainMenu`.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/`, `Intern/Assets/Generated/MVP/ui/menus/`, `ui/panels/`, `ui/buttons/`, `ui/icons/`, and `screens/`.
- Imported and used `Intern/Assets/Generated/MVP/ui/menus/ui_game_over_stat_panel_normal.png` as the GameOver stat panel under `InternUnity/Assets/Generated/MVP/ui/menus/`.
- Reused `InternUnity/Assets/Generated/UI/Buttons/ui_button_primary_gold_default.png` for Restart and Main Menu buttons.
- Full-screen mockups remained reference-only because they would embed layout/background assumptions and reduce dynamic text readability.

## Verification

- Validated `RunResult.cs`, `LastRunResult.cs`, `RunEndController.cs`, and `GameOverBinder.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `RunEndController` scene references in `Game.unity`: Player, RoomManager, RunCoinCounter, RunScoreCounter, and `GameOver` scene name.
- Play-mode smoke test: applying lethal damage in Room 1 loaded `GameOver`.
- Verified GameOver showed `Final Score 0000`, `Rooms Climbed 0`, `Coins Earned 000`, `Banked Coins 000`, and killed-by source `Editor Test Damage`.
- Verified Restart button returned to `ClassSelect`.
- Verified Main Menu button returned to `MainMenu`.
- Rechecked Unity console after implementation and play-mode tests: 0 errors, 0 warnings.

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
