# T38 - Implement Class Selection State

Task ID: T38
Source MVP card: MVP-016
Title: Implement basic class selection data
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T24.

## Required Inputs / Docs
- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Core/Conventions.md`
- `Tasks/Open/T24_Coder-Create-MVP-Scene-Bootstrap-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating class-selection placeholder visuals, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/ui/cards/`, `ui/icons/`, and `characters/`.
- Prefer generated class cards/icons/sprites when they preserve button clarity, selected-state readability, and portrait layout.
- In the task report, state which generated assets were used or why placeholders remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Classes/PlayerClassId.cs`.
- Create runtime `ClassSelectionState`.
- Default selection to Warrior.
- Add placeholder Warrior, Archer, and Mage buttons in ClassSelect.
- Update selection from class buttons.
- Make selected class available to Game scene.
- Add temporary Game scene debug display for selected class.

## Acceptance Criteria
- Warrior, Archer, and Mage can be selected.
- Warrior is default if no explicit selection occurs.
- Game scene can read selected class.
- Selected class survives scene transition from ClassSelect to Game.
