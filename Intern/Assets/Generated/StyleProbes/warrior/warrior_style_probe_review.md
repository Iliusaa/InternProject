# Warrior Style Probe Review

Date: 2026-05-20  
Task: `Tasks/Open/ArtDirector-Warrior-Style-Probe-Batch-Stackspire.md`

## Sprite Paths

1. `Assets/Generated/StyleProbes/warrior/warrior_style_probe_01_gothic_ink.png`
2. `Assets/Generated/StyleProbes/warrior/warrior_style_probe_02_painterly_candlelit.png`
3. `Assets/Generated/StyleProbes/warrior/warrior_style_probe_03_etched_woodcut.png`
4. `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`
5. `Assets/Generated/StyleProbes/warrior/warrior_style_probe_05_brutal_comic_silhouette.png`

## Comparison

- `01_gothic_ink`: strongest continuity with the current MVP Warrior. Clear sword-first identity, thick outline, and good grim cartoon tone.
- `02_painterly_candlelit`: warmer and more dimensional. It has strong mood, but the added painting detail can become busy at small size.
- `03_etched_woodcut`: most print-like and scratchy. The texture gives identity, but hatching increases 64x64 noise risk.
- `04_mobile_grotesque`: cleanest direction for game production. It keeps the anxious oversized-head read while simplifying shapes for mobile scale.
- `05_brutal_comic_silhouette`: strongest aggressive sword/cloak mass. It reads dramatically, but risks being too heavy and detail-dense for small UI uses.

## Strongest Future Style Direction

`warrior_style_probe_04_mobile_grotesque.png` is the strongest foundation for future Stackspire asset generation. It best matches the project's mobile-readability rule: silhouette first, expression second, costume detail last. Its simplified shape language can be adapted to classes, enemies, props, VFX, and icons without forcing every asset to carry high illustration detail.

## Most Readable At 64x64

`warrior_style_probe_04_mobile_grotesque.png` is the most readable at 64x64 because the face, oversized sword, cape mass, and boots separate with the least reliance on interior hatching.

## Reuse Across Asset Types

- Player classes: `04_mobile_grotesque` for production consistency; `01_gothic_ink` as a continuity fallback.
- Enemies: `05_brutal_comic_silhouette` and `03_etched_woodcut` are useful for threat shapes, but should be simplified.
- Projectiles/VFX: `04_mobile_grotesque` gives the best high-contrast silhouette discipline.
- World props: `01_gothic_ink` and `03_etched_woodcut` both support scuffed dungeon material language.
- UI icons: `04_mobile_grotesque` is the best fit because it favors fewer shapes and stronger value grouping.

## Risks

- All five generations remained close to the current MVP Warrior reference; the batch tests rendering emphasis more than radically different character construction.
- `02`, `03`, and `05` carry enough interior texture to blur at 64x64 unless future prompts explicitly cap detail density.
- `05` has the most dramatic silhouette, but its heavy sword and cloak could compete with enemies or boss-scale threats.
- Chroma-key generation produced slightly non-uniform green sources, so future transparent-output runs should either use true native transparency when available or include a stronger flat-key instruction and validation pass.
- No visible copied IP, logos, UI symbols, text, gore, extra characters, or background scenes were observed in the final sprites.
