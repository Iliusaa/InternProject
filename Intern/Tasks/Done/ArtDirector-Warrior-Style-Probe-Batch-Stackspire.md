# ArtDirector Handoff - Warrior Style Probe Batch For Stackspire

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-20
Priority: Style exploration / future reusable asset-generation skill seed
Deadline: 1 ArtDirector session

## Goal

Generate a batch of 5 original Warrior-class sprite style probes for Stackspire.

These are not final MVP replacements yet. They are exploration sprites intended to test different possible art-style directions for the Warrior class while staying inside Stackspire's approved dark-fantasy mobile-readability rules.

Each generated sprite must have its own definitive prompt attached, so the final sprite + prompt pair can later be used as a reference foundation for a reusable asset-generation skill for future Stackspire characters, enemies, props, VFX, and UI icons.

## Required Project References

Before generating, read and use:

- `GDD.md`
- `Docs/Visual-Design.md`
- `Docs/AssetSpecs/00_style_guide.md`
- `Docs/AssetSpecs/00_dimensions_and_naming.md`
- `Docs/AssetSpecs/assets/characters/player_warrior.md`
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`
- Existing generated player sprites:
  - `Assets/Generated/MVP/characters/player_warrior.png`
  - `Assets/Generated/MVP/characters/player_archer.png`
  - `Assets/Generated/MVP/characters/player_mage.png`
- Existing style atlases where available:
  - `Assets/Generated/MVP/_source_atlases/atlas_characters.png`
  - `Assets/Generated/MVP/_source_atlases/atlas_enemies.png`
  - `Assets/Generated/MVP/_source_atlases/atlas_projectiles_vfx.png`
  - `Assets/Generated/MVP/_source_atlases/atlas_ui_icons.png`

## Mandatory Flux Style Anchor

Use this exact ArtDirector Memory / Flux prompt fragment as the primary style anchor for every Warrior generation:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents;

This line is mandatory because `Docs/Visual-Design.md` describes the intended mood but is not explicit enough for reliable sprite generation. Treat this Flux-proven fragment as the strongest style instruction, and use the docs only as supporting reference.

Every generated Warrior prompt must include this fragment verbatim as the first sentence of the positive prompt.

## Darkest Dungeon Inspiration Guardrail

Use Darkest Dungeon only as broad inspiration for mood and visual language: gothic dark-fantasy pressure, thick ink, angular shadows, hand-painted grit, harsh silhouettes, oppressive contrast, candlelit warmth, distressed texture, and readable combat poses.

Do not copy Darkest Dungeon characters, armor designs, faces, UI motifs, symbols, composition, exact proportions, logos, monsters, proprietary shapes, or recognizable brushwork. The output must remain original Stackspire art.

## Shared Warrior Requirements For All 5 Sprites

Every prompt must begin with this proven Stackspire style anchor:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents;

Each sprite must show the same gameplay identity:

- Subject: Warrior class player avatar.
- One object only: one full-body Warrior character, no enemies, no UI, no background scene, no slash VFX.
- Perspective: fixed 2D three-quarter top-down.
- Pose: idle/combat-ready, sword-first silhouette.
- Character traits: tiny vulnerable doll-like adventurer, oversized head, anxious expression, compact body, oversized chipped sword, dark dried-crimson cape or cloth accent.
- Mood: grim, strange, absurd, oppressive, candlelit, readable.
- Output: PNG/RGBA with transparent background.
- Source canvas: 512x512 minimum.
- Final gameplay readability target: must still read at 128x128 and 64x64.
- Pivot intent: bottom-center feet point.
- Keep generous transparent padding around the character.
- Avoid bright damage red except tiny non-dominant accents if absolutely necessary.
- No readable text, numbers, watermark, logo, or baked UI.
- Do not overwrite `player_warrior.png`.
- Save under:
  - `Assets/Generated/StyleProbes/warrior/`

## Shared Stackspire Palette

Use the approved Stackspire palette:

- Ink / void: `#0E0B10`, `#17131A`, `#262129`
- Dungeon stone: `#343038`, `#4B4447`, `#6D6461`
- Warrior dark crimson: `#6E151D`, `#9E2527`
- Damage red: `#D64A32`, reserved only for damage and urgent feedback
- Torch / coin gold: `#8F5A24`, `#C18432`, `#E0B75C`
- Bone / parchment: `#B8A487`, `#D6C6A1`
- Optional sickly accent: `#35533B`, `#587642`, `#8A9B55`
- Optional occult shadow accent: `#26364F`, `#415C78`, `#7B6A9B`
- Do not use `#00FF00` in final visuals.

