# T24 - Create MVP Scene Bootstrap

Task ID: T24
Source MVP card: MVP-002
Title: Create MainMenu, ClassSelect, Game, and GameOver scene bootstrap
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T23.

## Required Inputs / Docs
- `Tasks/Open/T23_Coder-Audit-Unity-Baseline-Stackspire.md`
- `GDD.md`
- `Core/Conventions.md`
- `InternUnity/ProjectSettings/EditorBuildSettings.asset`

## Exact Deliverables
- Create `MainMenu`, `ClassSelect`, `Game`, and `GameOver` scenes.
- Add scenes to build settings in flow order.
- Implement `SceneNavigator` with load methods for all four scenes.
- Add placeholder navigation buttons/debug trigger for MainMenu -> ClassSelect -> Game -> GameOver -> ClassSelect/MainMenu.

## Acceptance Criteria
- MainMenu loads ClassSelect.
- ClassSelect loads Game.
- Game can load GameOver through a temporary debug trigger.
- GameOver can load ClassSelect and MainMenu.
- All scenes are in build settings.

