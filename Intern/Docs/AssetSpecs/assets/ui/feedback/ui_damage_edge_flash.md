---
asset_id: ui_damage_edge_flash
category: ui_feedback
source_files:
  - STATUS.md
  - CONTEXT.md
  - GDD.md
  - Docs/UIUX_MVP_SPEC.md
  - Docs/Visual-Design.md
  - Tasks/Open/UIUX_Art_Asset_Request.md
  - Agents/UIUXDesigner.md
  - Agents/UIUXDesigner-Memory.md
  - Agents/ArtDirector.md
  - Agents/ArtDirector-Memory.md
  - Core/Conventions.md
  - Knowledge/decisions.md
screen_usage:
  - Game HUD
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_damage_edge_flash

## Purpose
Portrait UI edge damage flash overlay.

## Gameplay or UI Context
Brief full-screen edge feedback when the player takes damage. Unity controls timing and opacity.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| player_damage | 1080 | 1920 | Portrait screen-space overlay. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Stretch to the full 1080x1920 screen. Keep the center combat lane and top HUD readable by using edge-weighted alpha. The overlay should be short-lived and driven by Unity UI or post-process timing.

## Visual Description
Full-screen transparent edge vignette using damage red only. Thick ink edge breakup and strong shape language so state does not rely only on color. No gore decals, no body parts, and no baked text.

## States and Variants
- `player_damage`: red edge flash overlay

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Canvas size: 1080x1920 px unless the generation tool requires a larger clean source. Pivot: center. Target output filename: `ui_damage_edge_flash_portrait.png`. Do not bake labels, values, prices, scores, room numbers, or killed-by strings into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_damage_edge_flash` for Stackspire as original 2D dark fantasy mobile game UI feedback art, thick uneven black ink edge breakup, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable damage feedback. Subject: 1080x1920 portrait full-screen transparent edge vignette using damage red #D64A32 only, center mostly clear for combat readability. Intended use: Game HUD. Background rule: semi-transparent RGBA overlay on transparent background; do not use #00FF00 in final visuals. Composition and readability: portrait phone damage edge overlay with no readable text, no numbers, no watermark, no gore decals, and no copied UI symbols.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, realistic blood spray, gore splatter decals

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Edge flash reads as damage without blocking HUD or combat visibility.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct state is present.
- [ ] Correct transparent background rule is followed.