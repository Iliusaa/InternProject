---
asset_id: world_room_template_stone_chamber
category: world_room
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

# Asset: world_room_template_stone_chamber

## Purpose
Reusable stone chamber room template.

## Gameplay or UI Context
Active combat room backdrop with clear south entrance and north exit.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| room_template | 900 | 1250 | World room art bounds inside the 1080x1920 reference frame, fitting the portrait combat lane above the bottom joystick zone. | inferred_from_layout |

## Placement and Anchor Rules
Center in Game screen behind HUD. Align north exit to top-center and south entrance to bottom-center. Keep combat lane x 80-1000 and y 170-1420 readable.

## Visual Description
Tall stone chamber in three-quarter top-down view with crooked masonry, grime, candle pools, heavy corner shadows, low-detail center floor, clear exits, and no UI text.

## States and Variants
- `default`: default state or variant
- `cleared_lighting_source`: cleared_lighting_source state or variant

## Sprite Sheet or Export Plan
Export as an opaque PNG at 900x1250 px. Pivot: center. Target output filename: `world_room_template_stone_chamber_portrait.png`. Keep UI labels and numbers out of the bitmap so Unity UI can layer text above it.

## Generation Prompt
Create `world_room_template_stone_chamber` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: three-quarter top-down dark stone dungeon chamber with clear north and south exits and low-clutter combat floor. Intended use: Game HUD. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: opaque portrait room background; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: full room asset with UI-safe margins and no labels. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, ornate unreadable floor clutter, strict side-scroller perspective

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Silhouette is readable at mobile scale.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers unless this file explicitly allows it.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent, semi-transparent, opaque, or chroma-key background rule is followed.
