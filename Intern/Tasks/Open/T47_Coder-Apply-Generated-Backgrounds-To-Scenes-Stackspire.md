# Coder Handoff - Apply Generated Backgrounds To Scenes

Target agent: [[Coder]]
Source: [[PM]]
Date: 2026-05-30
Priority: Medium - Visual Integration

## Context

Stackspire now has generated fullscreen background concept assets available in the Unity project under:

- `InternUnity/Assets/Generated/MVP/screens/screen_class_select_concept_stackspire_01.png`
- `InternUnity/Assets/Generated/MVP/screens/screen_class_select_concept_stackspire_02.png`
- `InternUnity/Assets/Generated/MVP/screens/screen_room_concept_stackspire_01.png`
- `InternUnity/Assets/Generated/MVP/screens/screen_room_concept_stackspire_02.png`

PM wants the existing background assets applied to the correct scenes/UI instead of remaining only as generated files.

## Task

Apply existing background assets to the correct Unity scenes/UI.

Use the class selection menu background asset for the class selection screen and the gameplay background asset during matches. Ensure proper scaling and positioning on mobile devices.

## Chosen Agent

[[Coder]]

## Routing Reason

This is a Unity scene/UI integration task involving scene hierarchy, Canvas/Image components, sprite import settings, RectTransform scaling, sorting/layering, and mobile portrait layout verification.

## Required References

Before editing, read or inspect:

- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Tasks/Done/T24_Coder-Create-MVP-Scene-Bootstrap-Stackspire.md`
- `Tasks/Done/T25_Coder-Create-Portrait-Canvas-Root-Stackspire.md`
- `Tasks/Done/T26_Coder-Implement-Safe-Area-Root-Stackspire.md`
- `Tasks/Done/T37_Coder-Implement-Game-HUD-Prototype-Stackspire.md`
- `Tasks/Done/T44_ArtDirector-Create-Stackspire-Fullscreen-Concepts.md`
- `InternUnity/Assets/Scenes/ClassSelect.unity`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Generated/MVP/screens/`

## Asset Selection

Default selections unless PM or ArtDirector provides a newer preference:

- Class Select scene: `screen_class_select_concept_stackspire_01.png`
- Game scene/match background: `screen_room_concept_stackspire_01.png`

Do not delete the alternate concepts. Leave these available for future review:

- `screen_class_select_concept_stackspire_02.png`
- `screen_room_concept_stackspire_02.png`

## Implementation Scope

Coder must:

- Add or wire a fullscreen background image in `ClassSelect.unity`.
- Add or wire a fullscreen gameplay room background in `Game.unity`.
- Ensure backgrounds render behind all UI, player, enemies, projectiles, exits, and gameplay/HUD elements.
- Use import settings appropriate for UI/background sprites.
- Ensure the background fills the portrait reference screen without distortion or unintended cropping.
- Confirm mobile scaling and positioning for portrait devices, including safe-area layouts.
- Keep existing gameplay and navigation behavior intact.
- Avoid replacing unrelated UI art or changing gameplay systems.

## Technical Guidance

Prefer the existing project patterns:

- If the scenes use a Canvas background layer, add the images as `Image` components with full-stretch RectTransforms behind the safe-area/content roots.
- If the gameplay room uses world-space/SpriteRenderer backgrounds, integrate the room background consistently with current camera framing and sorting layers.
- Keep the source assets at `1080x1920` portrait scale.
- Use anchors, pivots, scale mode, or preserve-aspect settings that keep the art stable across common Android portrait aspect ratios.
- Do not bake gameplay/HUD objects into these assets.

## Verification

Run or perform the best available checks:

- Unity compile/import check.
- Inspect `ClassSelect.unity` and confirm the class-selection background is visible behind class selection UI.
- Inspect `Game.unity` and confirm the gameplay room background is visible during matches behind gameplay objects and HUD.
- Verify the background fills the portrait screen at the `1080x1920` reference resolution.
- Check at least one narrower/taller mobile aspect ratio if feasible.
- Confirm no console errors or missing sprite references.

## Acceptance Criteria

- Class Select scene uses `screen_class_select_concept_stackspire_01.png` as its background.
- Game scene uses `screen_room_concept_stackspire_01.png` as its match/gameplay background.
- Backgrounds are correctly layered behind UI/gameplay objects.
- Backgrounds scale and position correctly on portrait mobile screens.
- Existing scene flow and gameplay remain functional.
- Alternate generated background concepts remain in the project and are not deleted.
- Coder records completion in `Agents/Coder-Memory.md`, `Sessions/YYYY-MM-DD.md`, and moves this handoff to `Tasks/Done/` after verification.
