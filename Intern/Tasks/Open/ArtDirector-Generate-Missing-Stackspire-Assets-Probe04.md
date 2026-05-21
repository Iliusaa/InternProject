# ArtDirector Handoff - Generate Missing Stackspire Assets Using Probe04 Asset Skill

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-21
Priority: High - Asset Production
Deadline: Ongoing production pass

## Resume Tracker

LAST COMPLETED STEP: 2026-05-21 ArtDirector production chunk 1 generated 13 isolated Probe04 MVP assets with matching `.prompt.md` logs: primary button default, stone panel default, class card default, currency chip default, movement joystick idle base, upgrade row default, pause overlay panel default, game-over stat panel normal, lit torch prop, locked north exit, coin reward default, Warrior slash VFX default, and single stone floor slab.
NEXT STEP TO EXECUTE: Continue the missing-asset pass by generating remaining one-state-per-PNG assets and states under `Assets/Generated/`, especially additional button states, class-card states, joystick states/thumbs, remaining HUD frames, world doors/props, pickups, VFX, and any other empty/missing folders allowed by the one-object/no-full-scene rules.

If resuming after a context limit: check the tracker above. Skip completed steps and continue from NEXT STEP TO EXECUTE. Always reload Phase 0 references before generation.

## Goal

Use the approved Probe04 asset-generation skill and anchored Stackspire art style to generate missing gameplay assets and UI assets for MVP production.

ArtDirector must:

- Use `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md` as the primary generation system.
- Follow the anchored Stackspire visual language exactly.
- Fill currently empty or missing folders inside `Assets/Generated/`.
- Generate gameplay assets and UI assets required for MVP production.
- Maintain strict sprite isolation rules: one object per PNG and one state per PNG.
- Create a matching `.prompt.md` file for every generated PNG.
- Do not send results to QA approval.
- Do not wait for QA review.
- Treat this as a direct asset production pass.

## Phase 0 - Required References

Before generation, read or view:

- `GDD.md`
- `Docs/Visual-Design.md`
- `Docs/AssetSpecs/`
- `Agents/ArtDirector.md`
- `Agents/ArtDirector-Memory.md`
- `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`
- `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`

## Mandatory Style Anchor

Every generation prompt must begin from this anchor:

```text
Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette.
```

Then adapt the second sentence depending on asset type:

- Warrior: `Warrior uses oversized sword and dark dried-crimson accents;`
- Archer: `Archer uses oversized bow, nervous posture, and muted hunter-green or dark leather accents.`
- Mage: `Mage uses oversized staff, anxious occult silhouette, and muted violet-blue shadow accents.`
- Enemy: `Enemy uses grotesque readable threat silhouette, exaggerated head or limb shape, and sickly dungeon accent colors.`
- UI: `UI uses thick uneven black frames, chunky readable silhouettes, scuffed painterly stone/parchment textures, and grim mobile readability.`

This style anchor is the primary art-direction mechanism. Do not rely only on `Docs/Visual-Design.md`.

## Production Rules

### One Object Per PNG

Every PNG must contain exactly one isolated object.

Correct examples:

- one sword
- one warrior
- one button
- one chest
- one UI panel
- one projectile
- one icon

Incorrect examples:

- multiple props in one PNG
- character and weapon separated as unrelated objects
- full UI layout
- scene composition
- multiple buttons in one image

### One State Per PNG

If an asset has multiple states, every state must be generated as a separate sprite.

Examples:

- `button_idle.png`
- `button_hover.png`
- `button_pressed.png`
- `button_disabled.png`
- `lever_on.png`
- `lever_off.png`
- `chest_closed.png`
- `chest_open.png`
- `torch_lit.png`
- `torch_unlit.png`
- `panel_idle.png`
- `panel_selected.png`
- `panel_disabled.png`

Never combine multiple states into one PNG. Do not generate sprite sheets for this pass, even if older asset specs mention state sheets.

## Asset Categories To Generate

Generate missing assets from empty folders inside `Assets/Generated/`, focusing on:

### Characters

- player classes
- enemy variants
- NPCs if required by current MVP docs

