---
asset_id: world_north_exit_unlocked
category: world_door
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

# Asset: world_north_exit_unlocked

## Purpose
Unlocked north exit doorway art.

## Gameplay or UI Context
Door art communicates room entry, blocked north exit, or open path to the next room.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| unlocked | 320 | 160 | Door sprite size. | inferred_from_layout |

## Placement and Anchor Rules
Place on room edge: south entrance at bottom-center, north exit at top-center. Pivot center. Door collision and room transition are Unity objects, not baked in art.

## Visual Description
north stone doorway with open center and warm torch-gold rim glow. Thick black outline, chipped stones, scuffed texture, readable open/closed silhouette without relying only on color.

## States and Variants
- `unlocked`: unlocked state or variant
- `glow_ready`: glow_ready state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 320x160 px. Padding between cells: 16 px. Pivot: center. Target output filename: `world_north_exit_unlocked_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. No baked dynamic text or numbers.

## Generation Prompt
Create `world_north_exit_unlocked` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: north stone doorway with open center and warm torch-gold rim glow. Intended use: Game HUD. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: doorway sprite viewed three-quarter top-down with transparent outside edges. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Silhouette is readable at mobile scale.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers unless this file explicitly allows it.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent, semi-transparent, opaque, or chroma-key background rule is followed.
