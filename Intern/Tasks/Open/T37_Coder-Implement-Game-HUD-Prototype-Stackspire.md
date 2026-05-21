# T37 - Implement Game HUD Prototype

Task ID: T37
Source MVP card: MVP-015
Title: Implement basic Game HUD prototype
Owner agent: [[Coder]]
Status: pending

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
