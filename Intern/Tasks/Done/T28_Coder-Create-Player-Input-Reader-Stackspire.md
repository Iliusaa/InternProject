# T28 - Create Player Input Reader

Task ID: T28
Source MVP card: MVP-006
Title: Create movement and aim/attack input abstraction
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/Input/PlayerInputReader.cs`.
- Added serialized `movementJoystick`, `aimJoystick`, and `enableEditorFallback` fields.
- Exposed read-only `MovementVector`, `AimVector`, and `AttackHeld` properties.
- Reads mobile movement from the movement `VirtualJoystick`.
- Reads mobile aim direction and attack-held state from the aim `VirtualJoystick`.
- Added editor fallback through Unity's active Input System:
  - WASD for movement.
  - Arrow keys for aim.
  - Space or Left Ctrl for keyboard attack-held.
  - Left or right mouse button for mouse attack-held, with mouse aim from screen center.
- Keeps missing joystick references safe by returning zero vectors and false attack state.
- Added a `PlayerInputReader` GameObject to `InternUnity/Assets/Scenes/Game.unity`.
- Wired the scene reader to existing `MovementJoystick` and `AimJoystick` instances.

## Generated / Project Asset Check

Not applicable. This task has no visual asset surface; it adds input abstraction only.

## Dependencies

- T27.

## Required Inputs / Docs

- `Core/Conventions.md`
- `Tasks/Done/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`

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

## Verification

- Validated `PlayerInputReader.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Game.unity` has `PlayerInputReader` wired to `MovementJoystick` and `AimJoystick`.
- Verified initial reader output is safe at rest: movement `(0, 0)`, aim `(0, 0)`, attack-held `false`.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.
