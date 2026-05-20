---
asset_id: ui_upgrade_row_global
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
  - Upgrade Menu
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_upgrade_row_global

## Purpose
Reusable row art for Toughness, Power, Agility, and Greed.

## Gameplay or UI Context
Communicates upgrade affordability, current level, next effect, cost, and Buy state while Unity supplies all labels and numbers.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 968 | 132 | Upgrade row state cell. | Docs/UIUX_MVP_SPEC.md |
| affordable | 968 | 132 | Upgrade row state cell. | Docs/UIUX_MVP_SPEC.md |
| insufficient_coins | 968 | 132 | Upgrade row state cell. | Docs/UIUX_MVP_SPEC.md |
| maxed | 968 | 132 | Upgrade row state cell. | Docs/UIUX_MVP_SPEC.md |
| bought | 968 | 132 | Upgrade row state cell. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Rows live inside the Upgrade Menu vertical ScrollRect at x 56-1024, width 968 px. Pivot center. Icon, labels, cost, and button are Unity children layered above this background sprite.

## Visual Description
Long dense stone row with icon socket, separators, cost socket, and buy-button socket. Affordable adds gold highlight; insufficient mutes button area; maxed and bought use badge sockets and shape changes.

## States and Variants
- `default`: default state or variant
- `affordable`: affordable state or variant
- `insufficient_coins`: insufficient_coins state or variant
- `maxed`: maxed state or variant
- `bought`: bought state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 968x132 px. Padding between cells: 16 px. Pivot: center. Target output filename: `ui_upgrade_row_global_portrait_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_upgrade_row_global` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: portrait upgrade row background with icon socket, cost socket, and button socket. Intended use: Upgrade Menu. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: horizontal five-state row sheet, all states same size and aligned. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

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
