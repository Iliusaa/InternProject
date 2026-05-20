# Stackspire Visual Design

Owner: [[UIUXDesigner]]
Status: MVP visual reference
Date: 2026-05-16

## Purpose

This file is the required visual reference for Stackspire art generation prompts and UI art handoffs. Use it with `GDD.md` and `Docs/UIUX_MVP_SPEC.md`.

## MVP Art Direction

- Style: original 2D dark fantasy dungeon cartoon with grotesque hand-drawn proportions, thick ink outlines, scuffed painterly texture, and vulnerable small heroes.
- Camera: three-quarter top-down for rooms, characters, enemies, projectiles, VFX, props, and screen backgrounds.
- Mood: grim, strange, absurd, candlelit, oppressive, readable.
- Silhouette rule: weapon or role shape must identify the subject before costume detail or color.
- Mobile readability: every important sprite or icon must still read at 64 x 64 px.
- Gore ceiling: brief stylized blood particles only. No realistic wounds, body horror, dismemberment, organs, or lingering gore piles.
- Reference guardrail: describe Stackspire traits directly. Do not ask generators to copy characters, UI, symbols, logos, enemies, or proprietary designs from any reference game.

## Palette

| Role | Hex | Usage |
|------|-----|-------|
| Ink / void | `#0E0B10`, `#17131A`, `#262129` | outlines, deepest shadows, corner vignettes |
| Dungeon stone | `#343038`, `#4B4447`, `#6D6461` | room floors, walls, neutral panels |
| Warrior dark crimson | `#6E151D`, `#9E2527` | Warrior identity and dried-crimson accents |
| Damage red | `#D64A32` | damage, danger, urgent feedback, hit particles only |
| Torch / coin gold | `#8F5A24`, `#C18432`, `#E0B75C` | coins, torches, unlocked doors, reward emphasis |
| Archer sickly green | `#35533B`, `#587642`, `#8A9B55` | Archer identity and poison/sickly accents |
| Mage occult blue-violet | `#26364F`, `#415C78`, `#7B6A9B` | Mage identity, magic, rare highlights |
| Bone / parchment | `#B8A487`, `#D6C6A1` | small highlights, readable UI text fields, icon details |
| Chroma key green | `#00FF00` | raw generated sprite backgrounds only; forbidden in final game visuals |

## Global Shapes

- Outlines: thick black ink, uneven and hand-drawn, never thin vector strokes.
- Texture: scuffed, scratched, dirty, but lower-detail near active gameplay space.
- Characters: oversized head, small body, anxious expression, oversized class weapon.
- Enemies: warped uneven anatomy, distinct silhouette, readable in grayscale.
- Rooms: crooked masonry, grime, candle pools, heavy corner shadows, clear south entrance and north exit.
- UI panels: stone slabs with chipped edges, dark fill, bone/parchment text, gold highlights for primary actions.

## Screen Visual Rules

| Screen | Visual Treatment |
|--------|------------------|
| Main Menu | Three-quarter top-down tower-room backdrop with title and two clear actions; no clutter around CTA stack. |
| Class Select | Three stone class cards with class silhouettes and weapon-first identity; selected state must be visible by border/icon/scale, not color alone. |
| Game HUD | Persistent UI stays on edges; center combat plane remains readable; joysticks are translucent stone rings. |
| Pause Overlay | Gameplay dimmed with 60% black; centered stone panel; Resume is visually primary. |
| Upgrade Menu | Dense but readable stone rows, coin affordability visible at a glance, disabled and maxed states distinct by label and shape. |
| Game Over | Dimmed final-room or stone backdrop, result panel centered, Restart primary, Upgrades secondary. |

## Interactive UI Asset State Bundles

Interactive UI assets must be generated as a complete state bundle in one prompt/output set whenever practical.

| Asset | Required States |
|-------|-----------------|
| Primary button | default, pressed, disabled |
| Secondary button | default, pressed, disabled |
| Icon button | default, pressed, disabled |
| Class card | default, selected, pressed, disabled |
| Upgrade row | default, affordable, insufficient coins, maxed, bought |
| Currency chip | default, updated/pulse highlight |
| Heart icon | full, empty, armor pip, damage flash |
| Door indicator | locked, unlocked, blocked feedback |
| Virtual joystick | idle base, active base, thumb, aim direction notch |
| Toast label frame | room clear, exit locked, damage warning |

## ArtDirector Prompt Requirements

Every future generation prompt should include:

- `Docs/Visual-Design.md` as visual reference.
- Three-quarter top-down perspective.
- Thick black ink outlines.
- Scuffed painterly texture.
- Palette role names and exact colors when relevant.
- No `#00FF00` except raw chroma-key sprite backgrounds.
- No text in reusable art unless the task explicitly asks for baked display text.
- For interactive UI assets: request all required states together.

## Negative Prompt

`photorealistic, 3D render, blurry, text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols`