## Required Output Files

Create exactly these 5 sprite files:

1. `warrior_style_probe_01_gothic_ink.png`
2. `warrior_style_probe_02_painterly_candlelit.png`
3. `warrior_style_probe_03_etched_woodcut.png`
4. `warrior_style_probe_04_mobile_grotesque.png`
5. `warrior_style_probe_05_brutal_comic_silhouette.png`

For each sprite, create a matching prompt file:

1. `warrior_style_probe_01_gothic_ink.prompt.md`
2. `warrior_style_probe_02_painterly_candlelit.prompt.md`
3. `warrior_style_probe_03_etched_woodcut.prompt.md`
4. `warrior_style_probe_04_mobile_grotesque.prompt.md`
5. `warrior_style_probe_05_brutal_comic_silhouette.prompt.md`

Each `.prompt.md` must include:

- The exact final generation prompt used.
- The exact negative prompt used.
- Any generation settings, seed, model, or sampler information if the tool provides them.
- A short note explaining what style direction the sprite explores.
- A short note on whether the style is suitable for future characters, enemies, props, UI icons, or all asset types.

## Prompt 01 - Gothic Ink Baseline

Filename: `warrior_style_probe_01_gothic_ink.png`

Prompt:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only, transparent background. The Warrior is a tiny vulnerable doll-like adventurer with an oversized head, anxious eyes, compact body, dark dried-crimson cape, battered leather-and-iron armor, and an oversized chipped sword held forward so the sword silhouette reads before costume detail. Explore a gothic ink baseline direction inspired only by broad dark-fantasy dungeon mood: heavy uneven black ink outlines, angular black shadow shapes, distressed hand-painted texture, candlelit bone highlights, grim oppressive contrast, scuffed dungeon grime, original design. Use Stackspire palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, torch gold #8F5A24 #C18432 #E0B75C, bone parchment #B8A487 #D6C6A1. Keep bright damage red #D64A32 out of the costume except for no more than a tiny dull nick if needed. Centered 512x512 source canvas, generous transparent padding, bottom-center feet pivot, readable at 128x128 and 64x64, strong grayscale silhouette, no background scene, no text, no numbers, no watermark, no copied game character, no copied armor design, no proprietary symbols.

Negative prompt:

photorealistic, 3D render, anime clean lineart, glossy heroic fantasy, thin vector outline, realistic proportions, adult realistic anatomy, bright clean armor, colorful cheerful palette, noisy background, full scene, multiple characters, slash VFX, readable text, numbers, watermark, logo, extra limbs, malformed hands, deformed face, low quality, blurry, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied Darkest Dungeon character, copied UI symbols, copied proprietary designs.

## Prompt 02 - Painterly Candlelit

Filename: `warrior_style_probe_02_painterly_candlelit.png`

Prompt:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only, transparent background. The Warrior is a tiny fragile tower-climber with oversized head, worried expression, short compact body, oversized chipped sword, dark dried-crimson cloak, patched armor plates, and scuffed boots visible for bottom-center pivot. Explore a painterly candlelit direction: thick uneven black outline remains dominant, but interior forms use rough hand-painted value blocks, smoky shadow gradients, warm torch-gold rim light on sword edges, parchment highlights on face and knuckles, dirty stone-gray armor, and dried crimson fabric. The mood should feel grim, intimate, candlelit, oppressive, and original, with broad dark-fantasy inspiration only and no recognizable reference-game elements. Use Stackspire palette: #0E0B10 #17131A #262129 for ink and deepest shadow, #343038 #4B4447 #6D6461 for armor/stone neutrals, #6E151D #9E2527 for Warrior identity, #8F5A24 #C18432 #E0B75C for candle highlights, #B8A487 #D6C6A1 for bone/parchment highlights. Centered 512x512 source canvas, transparent PNG/RGBA, generous padding, mobile-readable at 64x64, strong grayscale sword-first silhouette, no text, no watermark, no background, no copied characters or proprietary designs.

Negative prompt:

photorealistic, 3D render, smooth plastic digital painting, clean heroic fantasy, over-detailed armor, realistic anatomy, tall adult warrior, thin outline, vector icon, bright saturated red costume, cluttered background, multiple objects, enemies, slash trail, readable text, numbers, watermark, logo, extra limbs, broken sword anatomy, deformed, blurry, low quality, realistic gore, body horror, dismemberment, exposed organs, copied game characters, copied Darkest Dungeon character, copied UI symbols, proprietary designs.

## Prompt 03 - Etched Woodcut

Filename: `warrior_style_probe_03_etched_woodcut.png`

