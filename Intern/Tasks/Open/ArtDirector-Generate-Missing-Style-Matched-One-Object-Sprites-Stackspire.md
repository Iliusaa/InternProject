# ArtDirector Handoff - Generate Missing Style-Matched One-Object Sprites

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-20
Deadline: 1 ArtDirector session

## Task

Generate missing Stackspire game sprites and save the PNG outputs under `Assets/Generated/`.

Do not generate or overwrite any asset that already exists anywhere under `Assets/Generated/`. Before generating, scan `Assets/Generated/` recursively and treat matching output filenames as already complete.

## Required References

Before generating each sprite, read and use:

- `Docs/Visual-Design.md`
- `Docs/AssetSpecs/00_manifest.md`
- `Docs/AssetSpecs/00_dimensions_and_naming.md`
- `Docs/AssetSpecs/00_style_guide.md`
- The matching individual spec file under `Docs/AssetSpecs/assets/`
- Existing sprites under `Assets/Generated/`
- Style reference atlases under `Assets/Generated/MVP/_source_atlases/`
- `GDD.md` where the individual asset spec references it
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`

Use the already generated sprites and the `_source_atlases` files as the practical style match reference for outline weight, palette, silhouette scale, texture density, mobile readability, and transparency treatment.

## Non-Negotiable Rules

- Every generated sprite must include maximum one object per sprite.
- This rule applies to every sprite category: menu sprites, wall sprites, UI components, cards, rows, panels, buttons, icons, HUD pieces, controls, doors, pickups, props, floor tiles, VFX, characters, enemies, and projectiles.
- Do not generate composed scenes, full menu screens, full room screens, atlases, or multi-object sprites.
- Generated menu assets must be individual menu components only, such as one panel, one row state, one card state, or one button state.
- Generated wall assets must be one wall segment or one tile/state per sprite.
- Do not bake readable text, numbers, prices, labels, score values, room values, or killed-by strings into sprites.
- Use PNG with transparency/RGBA for reusable sprites unless the individual spec explicitly requires otherwise and still satisfies the one-object rule.
- Follow `Docs/Visual-Design.md` and the matching `Docs/AssetSpecs/assets/` file for visual direction, dimensions, naming, states, palette, negative prompt, and QA notes.

## State Export Rule

Every object that has states must have a different sprite file for each state.

Do not export state sheets for this task, even if the asset spec names a `_sheet.png` output. Split the sheet into separate state PNG files.

Naming pattern:

- If the spec output is `asset_name_sheet.png`, export `asset_name_<state>.png`.
- If the spec output is `asset_name_portrait_sheet.png`, export `asset_name_portrait_<state>.png`.
- If the spec output has only one state, use the documented target output name without adding a state suffix.

Examples:

- `ui_button_primary_gold_portrait_default.png`
- `ui_button_primary_gold_portrait_pressed.png`
- `ui_button_primary_gold_portrait_disabled.png`
- `world_north_exit_unlocked_unlocked.png`
- `world_north_exit_unlocked_glow_ready.png`
- `world_floor_tile_stone_default.png`
- `world_floor_tile_stone_variant_a.png`
- `world_floor_tile_stone_variant_b.png`

## Existing Assets To Skip

Skip any exact output filename already present under `Assets/Generated/`, including existing MVP sprites, generated ArtDirector sprites, and source atlases.

Examples of existing assets that must not be regenerated:

- `player_archer.png`
- `player_mage.png`
- `player_warrior.png`
- `enemy_dasher.png`
- `enemy_grunt.png`
- `enemy_shooter.png`
- `enemy_shooter_projectile.png`
- `projectile_archer_arrow.png`
- `projectile_mage_bolt.png`
- `ui_damage_edge_flash_portrait.png`
- `ui_door_indicator_blocked_feedback.png`
- `ui_door_indicator_locked.png`
- `ui_door_indicator_unlocked.png`
- Existing `ui_icon_*.png` files under `Assets/Generated/MVP/ui/icons/`
- Existing one-state and split-state files under `Assets/Generated/ArtDirector/`
- `atlas_characters.png`
- `atlas_enemies.png`
- `atlas_projectiles_vfx.png`
- `atlas_ui_icons.png`

## Sprite Scope

Generate missing one-object sprites from `Docs/AssetSpecs/00_manifest.md` and matching individual spec files under `Docs/AssetSpecs/assets/`.

Priority order:

1. Missing gameplay sprites: characters, enemies, projectiles, pickups, props, doors, wall segments, floor tiles, compact VFX.
2. Missing UI/UX component sprites: buttons, cards, rows, panels, HUD frames, joystick parts, menu panels, feedback indicators.
3. Missing overlay sprites only when the overlay is one object and not a composed screen/scene.

Out of scope:

- Multi-object sprites.
- Full-screen menu compositions.
- Full-room compositions.
- Full-screen scene backgrounds.
- New source atlases.
- QA approval handoff.

## Output Location

Save all generated PNGs under `Assets/Generated/`.

Use clear category subfolders where useful, for example:

- `Assets/Generated/ArtDirector/characters/`
- `Assets/Generated/ArtDirector/enemies/`
- `Assets/Generated/ArtDirector/projectiles/`
- `Assets/Generated/ArtDirector/vfx/`
- `Assets/Generated/ArtDirector/ui/buttons/`
- `Assets/Generated/ArtDirector/ui/cards/`
- `Assets/Generated/ArtDirector/ui/hud/`
- `Assets/Generated/ArtDirector/world/props/`
- `Assets/Generated/ArtDirector/world/doors/`
- `Assets/Generated/ArtDirector/world/rooms/`

## Completion Rules

- Do not send the result to QA for approval.
- Do not create a QA approval task.
- When finished, record what was generated and move this task to `Tasks/Done/`.

## Acceptance Criteria

- All generated outputs are PNG files under `Assets/Generated/`.
- No existing generated asset is overwritten or regenerated.
- Every generated sprite contains maximum one object.
- Every object state is exported as a separate PNG file.
- Menu sprites, wall sprites, UI sprites, VFX sprites, and all other sprites follow the one-object rule.
- Every generated sprite follows `Docs/Visual-Design.md`, the relevant `Docs/AssetSpecs/assets/` file, existing generated sprites, and `Assets/Generated/MVP/_source_atlases/` style references.
- No readable text, watermark, copied proprietary design, source atlas, obsolete landscape asset, or QA approval handoff is created.
