---
type: InstanceFrame
owner: "[[PM]]"
regenerated: "2026-05-21"
---
# CONTEXT

> [[PM]] regenerates this file at the start of every session.
> See [[Memory]] for the write rules.

sprint_goal: Use the first MVP implementation cards to start the portrait Android playable vertical slice while asset and Unity setup follow-ups remain tracked.
last_session: Architect resolved the object-layer rule as a Unity technical setup decision, documented decision `D02`, and created a Coder setup handoff for layers, sorting layers, and collision matrix.
open_questions: No GDD blockers remain. The legacy UIUX art request still needs portrait asset-spec reconciliation, but the new Probe04 missing-asset pass is explicitly allowed by PM routing.
architecture_notes: First implementation cards are active under `Tasks/Open/MVP_First_Task_Cards.md`. Object-layer technical planning is resolved in `Knowledge/decisions.md` decision `D02`; Coder implementation is routed through `Tasks/Open/Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md` and backlog item `ARCH-BL-003`.

## Current Routing
- [[ArtDirector]] should run `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md` to generate missing isolated gameplay/UI assets under `Assets/Generated/` using `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md` and `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`. One object per PNG, one state per PNG, matching `.prompt.md` for every PNG, and no QA handoff.
- [[ArtDirector]] should remove obsolete landscape generated assets from `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`.
- [[UIUXDesigner]] should rebuild portrait asset specs from `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md` before new ArtDirector generation.
- [[Coder]] should use `Tasks/Open/MVP_First_Task_Cards.md` for first vertical-slice implementation handoffs.
- [[Coder]] should run `Tasks/Open/Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md` after MVP-001 and before Player, Enemy, Projectile, RoomBounds, and Exit prefab implementation.
- [[Coder]] verified UnityMCP connectivity and added the reusable external bridge under `Bridge/`; report is in `Tasks/Done/Coder-Check-UnityMCP-Connection-Stackspire.md`.
- [[Architect]] completed the Unity object-layer technical plan; no BA clarification is currently needed.
- [[GameDesigner]], [[BA]], and [[UIUXDesigner]] portrait rewrite tasks are complete unless reopened by PM.
- The old Architect implementation-card handoffs were superseded by `Tasks/Open/MVP_First_Task_Cards.md` and moved to `Tasks/Archive/`.
- [[ArtDirector]] should not generate from the legacy `Tasks/Open/UIUX_Art_Asset_Request.md` until portrait asset specs are reconciled; use the new Probe04 missing-asset task for direct asset production instead.
- [[Architect]] and [[Coder]] should use `Tasks/Open/UIUX_Unity_Implementation.md` as supporting UI context after first MVP task cards begin implementation.
- [[QA]] should use `Tasks/Open/UIUX_QA_Checklist.md` after the Unity UI exists.

## Style Anchor
- Probe 04 is approved as the canonical Stackspire visual direction: `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`.
- Probe 04 asset-generation skill is available at `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`.

## Decisions
see [[decisions]]

## Links
[[STATUS]] - [[TASKS]] - [[GDD]] - [[AGENTS]]
