---
asset_id: ui_result_stat_row
category: ui_row
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
  - Game Over
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_result_stat_row

## Purpose
Reusable Game Over stat row backing.

## Gameplay or UI Context
Reusable UI art or layout backing. Unity supplies dynamic text, numbers, values, and child icons.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 700 | 64 | Primary display or state cell size. | inferred_from_layout |
| highlight | 700 | 64 | Additional state cell size. | inferred_from_layout |

## Placement and Anchor Rules
Anchor according to the owning screen. Keep at least 24 px from adjacent controls and 32 px inside safe area. Pivot center. Unity text and values are child UI objects, not part of the sprite.

## Visual Description
compact result stat row frame with no text, no numbers, and a subtle highlight variant. Chipped stone, bone/parchment detail, thick ink outline, scuffed texture, and no baked labels.

## States and Variants
- `default`: default state or variant
- `highlight`: highlight state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 700x64 px. Padding between cells: 16 px. Pivot: center. Target output filename: `ui_result_stat_row_portrait_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_result_stat_row` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: compact result stat row frame with no text, no numbers, and a subtle highlight variant. Intended use: Game Over. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: clean UI sprite or sheet with transparent outside edges and no baked labels. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

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
