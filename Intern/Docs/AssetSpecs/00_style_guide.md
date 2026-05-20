# Stackspire Asset Style Guide

## Source Of Truth

Use `GDD.md`, `Docs/UIUX_MVP_SPEC.md`, and `Docs/Visual-Design.md` as the active source of truth for Stackspire MVP art and UI assets. `Agents/ArtDirector.md` and `Agents/ArtDirector-Memory.md` define generation and style consistency rules.

## Art Direction

Stackspire uses original 2D dark fantasy mobile game art for Android portrait phones. The game is a casual roguelite tower climber with fixed 2D three-quarter top-down room readability. The mood is grim, strange, absurd, candlelit, oppressive, and readable.

Core traits:
- Grotesque hand-drawn proportions.
- Thick uneven black ink outlines.
- Scuffed painterly dungeon texture.
- Tiny vulnerable heroes with oversized class weapons.
- Warped enemy silhouettes readable in grayscale.
- Low-detail central combat lane so projectiles, exits, coins, hearts, and danger remain readable.
- Tall portrait composition with top HUD space, bottom control space, and an unobstructed center lane.

## Palette

| Role | Hex | Usage |
|---|---|---|
| Ink / void | `#0E0B10`, `#17131A`, `#262129` | outlines, deepest shadows, corner vignettes |
| Dungeon stone | `#343038`, `#4B4447`, `#6D6461` | floors, walls, neutral panels |
| Warrior dark crimson | `#6E151D`, `#9E2527` | Warrior identity and dried-crimson accents |
| Damage red | `#D64A32` | damage, danger, urgent feedback, hit particles only |
| Torch / coin gold | `#8F5A24`, `#C18432`, `#E0B75C` | coins, torches, unlocked doors, rewards, primary CTA accents |
| Archer sickly green | `#35533B`, `#587642`, `#8A9B55` | Archer identity and sickly accents |
| Mage occult blue-violet | `#26364F`, `#415C78`, `#7B6A9B` | Mage identity, magic, rare highlights |
| Bone / parchment | `#B8A487`, `#D6C6A1` | highlights, icon details, readable UI text fields |
| Chroma key green | `#00FF00` | raw generated sprite backgrounds only; forbidden in final visuals |

## Readability Rules

- Every important icon or sprite must still read at 64x64 px on a phone screen.
- Shape and silhouette must communicate role before color.
- Player and enemies must remain distinguishable in grayscale.
- Bright damage red is reserved for damage, danger, urgent feedback, and hit particles.
- Warrior uses dark dried-crimson, not bright damage red.
- Backgrounds stay lower-saturation and lower-detail near the combat plane.
- Tall screen backgrounds must leave usable negative space for the top HUD and lower thumb controls.

## Text Rules

Reusable art must not contain baked dynamic text, labels, prices, scores, coin values, health values, room numbers, killed-by strings, or button labels. Unity UI must render text such as Start Run, Buy, Score, Coins, Pause, Restart, Upgrades, Main Menu, Room, High Score, and numeric values.

## Background Rules

- Reusable sprites, icons, UI frames, projectiles, VFX, characters, enemies, and props target PNG/RGBA with transparent background.
- Full-screen backgrounds target opaque 1080x1920 PNG unless the asset is an overlay.
- `screen_pause_dim_overlay`, damage edge flash, and similar overlays use RGBA transparency at 1080x1920.
- `#00FF00` is allowed only for raw chroma-key generation sources and must be removed before final Unity import.

## Gore Limit

MVP gore ceiling is brief stylized blood or hit particles only. Do not generate realistic wounds, body horror, dismemberment, exposed organs, lingering gore piles, or realistic gore stains.

## Base Negative Prompt

`photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs`

## Generation Prompt Rules

Every prompt must be self-contained and include:
- Stackspire game name or intended use.
- Original 2D dark fantasy mobile game art.
- Three-quarter top-down perspective where relevant.
- Tall portrait phone composition for screens, overlays, and room backgrounds.
- Thick uneven black ink outlines.
- Scuffed painterly dungeon texture.
- Mobile-readable silhouette.
- Relevant palette colors with hex values.
- Transparent, semi-transparent, or opaque background rule.
- No readable text, no numbers, no watermark.
- Do not copy existing game characters, UI symbols, logos, or proprietary designs.