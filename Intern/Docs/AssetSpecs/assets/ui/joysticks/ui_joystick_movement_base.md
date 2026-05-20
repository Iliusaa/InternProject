---
asset_id: ui_joystick_movement_base
category: ui_joystick
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

# Asset: ui_joystick_movement_base

## Purpose
Left movement joystick base art.

## Gameplay or UI Context
Dual-stick Android HUD control art. Left stick moves, right stick aims and autofires while held.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| idle_base | 240 | 240 | Joystick state cell size. | Docs/UIUX_MVP_SPEC.md |
| active_base | 240 | 240 | Joystick state cell size. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Anchor bottom-left, center x 235 y 245 inside safe area. Active touch zone is 340x340. Pivot center.

## Visual Description
large translucent chipped stone movement joystick ring with subtle arrow notches. Translucent stone, thick ink rim, scuffed center, no labels, and opacity-compatible for idle/active states.

## States and Variants
- `idle_base`: idle_base state or variant
- `active_base`: active_base state or variant

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 240x240 px. Padding between cells: 16 px. Pivot: center. Target output filename: `ui_joystick_movement_base_portrait_sheet.png`. Readability: must remain readable at 64x64 px on a phone screen. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_joystick_movement_base` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: large translucent chipped stone movement joystick ring with subtle arrow notches. Intended use: Game HUD. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: state sheet with transparent background, no text, readable thumb-zone shape. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs. Do not bake labels such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrade, Room, prices, scores, health values, or room numbers into the sprite; all labels and numbers must remain Unity UI text.

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