### Props

- torches
- chests
- doors
- levers
- traps
- pickups
- dungeon objects

### Combat

- projectiles
- impact sprites
- hit flashes
- simple VFX

### UI

- buttons
- panels
- inventory slots
- card frames
- icon frames
- tabs
- bars
- selectors
- simple indicators

### Icons

- item icons
- currency icons
- stat icons
- simple ability icons

## UI Asset Rules

UI must follow Probe04 visual language:

- thick uneven black outlines
- chunky readable silhouettes
- scuffed painterly texture
- grotesque dark fantasy tone
- mobile readability first
- low-to-medium detail
- transparent background outside isolated UI element
- no copied external UI frames
- no ornate decorative filigree
- no realistic glossy rendering
- no full-screen layouts

UI must feel grim, strange, compact, chunky, readable, distressed, and hand-painted.

## Readability Rules

All assets must:

- read clearly at 128x128
- remain identifiable at 64x64
- maintain strong grayscale readability
- avoid excessive micro-detail
- prioritize silhouette first
- prioritize gameplay readability over rendering detail

## Palette Rules

Use approved Stackspire palette:

- Ink / Void: `#0E0B10`, `#17131A`, `#262129`
- Dungeon Stone: `#343038`, `#4B4447`, `#6D6461`
- Dried Crimson: `#6E151D`, `#9E2527`
- Torch Gold: `#8F5A24`, `#C18432`, `#E0B75C`
- Bone / Parchment: `#B8A487`, `#D6C6A1`

Avoid:

- bright saturation
- clean fantasy colors
- neon
- modern UI gradients
- excessive glow

## Output Rules

All outputs must:

- be PNG/RGBA
- use transparent backgrounds unless the current asset specifically requires otherwise
- include generous transparent padding
- stay isolated and centered
- follow project naming conventions
- save directly into the correct generated folders under `Assets/Generated/`

Do not overwrite approved MVP assets unless replacing a clearly missing placeholder. If an existing approved asset is present, leave it alone and generate only missing assets.

## Prompt Logging Requirement

Every generated asset must have an accompanying `.prompt.md` file containing:

- exact positive prompt
- exact negative prompt
- generation settings
- model/sampler if available
- short note describing gameplay role

Example pair:

- `torch_lit.png`
- `torch_lit.prompt.md`

## Negative Prompt Baseline

Use this baseline negative prompt unless an asset requires a stricter modification:

```text
photorealistic, 3D render, realistic anatomy, tall heroic proportions, clean cute mascot, bright cheerful cartoon, thin outline, vector-flat precision, glossy fantasy rendering, ornate filigree, elegant royal UI, cluttered background, full scene, multiple unrelated objects, unreadable silhouette, watermark, logo, blurry, low quality, realistic gore, body horror, copied Darkest Dungeon character, copied external game character, copied UI frame, copied icon, copied symbol, proprietary design
```

## Forbidden Actions

Do not:

- send assets to QA
- create QA review tasks
- wait for approval
- overwrite approved MVP assets unless replacing missing placeholders
- generate full scenes
- generate multi-object compositions
- generate sprite sheets
- generate multiple states inside one PNG
- copy Darkest Dungeon UI or characters
- create ornate decorative fantasy UI

## Completion Rules

When a production pass chunk is finished:

- Record generated assets in `Agents/ArtDirector-Memory.md`.
- Record the session in `Sessions/YYYY-MM-DD.md`.
- Leave this handoff open if more empty/missing folders remain.
- Move this handoff to `Tasks/Done/` only when the current missing-asset pass is complete.
- Do not create QA, Coder, MVP integration, or approval-gate handoffs unless PM explicitly requests them later.

## Acceptance Criteria

- Empty `Assets/Generated/` folders begin receiving production-ready assets.
- All assets use the Probe04 style system.
- Every PNG contains one isolated object only.
- Every asset state has its own PNG.
- UI follows Stackspire grotesque mobile-dark-fantasy style.
- Every asset has a matching `.prompt.md`.
- No QA handoff is created.
- No approval gate blocks generation.