Prompt:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only, transparent background. The Warrior is a tiny anxious adventurer with oversized head, compact doll-like body, hunched shoulders, oversized chipped sword, ragged dried-crimson half-cape, dented helmet or shoulder guard, and boots placed clearly for bottom-center pivot. Explore an etched woodcut / scratch-ink direction: thick black silhouette, uneven ink contour, visible scratch hatching, carved shadow marks, parchment-colored worn highlights, dirty stone-gray midtones, and minimal controlled color. The sprite should feel like a grim dungeon illustration adapted for mobile readability, with gothic dark-fantasy inspiration only, fully original Stackspire design. Use Stackspire palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, torch gold #8F5A24 #C18432 #E0B75C used sparingly, bone parchment #B8A487 #D6C6A1 for etched highlights. 512x512 transparent PNG/RGBA, centered with generous padding, strong sword-first silhouette, readable at 128x128 and 64x64, no background scene, no text, no numbers, no watermark, no copied game character, no proprietary symbols.

Negative prompt:

photorealistic, 3D render, smooth airbrush, glossy fantasy armor, clean anime, colorful cartoon, thin vector lines, realistic tall warrior, high-detail background, multiple characters, enemy, projectile, slash VFX, readable text, numbers, watermark, logo, extra limbs, deformed anatomy, blurry, noisy, low quality, realistic gore, body horror, dismemberment, exposed organs, lingering gore, copied Darkest Dungeon character, copied game characters, copied UI symbols, proprietary designs.

## Prompt 04 - Mobile Grotesque Readability

Filename: `warrior_style_probe_04_mobile_grotesque.png`

Prompt:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only, transparent background. The Warrior is a tiny vulnerable grotesque mobile-readable hero with very oversized head, anxious round eyes, small compact torso, oversized chipped sword nearly as tall as the character, dark dried-crimson cape, simple battered armor shapes, and exaggerated boots for a clear bottom-center pivot. Explore a mobile grotesque direction: bolder simplified shapes, fewer interior details, thick uneven black outline, chunky scuffed texture, high-contrast face and weapon, dark funny-sad dungeon mood, strange but readable silhouette, original Stackspire character language. Keep it inspired by gothic dungeon cartoon mood and high-contrast dark fantasy, but not by copying any existing game character. Use Stackspire palette: #0E0B10 #17131A #262129 for outlines and shadows, #343038 #4B4447 #6D6461 for armor neutrals, #6E151D #9E2527 for Warrior cape, #8F5A24 #C18432 #E0B75C for tiny sword/torch highlights, #B8A487 #D6C6A1 for face and bone highlights. 512x512 source, transparent PNG/RGBA, centered, generous padding, readable at 64x64, grayscale-distinguishable, no background, no text, no numbers, no watermark, no proprietary designs.

Negative prompt:

photorealistic, 3D render, realistic anatomy, tall heroic knight, clean cute mascot, bright cheerful cartoon, thin outline, vector flat icon, over-detailed armor, unreadable tiny weapon, cluttered background, multiple objects, enemies, slash effects, readable text, numbers, watermark, logo, extra limbs, malformed face, deformed, blurry, low quality, realistic gore, body horror, dismemberment, copied game character, copied Darkest Dungeon character, copied UI symbols, proprietary designs.

## Prompt 05 - Brutal Comic Silhouette

Filename: `warrior_style_probe_05_brutal_comic_silhouette.png`

Prompt:

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only, transparent background. The Warrior is a tiny anxious tower-climber with oversized head, compact body, ragged dark dried-crimson cloak, dented armor, and a massive broken sword held diagonally across the body to create a brutal readable silhouette. Explore a brutal comic silhouette direction: extreme black shape design, jagged cloak edge, angular sword, thick uneven ink outline, harsh shadow chunks, scuffed painterly grime, limited dark palette, small warm torch-gold highlights, bone-parchment face accents, grim absurd dungeon tone. The design should feel original to Stackspire while taking only broad inspiration from gothic high-contrast dark-fantasy illustration. Use Stackspire palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, torch gold #8F5A24 #C18432 #E0B75C, bone parchment #B8A487 #D6C6A1. 512x512 transparent PNG/RGBA, centered, generous padding, bottom-center feet pivot, no background scene, no slash VFX, readable at 128x128 and 64x64, strong grayscale silhouette, no text, no numbers, no watermark, no copied characters or proprietary designs.

Negative prompt:

