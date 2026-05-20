# Stackspire Asset Generation Skill Seed

This is a seed document only. It is not a packaged Codex skill.

## Recommended Visual Anchor

Use `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png` as the primary visual anchor for future reusable Stackspire asset generation.

Reason: it preserves Stackspire's grotesque dark-fantasy mood while making silhouette, face, weapon, and class color readable at mobile scale.

## Core Invariant Rules

- Perspective: fixed 2D three-quarter top-down for characters, enemies, projectiles, VFX, and props.
- Outline weight: thick uneven black ink outlines, never thin vector strokes.
- Proportions: tiny vulnerable bodies, oversized heads for player classes, exaggerated weapon or role silhouette first.
- Texture density: scuffed painterly texture, but simplified interior detail for 64x64 readability.
- Palette: use the approved Stackspire palette. Warrior dark crimson is `#6E151D` and `#9E2527`; bright damage red `#D64A32` is reserved for damage and urgent feedback only.
- Background treatment: reusable sprites use PNG/RGBA transparency. If chroma-key is used as an intermediate, remove `#00FF00` before final import.
- Mobile readability: every sprite or icon must read at 128x128 and remain identifiable at 64x64 in grayscale.
- Gore limits: brief stylized hit particles only. No realistic gore, body horror, dismemberment, exposed organs, or lingering gore piles.
- IP/reference guardrails: broad dark-fantasy mood inspiration only. Do not copy existing game characters, armor, UI motifs, symbols, logos, monsters, brushwork, or proprietary designs.

## Mandatory Style Anchor

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette.

## Class And Asset Adaptation Rules

- For Warrior: Warrior uses oversized sword and dark dried-crimson accents;
- For Archer: Archer uses oversized bow, nervous posture, and muted hunter-green or dark leather accents.
- For Mage: Mage uses oversized staff, anxious occult silhouette, and muted violet-blue shadow accents.
- For Enemy: Enemy uses grotesque readable threat silhouette, exaggerated head or limb shape, and sickly dungeon accent colors.
- For UI icon: UI icon keeps the same thick black ink outline, scuffed painterly texture, grim Stackspire palette, and high-contrast readable silhouette.

## Reusable Prompt Formula

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. `[class/enemy/world/UI role adaptation sentence]` Create `[asset_id]` as `[asset_category]` for Stackspire, original 2D dark fantasy mobile game art, fixed three-quarter top-down perspective where applicable, one object only, `[subject]`. Prioritize `[silhouette priority]` so the asset reads before detail or color. Use `[palette accents]` within the approved Stackspire palette. Keep the design grim, strange, absurd, oppressive, candlelit, and mobile-readable. Source canvas `[output size]`, generous padding, correct pivot intent, strong grayscale readability at 128x128 and 64x64. `[background rule]` No readable text, numbers, watermark, logo, copied game character, copied UI symbol, copied proprietary design, realistic gore, body horror, dismemberment, exposed organs, or lingering gore.

## Slot Definitions

- `[asset_id]`: exact target filename stem.
- `[asset_category]`: character, enemy, projectile, VFX, prop, room object, UI icon, UI frame, or screen background.
- `[subject]`: the single subject or object to generate.
- `[silhouette priority]`: the shape that must read first, such as sword, bow, staff, teeth, door arch, coin, heart, or pause symbol.
- `[class/enemy/world/UI role]`: role-specific identity and gameplay read.
- `[palette accents]`: limited exact color accents from the approved palette.
- `[output size]`: minimum source canvas and final target.
- `[background rule]`: transparent PNG/RGBA, opaque screen background, semi-transparent overlay, or raw chroma-key source that will be removed.

## Reusable Negative Prompt

photorealistic, 3D render, smooth plastic digital painting, clean heroic fantasy, anime clean lineart, thin vector outline, realistic anatomy, tall adult proportions, bright cheerful palette, bright saturated damage red costume, cluttered background, full scene, multiple characters, multiple objects, readable text, numbers, watermark, logo, extra limbs, malformed hands, deformed face, blurry, low quality, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied Darkest Dungeon character, copied UI symbols, copied logos, proprietary designs.

## Example Adaptation Prompt - Archer

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Archer uses oversized bow, nervous posture, and muted hunter-green or dark leather accents. Create `player_archer_style_source` as a character sprite for Stackspire, original 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body Archer only, tiny vulnerable tower-climber with compact body, oversized hooded head, anxious eyes, quiver, scuffed boots, and oversized bow held forward. Prioritize the bow silhouette so the class reads before costume detail. Use ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, sickly green #35533B #587642 #8A9B55, torch gold #8F5A24 #C18432 #E0B75C sparingly, and bone parchment #B8A487 #D6C6A1 for face highlights. Source canvas 512x512 minimum, generous padding, bottom-center feet pivot, readable at 128x128 and 64x64. Transparent PNG/RGBA or raw #00FF00 chroma-key source that will be removed before final import. No readable text, numbers, watermark, logo, copied game character, copied UI symbol, copied proprietary design, realistic gore, body horror, dismemberment, exposed organs, or lingering gore.

## Example Adaptation Prompt - Enemy

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Enemy uses grotesque readable threat silhouette, exaggerated head or limb shape, and sickly dungeon accent colors. Create `enemy_dasher_style_source` as an enemy sprite for Stackspire, original 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body enemy only, warped dungeon creature with hunched compact body, oversized lunging shoulder, tiny dragging legs, cracked mask-like face, and one exaggerated forward claw. Prioritize the forward lunge silhouette so the threat reads before texture. Use ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, sickly green #35533B #587642 #8A9B55, and bone parchment #B8A487 #D6C6A1 for tiny highlights. Source canvas 512x512 minimum, generous padding, bottom-center feet pivot, readable at 128x128 and 64x64. Transparent PNG/RGBA or raw #00FF00 chroma-key source that will be removed before final import. No readable text, numbers, watermark, logo, copied game character, copied UI symbol, copied proprietary design, realistic gore, body horror, dismemberment, exposed organs, or lingering gore.

## Example Adaptation Prompt - UI Icon

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. UI icon keeps the same thick black ink outline, scuffed painterly texture, grim Stackspire palette, and high-contrast readable silhouette. Create `ui_icon_warrior_sword_style_source` as a UI icon for Stackspire, original 2D dark fantasy mobile game art, one object only: a chipped oversized sword icon with chunky black silhouette, cracked stone-metal blade, small dark dried-crimson wrap, and tiny torch-gold nick highlights. Prioritize the sword silhouette so the icon reads at 64x64 before material detail. Use ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, torch gold #8F5A24 #C18432 #E0B75C, and bone parchment #B8A487 #D6C6A1. Source canvas 512x512 minimum, centered with generous padding, readable at 64x64 and in grayscale. Transparent PNG/RGBA or raw #00FF00 chroma-key source that will be removed before final import. No readable text, numbers, watermark, logo, copied UI symbol, copied proprietary design, realistic gore, body horror, dismemberment, exposed organs, or lingering gore.
