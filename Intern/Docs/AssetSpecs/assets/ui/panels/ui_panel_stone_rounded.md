---
asset_id: ui_panel_stone_rounded
category: ui_panel
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
  - Main Menu
  - Class Select
  - Upgrade Menu
  - Pause Overlay
  - Game Over
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: ui_panel_stone_rounded

## Purpose
Reusable scalable stone panel art for portrait UI composition.

## Gameplay or UI Context
Reusable UI art or layout backing. Unity supplies dynamic text, numbers, values, buttons, and child icons.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 512 | 512 | 9-slice source cell for scalable portrait panels. | Docs/UIUX_MVP_SPEC.md |
| dimmed | 512 | 512 | Dimmed panel source cell for overlays. | Docs/UIUX_MVP_SPEC.md |

## Placement and Anchor Rules
Anchor according to the owning screen. Keep at least 24 px from adjacent controls and 32 px inside safe area. Pivot center. Use Unity 9-slice scaling for larger portrait panels such as Pause and Game Over.

## Visual Description
Scalable chipped dark stone rounded panel with clean 9-slice border and empty center. Chipped stone, bone/parchment detail, thick ink outline, scuffed texture, and no baked labels.

## States and Variants
- `default`: normal scalable panel source
- `dimmed`: darker scalable panel source for overlays

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Use one horizontal state sheet. Cell size: 512x512 px. Padding between cells: 16 px. Pivot: center. Target output filename: `ui_panel_stone_portrait_sheet.png`. Readability: must remain readable at mobile UI scale. Do not bake labels, values, prices, scores, room numbers, or killed-by strings into the sprite; all labels and numbers must remain Unity UI text.

## Generation Prompt
Create `ui_panel_stone_rounded` for Stackspire as original 2D dark fantasy mobile game UI art, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: scalable chipped dark stone rounded panel with clean 9-slice border and empty center for portrait phone UI. Intended use: Main Menu, Class Select, Upgrade Menu, Pause Overlay, Game Over. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, torch and coin gold #8F5A24 #C18432 #E0B75C, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable UI element; do not use #00FF00 in final visuals. Composition and readability: clean UI state sheet with transparent outside edges and no baked labels, no readable text, no numbers, no watermark, no copied UI symbols.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] 9-slice border can scale without distorting corners.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent background rule is followed.