# T28 - Create Player Input Reader

Task ID: T28
Source MVP card: MVP-006
Title: Create movement and aim/attack input abstraction
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T27.

## Required Inputs / Docs
- `Core/Conventions.md`
- `Tasks/Open/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Input/PlayerInputReader.cs`.
- Reference movement and aim joysticks through serialized fields.
- Expose read-only movement vector, aim vector, and attack-held state.
- Add editor fallback for WASD movement and mouse/key aim attack.
- Keep values normalized and safe when joystick references are missing.

## Acceptance Criteria
- Movement vector is available to gameplay code.
- Aim vector and attack-held state are available to gameplay code.
- WASD movement works in editor.
- Mobile joystick input remains supported.
- No gameplay movement or combat is implemented in this component.

