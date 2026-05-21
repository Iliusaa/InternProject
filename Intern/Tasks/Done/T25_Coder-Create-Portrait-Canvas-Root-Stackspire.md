# T25 - Create Portrait Canvas Root

Task ID: T25
Source MVP card: MVP-003
Title: Create a reusable portrait Canvas root for MVP UI screens
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T24.

## Required Inputs / Docs
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Tasks/Open/T24_Coder-Create-MVP-Scene-Bootstrap-Stackspire.md`
- `InternUnity/Assets/Scenes/`

## Exact Deliverables
- Create `Assets/Prefabs/UI/PortraitCanvasRoot.prefab`.
- Configure Canvas, Canvas Scaler, and Graphic Raycaster.
- Set Canvas to Screen Space - Overlay.
- Set Canvas Scaler to Scale With Screen Size, reference resolution `1080 x 1920`, match `0.5`.
- Add the canvas root or equivalent scene root to current MVP scenes.

## Acceptance Criteria
- Reusable portrait Canvas root exists.
- Canvas reference resolution is `1080 x 1920`.
- Canvas Scaler match value is `0.5`.
- Placeholder UI appears correctly in portrait Game view.

