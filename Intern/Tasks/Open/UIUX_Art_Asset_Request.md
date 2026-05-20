# UIUX Art Asset Request - Portrait Mobile

Target agent: [[ArtDirector]]
Source: [[UIUXDesigner]]
Date: 2026-05-19

## Purpose

Create or regenerate MVP UI and screen art assets for Stackspire using the portrait-only Android phone specs. The active reference frame is 1080x1920. Do not generate obsolete horizontal UI or screen assets.

## Inputs

- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Docs/AssetSpecs/00_manifest.md`
- `Docs/AssetSpecs/00_dimensions_and_naming.md`
- `Docs/AssetSpecs/00_style_guide.md`
- Relevant individual files under `Docs/AssetSpecs/assets/`
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`

## Required Art Direction

Original 2D dark fantasy mobile UI art with three-quarter top-down readability, thick uneven black ink outlines, scuffed dungeon texture, high-contrast silhouettes, deep stone grays, warm torch/coin golds, Warrior dark crimson, Archer sickly green, Mage occult blue-violet, and bright damage red reserved only for damage or urgent feedback.

Every prompt should treat `Docs/Visual-Design.md` as the visual reference and should use the exact dimensions, states, output names, and background rules from the matching `Docs/AssetSpecs/assets/` file.

Use the ArtDirector negative prompt from `Docs/AssetSpecs/00_style_guide.md`:

`photorealistic, 3D render, blurry, readable text, watermark, extra limbs, deformed, low quality, noisy background, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied UI symbols, copied logos, proprietary designs`

## Portrait Layout-Bound Assets To Generate

Generate these from the portrait specs before any Unity prefab polish:

- `screen_main_menu_background_portrait.png` at 1080x1920
- `screen_class_select_background_portrait.png` at 1080x1920
- `screen_upgrade_menu_background_portrait.png` at 1080x1920
- `screen_game_hud_room_background_portrait.png` at 1080x1920
- `screen_pause_dim_overlay_portrait.png` at 1080x1920 RGBA
- `screen_game_over_background_portrait_sheet.png` with 1080x1920 cells
- `ui_damage_edge_flash_portrait.png` at 1080x1920 RGBA
- `vfx_player_damage_flash_portrait_sheet.png` with 1080x1920 cells
- `world_room_template_stone_chamber_portrait.png` at 900x1250

## Portrait UI Component State Bundles

Generate interactive UI assets with all required states in the same output where practical:

- `ui_button_primary_gold_portrait_sheet.png` with default, pressed, disabled at 660x96 cells
- `ui_button_secondary_stone_portrait_sheet.png` with default, pressed, disabled at 620x84 cells
- `ui_button_tertiary_stone_portrait_sheet.png` with default, pressed, disabled at 560x76 cells
- `ui_button_icon_stone_portrait_sheet.png` with default, pressed, disabled at 72x72 cells
- `ui_class_card_portrait_sheet.png` with default, selected, pressed, disabled at 888x300 cells
- `ui_upgrade_row_global_portrait_sheet.png` with default, affordable, insufficient_coins, maxed, bought at 968x132 cells
- `ui_upgrade_row_class_special_portrait_sheet.png` with default, affordable, insufficient_coins, maxed, bought at 968x118 cells
- `ui_game_over_stat_panel_portrait_sheet.png` with normal and new_high_score at 780x495 cells
- `ui_pause_overlay_panel_portrait.png` at 700x630
- `ui_result_stat_row_portrait_sheet.png` with default and highlight at 700x64 cells
- `ui_currency_chip_portrait_sheet.png` with default and updated_pulse_highlight at 260x64 cells
- `ui_score_room_plaque_portrait_sheet.png` with default and update_pulse at 480x104 cells
- `ui_toast_label_frame_portrait_sheet.png` with room_clear, exit_locked, damage_warning at 500x80 cells
- `ui_heart_container_portrait_sheet.png` with default and wrap_reference at 398x104 cells
- `ui_joystick_movement_base_portrait_sheet.png` with idle_base and active_base at 240x240 cells
- `ui_joystick_aim_base_portrait_sheet.png` with idle_base, active_base, aim_direction_notch at 240x240 cells
- `ui_joystick_thumb_portrait_sheet.png` with thumb_idle and thumb_active at 96x96 cells

## Reusable Non-Layout Assets

These may be reused from existing non-layout generation if quality is acceptable, or regenerated from their individual specs if a cohesive portrait set is needed:

- Class/player sprites: Warrior, Archer, Mage
- Enemy sprites: Grunt, Dasher, Shooter
- Projectile sprites: Archer arrow, Mage bolt, Shooter projectile
- Heart, coin, pause, back, settings, class weapon, and upgrade icons
- Door indicators and world door sprites
- Compact VFX such as slash arc, arrow streak, magic trail, coin sparkle, damage particles, room-clear door glow, score marker
- World props and floor tiles

## Constraints

- No text, numbers, prices, score values, room values, killed-by strings, or button labels baked into sprites.
- Dynamic UI text must remain Unity UI text.
- Use PNG with transparency for reusable UI, icons, VFX, controls, and overlays.
- Use opaque 1080x1920 PNG for screen backgrounds unless the spec says RGBA overlay.
- Do not use `#00FF00` in final UI/gameplay art.
- Assets must remain readable at mobile HUD sizes, especially 64x64 icons.
- Class silhouettes must remain distinguishable in grayscale.
- Door locked and unlocked states must be readable without relying only on color.
- Do not create assets for out-of-scope systems.

## Acceptance Criteria

- Generated outputs follow the names, dimensions, states, transparency rules, and negative prompts from `Docs/AssetSpecs/`.
- No obsolete horizontal UI or screen assets are generated.
- Portrait screen art preserves clear top HUD space, bottom thumb-control space, and central combat readability.
- Button, panel, card, row, and joystick assets support Unity prefab composition without baked labels.