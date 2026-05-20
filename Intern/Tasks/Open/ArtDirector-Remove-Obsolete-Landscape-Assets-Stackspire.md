# ArtDirector Handoff - Remove Obsolete Landscape Generated Assets

Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-19
Deadline: 1 ArtDirector session

## Task
Audit and remove obsolete landscape-oriented generated assets created before the portrait-mode pivot.

## Context
Stackspire has changed from Android landscape layout to portrait-only Android phone layout at 1080 x 1920.

Current sources of truth:
- `GDD.md` - BA-approved portrait-only Android phone GDD.
- `Docs/UIUX_MVP_SPEC.md` - portrait-only Android phone UI/UX spec.
- `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md` - portrait asset specs still need rebuilding before new ArtDirector generation.

Existing landscape-oriented generated assets are outdated and must not be treated as production portrait assets.

## Locations To Check First
- `Assets/Generated/UI/`
- `Assets/Generated/MVP/`
- any generated HUD, screen background, panel, button, joystick, overlay, or mockup asset based on old wide-canvas specs
- old 1920 x 1080 or wide-ratio UI concepts
- assets generated from the old `Docs/AssetSpecs/` package if those specs were layout-dependent

## Known Likely Obsolete Candidates
- `Assets/Generated/UI/stackspire_game_hud_style_concept.png`
- `Assets/Generated/UI/stackspire_game_hud_style_concept_v2.png`
- landscape-era UI/HUD assets under `Assets/Generated/MVP/`

## Do Not Delete
Do not delete reusable character, enemy, weapon, VFX, icon, or non-layout-dependent sprites unless they are clearly tied to the old wide UI layout.

If unsure whether an asset is reusable in portrait mode, mark it as `needs_review` instead of deleting it.

## Required Work
1. Create an audit list of generated assets reviewed.
2. Separate assets into:
   - `delete_now`
   - `keep_reusable`
   - `needs_review`
3. Delete only confirmed obsolete landscape layout assets from `delete_now`.
4. Update `Agents/ArtDirector-Memory.md` asset registry so it no longer presents deleted landscape assets as active production assets.
5. Add a memory note that landscape-generated assets were removed because the project is now portrait-only.
6. Check whether deleted assets are referenced by Unity scenes, prefabs, UI Images, SpriteRenderers, materials, or other project files.
7. If any deleted asset has a Unity reference, create a [[Coder]] handoff in `Tasks/Open/` to remove or replace the broken reference.

## Reference Check Guidance
Use filename and GUID/meta references where possible:
- Check references to deleted filenames across `Assets/`, `ProjectSettings/`, `Packages/`, and task/docs files.
- If `.meta` files exist, check GUID references before deleting or immediately after deletion from the deletion diff.
- Do not edit scenes, prefabs, scripts, or materials as ArtDirector unless the task is purely documenting a required Coder fix.

## Required Output
- Append the audit summary to `Agents/ArtDirector-Memory.md`.
- Include `delete_now`, `keep_reusable`, and `needs_review` lists in the memory note.
- If references are found, create one Coder handoff named clearly for broken landscape asset references.

## Acceptance Criteria
- No confirmed obsolete landscape HUD/screen assets remain in active production folders.
- `Agents/ArtDirector-Memory.md` clearly reflects which old assets were removed or deprecated.
- Reusable non-layout sprites are preserved.
- Any potential portrait-reusable asset is kept and marked `needs_review` instead of deleted.
- QA can verify portrait mode without missing sprite/reference errors, or a Coder handoff exists for any broken references found.
