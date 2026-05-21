# T27 - Implement Virtual Joystick

Task ID: T27
Source MVP card: MVP-005
Title: Implement reusable virtual joystick component
Owner agent: [[Coder]]
Status: done

## Completion
Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/Input/VirtualJoystick.cs`.
- Exposed read-only `Direction`, `Magnitude`, and `IsHeld` properties.
- Added serialized `activeRadius`, `deadZone`, `thumb`, opacity, and `CanvasGroup` fields.
- Created placeholder `InternUnity/Assets/Prefabs/UI/VirtualJoystick.prefab` with a 340 x 340 touch zone, 240 x 240 base visual, and 96 x 96 thumb.
- Added independent `MovementJoystick` and `AimJoystick` prefab instances under the `Game` scene `SafeAreaRoot`.
- Placed movement joystick at bottom-left `(235, 245)` and aim joystick at bottom-right `(-235, 245)` inside the safe area.
- Verified pointer down/up behavior: held state changes, direction/magnitude output updates, and thumb returns to center on release.

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
