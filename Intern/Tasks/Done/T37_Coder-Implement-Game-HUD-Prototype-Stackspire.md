# T37 - Implement Game HUD Prototype

Task ID: T37
Source MVP card: MVP-015
Title: Implement basic Game HUD prototype
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/UI/GameHudBinder.cs`.
- Added `GameplayHudRoot` under `SafeAreaRoot` in `InternUnity/Assets/Scenes/Game.unity`.
- Added placeholder HUD text for Hearts, Score, Room, and Coins in portrait-safe top zones.
- Wired `GameHudBinder` to `PlayerHealth`, `RunScoreCounter`, `RunCoinCounter`, and `RoomManager`.
- HUD updates through gameplay events for health, score, current-run coins, and room advancement.
- Kept HUD text at the top edge so the central combat lane and lower joystick zones remain clear.

## Generated Asset Usage

- Checked generated HUD/icon/panel/joystick assets in `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/ui/`.
- No new generated HUD art was used for this task because the exact deliverable called for placeholder HUD text, and the existing generated assets either were not imported into Unity or were for buttons, panels, icons, and joystick art rather than required dynamic text labels.

## Verification

- Validated `GameHudBinder.cs` with Unity script validation: 0 errors, 0 warnings.
- Saved `InternUnity/Assets/Scenes/Game.unity` after adding and wiring the HUD.
- Verified initial HUD values: `Hearts 5/5`, `Score 0000`, `Room 1`, `Coins 000`.
- Verified score, room, and coin event updates: score changed to `Score 0020`, room changed to `Room 2`, coins changed to `Coins 001`.
- Verified health event update: hearts changed from `Hearts 5/5` to `Hearts 3/5` after damage.
- Checked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T26.
- T34.
- T35.
- T36.

## Required Inputs / Docs
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Core/Conventions.md`
- `Tasks/Open/T26_Coder-Implement-Safe-Area-Root-Stackspire.md`
- `Tasks/Open/T34_Coder-Implement-North-Exit-Lock-Stackspire.md`
- `Tasks/Open/T35_Coder-Implement-Run-Coin-Counter-Stackspire.md`
- `Tasks/Open/T36_Coder-Implement-Run-Score-Counter-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating HUD placeholder panels/icons, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/ui/hud/`, `ui/icons/`, `ui/panels/`, and `ui/joysticks/`.
- Prefer generated HUD assets when they preserve portrait safe-area layout, text readability, and combat-lane clarity.
- In the task report, state which generated assets were used or why placeholders remained necessary.

## Exact Deliverables
- Add placeholder HUD text under SafeAreaRoot in Game scene.
- Create `Assets/Scripts/UI/GameHudBinder.cs`.
- Bind HUD to `PlayerHealth`, `RunScoreCounter`, `RunCoinCounter`, and `RoomManager`.
- Display Hearts, Score, Room, and Coins.
- Place HUD values in portrait-safe zones and keep joystick visuals in lower-left/lower-right.

## Acceptance Criteria
- HUD displays current hearts.
- HUD displays score.
- HUD displays current room.
- HUD displays current-run coins.
- HUD updates when values change.
- Central combat lane remains readable.
