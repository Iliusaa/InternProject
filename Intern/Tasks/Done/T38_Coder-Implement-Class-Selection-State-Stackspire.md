# T38 - Implement Class Selection State

Task ID: T38
Source MVP card: MVP-016
Title: Implement basic class selection data
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Classes/PlayerClassId.cs`.
- Created runtime `ClassSelectionState` with Warrior as the default selected class.
- Created `ClassSelectionController` for class-selection UI button methods.
- Created `SelectedClassDebugDisplay` for the temporary Game scene class label.
- Added placeholder Warrior, Archer, Mage, and Start buttons to `InternUnity/Assets/Scenes/ClassSelect.unity`.
- Removed overlapping ClassSelect bootstrap placeholder UI from `SafeAreaRoot`.
- Wired class buttons to update the runtime selection.
- Wired Start to the existing `SceneNavigator.LoadGame()`.
- Added `SelectedClassDebugRoot` to `InternUnity/Assets/Scenes/Game.unity` so Game can read and display the selected class.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/ui/cards/`, `ui/icons/`, and `characters/`.
- Kept placeholder class-selection buttons because class card/icon/Archer/Mage character assets were not imported into `InternUnity/Assets/Generated/` yet, and the task required simple temporary selection controls.

## Verification

- Validated all new class-selection scripts with Unity script validation: 0 errors, 0 warnings.
- Verified play-mode button clicks select Warrior, Archer, and Mage after placeholder cleanup.
- Verified the Game scene selected-class debug display reads the runtime selected class after placeholder cleanup.
- Checked Unity console after implementation: 0 errors, 0 warnings.

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
