# ArtDirector Handoff - Create Stackspire Fullscreen Concepts

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-30
Priority: High - Visual Direction Correction
Deadline: 1 ArtDirector session

## Context

The previous generated class-selection and room concepts were rejected because they did not fit the Stackspire project style. PM deleted those rejected PNGs from the project asset folders and from the recent `.codex/generated_images` batch.

This task replaces that rejected pass with a focused Stackspire fullscreen concept pass.

## Goal

Create four new fullscreen Stackspire concept images:

- Two images for the class selection menu.
- Two images for in-game rooms.

These are style concepts and screen backgrounds, not isolated sprites.

## Required References

Before generation, read or view:

- `GDD.md`
- `Docs/Visual-Design.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/AssetSpecs/00_style_guide.md`
- `Docs/AssetSpecs/assets/screens/screen_class_select_background.md`
- `Docs/AssetSpecs/assets/screens/screen_game_hud_room_background.md`
- `Docs/AssetSpecs/assets/world/rooms/world_room_template_stone_chamber.md`
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`
- `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`
- `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`

## Style Direction

Use the approved Stackspire Probe04 direction:

- Grotesque dark fantasy cartoon.
- Thick uneven black ink outlines.
- Scuffed painterly texture.
- Grim mobile readability.
- Dark dungeon palette with torch-gold lighting, dungeon stone, dried crimson, bone/parchment, sickly green, and muted occult violet-blue accents.
- Avoid clean heroic fantasy, realistic 3D, generic polished fantasy, sci-fi, neon cyberpunk, and copied reference-game designs.

## Deliverables

Create and save four PNGs under `Assets/Generated/MVP/screens/`:

- `screen_class_select_concept_stackspire_01.png`
- `screen_class_select_concept_stackspire_02.png`
- `screen_room_concept_stackspire_01.png`
- `screen_room_concept_stackspire_02.png`

For each PNG, create a matching `.prompt.md` file with the final positive prompt, negative prompt, generation settings if available, and a short note describing intended use.

## Class Selection Concept Requirements

Each class-selection image must:

- Be fullscreen.
- Fit Stackspire's current dark fantasy mobile MVP.
- Suggest Warrior, Archer, and Mage class identities through environment, props, silhouettes of weapons, cards, banners, shrines, or class stations.
- Leave room for later UI overlay, but include no baked UI components unless they are purely background staging and not readable as an interface.
- Contain no readable text, labels, class names, numbers, logos, watermarks, cursors, or HUD.
- Avoid characters, enemies, and character portraits unless ArtDirector has a strong reason and keeps them as non-playable background iconography only.

## In-Game Room Concept Requirements

Each in-game room image must:

- Be fullscreen.
- Show a Stackspire dungeon room suitable as a game screen/background.
- Contain room layout and environmental objects only.
- Include no HUD elements, no UI overlays, no characters, no enemies, no readable text, no numbers, no cursor, no watermark.
- Prefer second-plan/background objects that reinforce Stackspire style, especially wall torches, candles, chains, rubble, cracked stone, banners, doors, floor markings, alcoves, or props.
- Keep second-plan props readable but not so dominant that they block gameplay space.
- Maintain clear walkable/combat space in the center.

## Negative Prompt Baseline

Use or adapt this negative prompt:

```text
photorealistic, realistic 3D render, generic fantasy castle, clean heroic fantasy, sci-fi, cyberpunk, neon UI, cute mascot style, thin outlines, smooth vector art, glossy mobile ad art, ornate royal filigree, readable text, letters, numbers, logos, watermark, HUD, health bars, buttons, cursor, character portraits, playable characters, enemies, monsters, NPCs, dialogue boxes, copied Darkest Dungeon artwork, copied external game UI, proprietary symbols, cluttered unreadable room
```

## Acceptance Criteria

- Four fullscreen PNG concepts exist under `Assets/Generated/MVP/screens/`.
- Four matching `.prompt.md` files exist beside the PNGs.
- All four images follow approved Stackspire Probe04 visual direction.
- Class-selection concepts read as Stackspire class-selection backgrounds without text or UI.
- Room concepts show object-rich Stackspire rooms without HUD, characters, or enemies.
- At least one room concept includes second-plan torch or candle lighting.
- No generated image from the rejected 2026-05-30 pass is reused.
