---
asset_id: player_archer
category: character
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
  - Class Select
  - Game HUD
reference_resolution_px: 1080x1920
status: ready_for_generation
---

# Asset: player_archer

## Purpose
Readable player class avatar for archer.

## Gameplay or UI Context
Appears in combat rooms and class selection art. The bow and quiver silhouette communicates fast long-range kiting.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| gameplay_sprite | 128 | 128 | Reference-canvas gameplay read size; generate at 512x512 minimum for clean downscale. | inferred_from_layout |
| generation_source | 512 | 512 | Minimum square source for asset generation and Unity downscale. | Agents/ArtDirector.md |

## Placement and Anchor Rules
World sprite pivot at bottom-center feet point. Spawn near the south entrance inside the portrait combat lane, roughly x 80-1000 and y 170-1420, with the actual spawn kept above the bottom joystick visuals. Keep visual bounds inside gameplay collider and away from HUD and joystick zones.

## Visual Description
Tiny vulnerable doll-like adventurer with oversized head, anxious expression, thick black outline, scuffed texture, sickly green hood, and weapon-first silhouette: curved bow and quiver. Avoid bright damage red except external hit feedback.

## States and Variants
- `default`: single readable idle/combat-ready pose
- `damaged_flash_source`: same silhouette must tolerate a brief Unity damage tint

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Canvas size: 128x128 px unless the generation tool requires a larger clean source. Pivot: bottom-center feet point. Target output filename: `player_archer.png`. Readability: must remain readable at 64x64 px on a phone screen. No baked dynamic text or numbers.

## Generation Prompt
Create `player_archer` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: tiny vulnerable hero with curved bow and quiver, sickly green hood, oversized head, anxious expression. Intended use: Class Select, Game HUD. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: centered full-body three-quarter top-down pose with generous transparent padding and strong weapon silhouette. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, heroic clean fantasy, realistic armor shine, adult realistic proportions

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Silhouette is readable at mobile scale.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers unless this file explicitly allows it.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent, semi-transparent, opaque, or chroma-key background rule is followed.
