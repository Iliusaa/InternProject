---
asset_id: screen_game_over_background
category: screen_background
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

# Asset: screen_game_over_background

## Purpose
Game Over background.

## Gameplay or UI Context
Full-screen Game Over visual backing. Unity UI supplies all titles, buttons, values, and labels.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| normal | 1920 | 1080 | Full-screen reference canvas. | Docs/UIUX_MVP_SPEC.md |
| new_high_score | 1920 | 1080 | Full-screen reference canvas. | Docs/UIUX_MVP_SPEC.md |
| low_score_with_coins | 1920 | 1080 | Full-screen reference canvas. | Docs/UIUX_MVP_SPEC.md |
| zero_coins_earned | 1920 | 1080 | Full-screen reference canvas. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Stretch to the full 1080x1920 portrait reference canvas. Keep safe-area UI zones clear and avoid high-contrast clutter behind text or controls.

## Visual Description
dark final-room stone backdrop with open upper/middle result panel and lower action stack and somber edge shadows. Thick ink outlines, scuffed painterly dungeon texture, dark fantasy palette, no baked UI text, no logos.

## States and Variants
- `normal`: normal state or variant
- `new_high_score`: new_high_score state or variant
- `low_score_with_coins`: low_score_with_coins state or variant
- `zero_coins_earned`: zero_coins_earned state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with opaque background. Use one horizontal state sheet. Cell size: 1080x1920 px. Padding between cells: 16 px. Pivot: center. Target output filename: `screen_game_over_background_portrait_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `screen_game_over_background` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: dark final-room stone backdrop with open upper/middle result panel and lower action stack and somber edge shadows. Intended use: Game Over. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: opaque full-screen game background; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: full-screen portrait phone composition with UI-safe negative space and no baked labels. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

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
