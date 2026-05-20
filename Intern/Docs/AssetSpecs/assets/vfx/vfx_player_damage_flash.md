---
asset_id: vfx_player_damage_flash
category: vfx
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

# Asset: vfx_player_damage_flash

## Purpose
Full-screen portrait player damage flash overlay.

## Gameplay or UI Context
Brief red edge flash when player loses one heart. This is a screen-space VFX overlay for the portrait Game HUD.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| player_damage | 1080 | 1920 | Portrait screen-space VFX cell. | Docs/UIUX_MVP_SPEC.md |
| fade | 1080 | 1920 | Fade-out cell aligned to player_damage. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Pivot center unless used as a full-screen overlay, where it stretches to all screen edges. Layer above world sprites but below persistent HUD when possible; use low opacity and a short duration so it does not block combat readability.

## Visual Description
Transparent portrait full-screen vignette with bright damage red edge flash only. Painterly alpha edges, thick ink breakup, high contrast, no lingering gore decals, no body parts, and no baked text.

## States and Variants
- `player_damage`: immediate damage edge flash
- `fade`: softer fade-out state

## Sprite Sheet or Export Plan
Export as PNG/RGBA with semi-transparent background. Use one horizontal state sheet. Cell size: 1080x1920 px. Padding between cells: 16 px. Pivot: center. Target output filename: `vfx_player_damage_flash_portrait_sheet.png`. No baked dynamic text or numbers.

## Generation Prompt
Create `vfx_player_damage_flash` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, thick uneven black ink breakup, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable damage feedback. Subject: transparent 1080x1920 portrait full-screen vignette with bright damage red edge flash only. Intended use: Game HUD. Palette: ink void #0E0B10 #17131A #262129, damage red #D64A32 reserved only for damage and urgent feedback. Background rule: semi-transparent RGBA overlay on transparent background; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: clean transparent VFX state sheet with no readable text, no numbers, no watermark, no gore decals, and no copied game UI symbols.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, realistic blood spray, gore splatter decals

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Flash reads as damage feedback without blocking HUD or combat visibility.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent background rule is followed.