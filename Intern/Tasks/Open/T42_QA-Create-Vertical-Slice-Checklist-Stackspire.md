# T42 - Create Vertical Slice QA Checklist

Task ID: T42
Source MVP card: MVP-020
Title: Create debug QA checklist for the first playable vertical slice
Owner agent: [[QA]]
Status: pending

## Dependencies
- T40.

## Required Inputs / Docs
- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Tasks/Open/T40_Coder-Implement-GameOver-Flow-Stackspire.md`
- Active Unity vertical-slice scene once implemented.

## Exact Deliverables
- Create a markdown checklist under `Intern/Docs/QA/` or `Intern/Tasks/Open/`.
- Cover MainMenu -> ClassSelect -> Game -> clear room -> advance -> die -> GameOver -> Restart.
- Include expected Room 1 values: 2 Grunts, 2 coins, 65 score after clear.
- Verify joystick/player movement, Warrior attack, Grunt death, room clear, locked/unlocked exit, score, coins, HUD, death, and GameOver stats.
- Record whether debug playtest controls exist; if missing, explicitly list the missing Coder follow-up instead of blocking the checklist.
- Include known out-of-scope gaps for this slice.

## Acceptance Criteria
- QA checklist file exists.
- Checklist covers scene flow.
- Checklist covers joystick/player movement.
- Checklist covers Warrior attack and Grunt death.
- Checklist covers room clear and locked/unlocked exit.
- Checklist covers score, coins, HUD, death, and GameOver stats.
- Debug controls are available or explicitly listed as not yet implemented.

