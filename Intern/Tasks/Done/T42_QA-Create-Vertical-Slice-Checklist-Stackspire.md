# T42 - Create Vertical Slice QA Checklist

Task ID: T42
Source MVP card: MVP-020
Title: Create debug QA checklist for the first playable vertical slice
Owner agent: [[QA]]
Status: done

## Completion

Done on 2026-05-22.

- Created `Intern/Docs/QA/Vertical-Slice-Checklist-Stackspire.md`.
- Checklist covers `MainMenu -> ClassSelect -> Game -> clear room -> advance -> die -> GameOver -> Restart`.
- Included expected Room 1 values: 2 Grunts, 2 coins, and 65 score after clear.
- Covered joystick/player movement, Warrior attack, Grunt death, room clear, locked/unlocked north exit, score, coins, HUD, death, GameOver stats, save persistence smoke, generated asset readability, and portrait safe-area checks.
- Recorded available partial debug aids and explicitly listed missing Coder follow-up for full debug playtest controls.
- Included known out-of-scope gaps for this slice.

## Dependencies
- T40.

## Required Inputs / Docs
- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Tasks/Open/T40_Coder-Implement-GameOver-Flow-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`
- Active Unity vertical-slice scene once implemented.

## Generated Asset Requirement
- Include QA checklist coverage for whether relevant generated assets were checked, used, or explicitly rejected as unsuitable.
- Verify generated assets do not reduce gameplay readability, portrait safe-area compliance, collision clarity, or dynamic text readability.
- Note any missing, obsolete, temporary-only, or unsuitable generated assets as follow-up items.

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
