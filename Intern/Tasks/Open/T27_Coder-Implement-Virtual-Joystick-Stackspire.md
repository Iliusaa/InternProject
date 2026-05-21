# T27 - Implement Virtual Joystick

Task ID: T27
Source MVP card: MVP-005
Title: Implement reusable virtual joystick component
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T26.

## Required Inputs / Docs
- `Docs/UIUX_MVP_SPEC.md`
- `Core/Conventions.md`
- `Tasks/Open/T26_Coder-Implement-Safe-Area-Root-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Input/VirtualJoystick.cs`.
- Expose normalized direction, analog magnitude, and held state.
- Add serialized active radius and dead zone.
- Create placeholder `Assets/Prefabs/UI/VirtualJoystick.prefab`.
- Add movement and aim joystick instances to Game scene.

## Acceptance Criteria
- Joystick outputs direction and magnitude while dragged.
- Held state is true while pressed and false when released.
- Thumb visual returns to center on release.
- Two joystick instances can operate independently.

