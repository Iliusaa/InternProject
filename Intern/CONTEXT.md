---
type: InstanceFrame
owner: "[[PM]]"
regenerated: "2026-05-21"
---
# CONTEXT

> [[PM]] regenerates this file at the start of every session.
> See [[Memory]] for the write rules.

sprint_goal: Use the completed Probe04 mobile-grotesque skill to produce missing isolated Stackspire assets while portrait implementation work remains pending.
last_session: PM reconciled the completed Probe04 skill conversion and routed a direct missing-asset production pass to [[ArtDirector]] via `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md`.
open_questions: No GDD blockers remain. The legacy UIUX art request still needs portrait asset-spec reconciliation, but the new Probe04 missing-asset pass is explicitly allowed by PM routing.
architecture_notes: Portrait implementation cards are pending under `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md`. Object-layer technical planning is still pending under `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`.

## Current Routing
- [[ArtDirector]] should run `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md` to generate missing isolated gameplay/UI assets under `Assets/Generated/` using `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md` and `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`. One object per PNG, one state per PNG, matching `.prompt.md` for every PNG, and no QA handoff.
- [[ArtDirector]] should remove obsolete landscape generated assets from `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`.
- [[UIUXDesigner]] should rebuild portrait asset specs from `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md` before new ArtDirector generation.
- [[Architect]] should create portrait implementation cards from `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md`.
- [[Coder]] verified UnityMCP connectivity and added the reusable external bridge under `Bridge/`; report is in `Tasks/Done/Coder-Check-UnityMCP-Connection-Stackspire.md`.
- [[Architect]] should define the Unity object-layer technical plan from `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`.
- [[GameDesigner]], [[BA]], and [[UIUXDesigner]] portrait rewrite tasks are complete unless reopened by PM.
- The old `Tasks/Open/Architect-Create-MVP-Implementation-Cards-Stackspire.md` is superseded by the portrait implementation-card handoff.
- [[ArtDirector]] should not generate from the legacy `Tasks/Open/UIUX_Art_Asset_Request.md` until portrait asset specs are reconciled; use the new Probe04 missing-asset task for direct asset production instead.
- [[Architect]] and [[Coder]] should use `Tasks/Open/UIUX_Unity_Implementation.md` only after portrait implementation cards are decomposed.
- [[QA]] should use `Tasks/Open/UIUX_QA_Checklist.md` after the Unity UI exists.

## Style Anchor
- Probe 04 is approved as the canonical Stackspire visual direction: `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`.
- Probe 04 asset-generation skill is available at `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`.

## Decisions
see [[decisions]]

## Links
[[STATUS]] - [[TASKS]] - [[GDD]] - [[AGENTS]]
