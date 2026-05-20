---
type: InstanceFrame
owner: "[[PM]]"
regenerated: "2026-05-20"
---
# CONTEXT

> [[PM]] regenerates this file at the start of every session.
> See [[Memory]] for the write rules.

sprint_goal: Systematize the approved Probe 04 mobile-grotesque visual direction while downstream portrait implementation work remains pending.
last_session: PM routed the Probe 04 asset-generation skill conversion to [[ArtDirector]] via `Tasks/Open/ArtDirector-Convert-Probe04-Asset-Generation-Skill-Stackspire.md`, after reconciling the completed Warrior style-probe batch as done.
open_questions: No GDD blockers remain. Portrait asset specs still need rebuild before production UI/MVP ArtDirector generation.
architecture_notes: Portrait implementation cards are pending under `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md`. Object-layer technical planning is still pending under `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`.

## Current Routing
- [[ArtDirector]] should run `Tasks/Open/ArtDirector-Convert-Probe04-Asset-Generation-Skill-Stackspire.md` to create the official reusable Probe 04 asset-generation skill document plus exactly one UI panel example and prompt. It must use `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png` as the canonical style anchor and create no QA or MVP integration handoff.
- [[ArtDirector]] should remove obsolete landscape generated assets from `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`.
- [[UIUXDesigner]] should rebuild portrait asset specs from `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md` before new ArtDirector generation.
- [[Architect]] should create portrait implementation cards from `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md`.
- [[Coder]] should verify UnityMCP connectivity from `Tasks/Open/Coder-Check-UnityMCP-Connection-Stackspire.md`.
- [[Architect]] should define the Unity object-layer technical plan from `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`.
- [[GameDesigner]], [[BA]], and [[UIUXDesigner]] portrait rewrite tasks are complete unless reopened by PM.
- The old `Tasks/Open/Architect-Create-MVP-Implementation-Cards-Stackspire.md` is superseded by the portrait implementation-card handoff.
- [[ArtDirector]] should not generate new production UI/MVP art from `Tasks/Open/UIUX_Art_Asset_Request.md` until portrait asset specs are reconciled.
- [[Architect]] and [[Coder]] should use `Tasks/Open/UIUX_Unity_Implementation.md` only after portrait implementation cards are decomposed.
- [[QA]] should use `Tasks/Open/UIUX_QA_Checklist.md` after the Unity UI exists.

## Style Anchor
- Probe 04 is approved as the canonical Stackspire visual direction: `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`.

## Decisions
see [[decisions]]

## Links
[[STATUS]] - [[TASKS]] - [[GDD]] - [[AGENTS]]
