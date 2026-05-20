---
asset_id: enemy_shooter_projectile
category: projectile
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

# Asset: enemy_shooter_projectile

## Purpose
Enemy Shooter projectile sprite.

## Gameplay or UI Context
Slow hostile shot that threatens one heart of damage from anywhere in the active room.

## Pixel Dimensions
| Variant or State | Width px | Height px | Notes | Source |
|---|---:|---:|---|---|
| default | 72 | 72 | Reference-canvas projectile sprite size. | inferred_from_layout |
| generation_source | 512 | 512 | Generate on larger source if needed and crop to final transparent sprite. | Agents/ArtDirector.md |

## Placement and Anchor Rules
Pivot center. Rotate in Unity toward travel direction. Keep collider-aligned core inside the visual silhouette with transparent padding for antialiasing.

## Visual Description
sickly hostile orb or spit-bolt with jagged black outline and clear danger shape. Thick ink edge, clear travel direction, high contrast against dark stone, and no readable markings.

## States and Variants
- `default`: single projectile frame
- `impact_tint_source`: same frame must tolerate brief Unity hit tint

## Sprite Sheet or Export Plan
Export as PNG/RGBA with transparent background. Canvas size: 72x72 px unless the generation tool requires a larger clean source. Pivot: center. Target output filename: `enemy_shooter_projectile.png`. Readability: must remain readable at 64x64 px on a phone screen. No baked dynamic text or numbers.

## Generation Prompt
Create `enemy_shooter_projectile` for Stackspire as original 2D dark fantasy mobile game art, fixed 2D three-quarter top-down perspective where relevant, grotesque hand-drawn proportions, thick uneven black ink outlines, scuffed painterly dungeon texture, grim candlelit tower mood, mobile-readable silhouette. Subject: sickly hostile orb or spit-bolt with jagged black outline and clear danger shape. Intended use: Game HUD. Palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, damage red #D64A32 reserved only for damage and urgent feedback, torch and coin gold #8F5A24 #C18432 #E0B75C, Archer sickly green #35533B #587642 #8A9B55, Mage occult blue-violet #26364F #415C78 #7B6A9B, bone and parchment #B8A487 #D6C6A1. Background rule: transparent background for a reusable sprite or UI element; do not use #00FF00 in final visuals unless it is a raw removable chroma-key background that will be removed before Unity import. Composition and readability: horizontal or radial projectile with clear forward direction and clean transparent padding. no readable text, no numbers, no watermark, do not copy existing game characters, UI symbols, logos, or proprietary designs.

## Negative Prompt
photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs, screen-filling explosion, unreadable glow bloom

## QA Acceptance Checklist
- [ ] Pixel dimensions are correct.
- [ ] Silhouette is readable at mobile scale.
- [ ] Style matches Stackspire dark fantasy cartoon direction.
- [ ] No baked dynamic text or numbers unless this file explicitly allows it.
- [ ] No forbidden gore.
- [ ] No copied IP or logos.
- [ ] Correct states are present.
- [ ] Correct transparent, semi-transparent, opaque, or chroma-key background rule is followed.
