# UIUXDesigner Handoff - Rewrite UI/UX Spec For Portrait Mobile

Target agent: [[UIUXDesigner]]
Source: [[PM]]
Date: 2026-05-19
Deadline: 1 UIUXDesigner session

## Task
Rewrite the whole `Docs/UIUX_MVP_SPEC.md` for portrait-only mobile phones. Every menu, HUD element, button, touch control, and layout rule must be adjusted to make sense in portrait mode.

## Inputs
- `Tasks/Open/GameDesigner-Rewrite-GDD-Portrait-Mobile-Stackspire.md`
- `GDD.md` after the portrait rewrite is complete and BA-validated
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Tasks/Open/UIUX_Unity_Implementation.md`
- `Tasks/Open/UIUX_QA_Checklist.md`
- `Agents/UIUXDesigner.md`
- `Agents/UIUXDesigner-Memory.md`
- `Core/Conventions.md`

## Required Updates
- Use portrait-only mobile phone layout throughout the UI/UX spec.
- Set the active UI reference bounds to 1080 x 1920.
- Remove every landscape-mode layout rule, breakpoint, screen zone, and acceptance test.
- Redesign all MVP screens for portrait: Main Menu, Class Select, Upgrade Menu, Game HUD, Pause Overlay, Game Over, and any shared overlay or reusable component.
- Redefine HUD anchors, joystick placement, action/aim controls, pause access, health, score, room, and coin placement for one-handed/two-handed portrait phone play.
- Resize and reposition every button, card, list row, modal, icon, and touch target for portrait phone ergonomics.
- Carry forward the May 17 clarified requirements: killed-by display, current-run coins, banked coins after deposit, Rooms Climbed 0 boundary behavior, and Pause Restart discard behavior.
- Update `Tasks/Open/UIUX_Unity_Implementation.md` and `Tasks/Open/UIUX_QA_Checklist.md` where they still assume landscape mode.
- If `Docs/AssetSpecs/` or `Tasks/Open/UIUX_Art_Asset_Request.md` become invalid because of portrait sizing, create a follow-up task card instead of silently leaving the conflict.

## Constraints
- Do not add new MVP screens unless the portrait layout cannot express an existing required flow.
- Keep all labels, counters, prices, scores, and dynamic values as Unity UI text, not baked into sprites.
- Do not change gameplay balance or economy values.
- Do not begin Unity implementation.

## Acceptance Criteria
- `Docs/UIUX_MVP_SPEC.md` is fully portrait-only and uses 1080 x 1920 reference bounds.
- Searching `Docs/UIUX_MVP_SPEC.md` for `landscape` returns no active landscape-mode requirement.
- Every MVP menu, HUD, button, touch control, and overlay has portrait-specific placement and sizing guidance.
- UI implementation and QA handoffs no longer contain landscape-only instructions.
- Any remaining portrait asset-spec or ArtDirector conflicts are routed through a new `Tasks/Open/` handoff.
