---
asset_id: ui_button_tertiary_stone
category: ui_button
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
  - Pause Overlay
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_button_tertiary_stone

## Purpose
Tertiary low-emphasis action button art for Main Menu or navigation choices.

## Gameplay or UI Context
Used as reusable Unity UI button sprite art. Unity text supplies all labels.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 560 | 76 | State cell size. | Docs/UIUX_MVP_SPEC.md |
| pressed | 560 | 76 | State cell size. | Docs/UIUX_MVP_SPEC.md |
| disabled | 560 | 76 | State cell size. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Anchor according to the owning screen. Keep at least 24 px from adjacent controls and 32 px inside safe area. Pivot center. Unity text and values are child UI objects, not part of the sprite.

## Visual Description
compact dark stone button with muted bone rim and subtle shadow. Chipped fantasy stone UI with thick outline, scuffed fill, and tactile raised/pressed/disabled treatment.

## States and Variants
- `default`: default state or variant
- `pressed`: pressed state or variant
- `disabled`: disabled state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 560x76 px. Padding between cells: 16 px. Pivot: center. Target output filename: `ui_button_tertiary_stone_portrait_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_button_tertiary_stone` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: compact dark stone button with muted bone rim and subtle shadow. Intended use: Game Over, Pause Overlay. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: one horizontal state sheet, consistent silhouette and padding across states. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

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