photorealistic, 3D render, clean superhero comic, glossy armor, realistic knight, tall adult proportions, thin outline, vector art, bright saturated damage red costume, cluttered scene, multiple characters, monsters, UI frame, attack trail, readable text, numbers, watermark, logo, extra limbs, deformed anatomy, blurry, low quality, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied Darkest Dungeon character, copied game characters, copied UI symbols, proprietary designs.

## Review Deliverable

After generating the 5 sprites and 5 prompt files, create:

`Assets/Generated/StyleProbes/warrior/warrior_style_probe_review.md`

The review file must include:

1. A thumbnail/contact-sheet reference or paths to the 5 sprites.
2. A short comparison of the 5 style directions.
3. Which style is strongest for Stackspire's future asset generation and why.
4. Which style is most readable at 64x64.
5. Which style best supports reuse across:
   - player classes
   - enemies
   - projectiles/VFX
   - world props
   - UI icons
6. Any risks, such as too much detail, weak silhouette, too much similarity to external references, or poor grayscale readability.

## Reusable Skill Seed Deliverable

Also create:

`Assets/Generated/StyleProbes/warrior/stackspire_asset_generation_skill_seed.md`

This is not a packaged skill yet. It is a seed document that can later become a reusable asset-generation skill.

Include:

- Recommended style direction, using the generated sprite filename as the visual anchor.
- Core invariant rules:
  - perspective
  - outline weight
  - proportions
  - texture density
  - palette
  - background treatment
  - mobile readability rules
  - gore limits
  - IP/reference guardrails
- Mandatory style anchor for future asset skill:
  - Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette.
- Class/asset-specific adaptation rule:
  - For Warrior: Warrior uses oversized sword and dark dried-crimson accents;
  - For Archer: Archer uses oversized bow, nervous posture, and muted hunter-green or dark leather accents.
  - For Mage: Mage uses oversized staff, anxious occult silhouette, and muted violet-blue shadow accents.
  - For Enemy: Enemy uses grotesque readable threat silhouette, exaggerated head or limb shape, and sickly dungeon accent colors.
  - For UI icon: UI icon keeps the same thick black ink outline, scuffed painterly texture, grim Stackspire palette, and high-contrast readable silhouette.
- A reusable prompt formula with slots:
  - `[asset_id]`
  - `[asset_category]`
  - `[subject]`
  - `[silhouette priority]`
  - `[class/enemy/world/UI role]`
  - `[palette accents]`
  - `[output size]`
  - `[background rule]`
- A reusable negative prompt.
- 3 example adaptation prompts:
  - one for Archer
  - one for an enemy
  - one for a UI icon
- Do not package the skill yet unless PM explicitly requests it later.

## Completion Rules

- This is style exploration only, not MVP replacement work.
- Do not overwrite `Assets/Generated/MVP/characters/player_warrior.png`.
- Do not modify Unity scenes, prefabs, scripts, import settings, or gameplay references.
- Do not create a QA handoff, Coder handoff, MVP integration handoff, or packaged skill unless PM explicitly requests it later.
- When finished, record what was generated and move this task to `Tasks/Done/`.

## Acceptance Criteria

- Exactly 5 Warrior style-probe PNGs are generated.
- Exactly 5 matching `.prompt.md` files are generated.
- Existing `player_warrior.png` is not overwritten.
- Each sprite contains one full-body Warrior only.
- Each sprite has transparent background.
- Each sprite is readable at 64x64.
- Each sprite follows Stackspire's dark-fantasy mobile style and approved palette.
- Each sprite starts from the mandatory Flux style anchor.
- Darkest Dungeon is used only as broad mood/readability inspiration; no copied characters, UI, symbols, logos, monsters, or proprietary designs.
- The review file and skill seed file are created.
- No QA handoff or MVP integration is created unless PM explicitly requests it.

## Completion Report - 2026-05-20

Generated under `Assets/Generated/StyleProbes/warrior/`:

- `warrior_style_probe_01_gothic_ink.png`
- `warrior_style_probe_02_painterly_candlelit.png`
- `warrior_style_probe_03_etched_woodcut.png`
- `warrior_style_probe_04_mobile_grotesque.png`
- `warrior_style_probe_05_brutal_comic_silhouette.png`
- Matching `.prompt.md` files for all five sprites.
- `warrior_style_probe_review.md`
- `stackspire_asset_generation_skill_seed.md`

Generation notes:

- Used built-in `image_gen` with raw chroma-key sources and local RGBA matte cleanup.
- Final PNGs are 1254 x 1254 with transparent corners and no visible sampled pure-green chroma residue.
- Existing `Assets/Generated/MVP/characters/player_warrior.png` was not modified.
- No Unity scene, prefab, script, import-setting, QA, Coder, or MVP integration handoff was created.
