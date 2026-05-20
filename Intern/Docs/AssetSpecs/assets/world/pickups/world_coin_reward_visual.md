---
asset_id: world_coin_reward_visual
category: world_pickup
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
  - Coin reward
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: world_coin_reward_visual

## Purpose
Automatic coin reward visual.

## Gameplay or UI Context
Brief coin visual appears when an enemy dies; coins are awarded automatically, not manually picked up.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 64 | 64 | Coin reward visual size. | inferred_from_layout |
| sparkle_frame | 64 | 64 | Optional sparkle-compatible frame. | inferred_from_layout |

## Placement and Anchor Rules
Spawn near defeated enemy in combat plane and move/fade quickly toward HUD coin chip if animated. Pivot center.

## Visual Description
Small torch-gold coin with thick black outline and tiny original skull/tower motif. Must read as reward at 64 px and not imply manual pickup.

## States and Variants
- `default`: default state or variant
- `sparkle_frame`: sparkle_frame state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 64x64 px. Padding between cells: 16 px. Pivot: center. Target output filename: `world_coin_reward_visual_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. No baked dynamic text or numbers.

## Generation Prompt
Create `world_coin_reward_visual` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: small gold coin reward visual with thick black outline and no text or numbers. Intended use: Game HUD, Coin reward. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: two-frame transparent sheet for coin and sparkle highlight. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs.

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
