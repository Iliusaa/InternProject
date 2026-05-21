# UIUXDesigner Handoff - Rebuild Asset Specs For Portrait Mobile

Target agent: [[UIUXDesigner]]
Source: [[UIUXDesigner]]
Date: 2026-05-19
Deadline: 1 UIUXDesigner session

## Task
Rebuild `Docs/AssetSpecs/` and update `Tasks/Open/UIUX_Art_Asset_Request.md` so generated UI and screen assets match the portrait-only mobile UI spec.

## Reason
`Docs/UIUX_MVP_SPEC.md` now uses portrait phone reference bounds of 1080 x 1920. The existing asset specification package and UI art request still contain old wide-canvas dimensions, screen zones, and full-screen asset sizes. They must not be used for final generation until reconciled.

## Inputs
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `GDD.md`
- `Docs/AssetSpecs/`
- `Tasks/Open/UIUX_Art_Asset_Request.md`
- `Agents/UIUXDesigner.md`
- `Agents/ArtDirector.md`
- `Core/Conventions.md`

## Required Updates
- Change asset manifest and dimension rules to 1080 x 1920 portrait phone reference bounds.
- Resize screen backgrounds, overlays, damage edge flash, HUD plaques, class cards, upgrade rows, pause panel, Game Over panel, and joystick assets to match `Docs/UIUX_MVP_SPEC.md`.
- Update generation prompts that mention old screen composition or canvas dimensions.
- Keep dynamic labels, numbers, prices, scores, room values, and killed-by text as Unity UI text, not baked into sprites.
- Update `Tasks/Open/UIUX_Art_Asset_Request.md` so ArtDirector does not generate obsolete wide-canvas UI assets.

## Acceptance Criteria
- `Docs/AssetSpecs/00_manifest.md` and `Docs/AssetSpecs/00_dimensions_and_naming.md` use 1080 x 1920 portrait reference bounds.
- Full-screen assets target 1080 x 1920 unless explicitly not full-screen.
- UI component dimensions match the portrait UI/UX spec.
- ArtDirector handoff references portrait asset specs and no obsolete screen zones.
