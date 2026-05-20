# ArtDirector Handoff - Stackspire UI/UX Style Concept Image

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-15
Deadline: 1 ArtDirector session

## Task
Create one polished concept image that shows Stackspire's approved current art style with core UI/UX elements visible.

## Chosen Agent
[[ArtDirector]]

## Routing Reason
The requested output is a generated visual image. `Docs/UIUX_MVP_SPEC.md` already defines layout and controls, while `GDD.md` defines the approved art style. ArtDirector owns visual generation and the FLUX art pipeline.

## Inputs
- `GDD.md` - approved art style, palette, gore ceiling, and reference guardrails
- `Docs/Visual-Design.md` - required visual reference for the current MVP visual direction
- `Docs/UIUX_MVP_SPEC.md` - HUD and screen layout rules
- `Tasks/Open/UIUX_Art_Asset_Request.md` - current UI asset style direction
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`

## Required Image
Create a single 1920 x 1080 PNG style target for the **Game HUD** screen.

The image should include:
- Three-quarter top-down dark fantasy dungeon room.
- Small readable player character in the approved style.
- At least one enemy silhouette.
- North exit indicator.
- Top-left heart HUD.
- Top-center score/room HUD treatment.
- Top-right coin/pause HUD treatment.
- Bottom-left movement joystick.
- Bottom-right aim/attack joystick.
- Torch/coin gold, dungeon stone, Warrior dark crimson, Archer sickly green, Mage occult blue-violet, and bright damage red used according to the GDD rules.

## Style Requirements
- Original 2D dark fantasy dungeon cartoon.
- Three-quarter top-down perspective with original Stackspire characters, enemies, icons, UI, and room props.
- Dark fantasy palette inspired by *Darkest Dungeon* contrast: heavy shadows, candle amber, dark crimson, sickly green, occult blue-violet, bone/parchment highlights.
- Thick ink outlines and mobile-readable silhouettes.
- Maximum gore: brief stylized blood particles only on hit feedback.
- Bright red reserved for damage, danger, urgent UI, and hit particles.
- Warrior accents use darker crimson, not bright damage red.

## Constraints
- Do not copy exact characters, enemies, UI, logos, symbols, or proprietary designs from reference games.
- No realistic gore, body horror, dismemberment, exposed organs, or lingering gore piles.
- No text baked into reusable UI art. If the concept needs score/room/coin placeholders, use simple abstract bars, icon slots, or unreadable placeholder marks instead of readable words.
- Save output under `Assets/Generated/`, preferably `Assets/Generated/UI/` if that folder exists or is created.

## Acceptance Criteria
- Image is saved as a PNG under `Assets/Generated/`.
- Image reads clearly at 1920 x 1080 and when scaled down to mobile preview size.
- UI/UX elements match the positions defined in `Docs/UIUX_MVP_SPEC.md`.
- Style matches the approved `GDD.md` art direction.
- Player, enemy, north exit, hearts, coins, pause, and both joysticks are visually identifiable without relying only on color.
- No direct copying from reference games.
