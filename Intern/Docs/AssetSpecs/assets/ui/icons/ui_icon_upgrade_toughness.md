---
asset_id: ui_icon_upgrade_toughness
category: ui_icon
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
  - Upgrade Menu
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_icon_upgrade_toughness

## Purpose
Toughness upgrade icon.

## Gameplay or UI Context
Used as a reusable UI icon on Upgrade Menu. It must communicate meaning at small size without relying on text.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 64 | 64 | Icon source size. | inferred_from_layout |
| upgrade_row_display | 56 | 56 | Display size inside portrait upgrade rows. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Pivot center. Place inside owning button, chip, card, row, or HUD container with at least 8 px internal gap from Unity text.

## Visual Description
sturdy heart and shield motif, no text. Thick black outline, high value contrast, scuffed texture, and clean silhouette. Keep icon simple enough to read at 56-64 px.

## States and Variants
- `default`: single icon state
- `disabled_tint_source`: same icon must tolerate Unity disabled tint

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Canvas size: 64x64 px unless the generation tool requires a larger clean source. Pivot: center. Target output filename: `ui_icon_upgrade_toughness.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_icon_upgrade_toughness` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: sturdy heart and shield motif, no text. Intended use: Upgrade Menu. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: centered icon with transparent padding and no text. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, thin line icon, modern flat vector-only style

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Silhouette is readable at mobile scale.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers unless this file explicitly allows it.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent, semi-transparent, opaque, or chroma-key background rule is followed.
