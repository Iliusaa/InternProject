---
type: InstanceFrame
owner: "[[PM]]"
regenerated: "2026-05-22"
---
# CONTEXT

> [[PM]] regenerates this file at the start of every session.
> See [[Memory]] for the write rules.

sprint_goal: Execute the decomposed portrait Android MVP vertical-slice task files while asset and Unity setup follow-ups remain tracked.
last_session: PM normalized `MVP_First_Task_Cards.md` into actionable task files `T22` through `T42` under `Tasks/Open/` and updated `TASKS.md` with one pending row per decomposed task.
open_questions: No GDD blockers remain. The legacy UIUX art request still needs portrait asset-spec reconciliation, but the new Probe04 missing-asset pass is explicitly allowed by PM routing.
architecture_notes: First implementation cards were normalized into individual `Tasks/Open/T##_...Stackspire.md` handoffs. Object-layer technical planning is resolved in `Knowledge/decisions.md` decision `D02`; Coder implementation is routed through `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md` and backlog item `ARCH-BL-003`.

## Current Routing
- [[ArtDirector]] should run `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md` to generate missing isolated gameplay/UI assets under `Assets/Generated/` using `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md` and `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`. One object per PNG, one state per PNG, matching `.prompt.md` for every PNG, and no QA handoff.
- [[ArtDirector]] should remove obsolete landscape generated assets from `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`.
- [[UIUXDesigner]] should rebuild portrait asset specs from `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md` before new ArtDirector generation.
- [[Coder]] should use decomposed handoffs `Tasks/Open/T23_...` through `Tasks/Open/T41_...` for first vertical-slice implementation.
- [[Coder]] completed `T43` at `Tasks/Done/T43_Coder-Audit-Completed-T-Generated-Assets-Stackspire.md`: imported generated primary button and joystick base sprites into `InternUnity/Assets/Generated/`, integrated them into current scene buttons and `VirtualJoystick`, and documented missing `ui_joystick_thumb` art.
- [[Coder]] completed `T28` at `Tasks/Done/T28_Coder-Create-Player-Input-Reader-Stackspire.md`: `PlayerInputReader` now exposes movement, aim, and attack-held values, supports mobile joysticks, and has editor keyboard/mouse fallback wired in `Game.unity`.
- [[Coder]] completed `T38` at `Tasks/Done/T38_Coder-Implement-Class-Selection-State-Stackspire.md`: ClassSelect now selects Warrior, Archer, or Mage through runtime `ClassSelectionState`, and Game has a temporary selected-class debug label.
- [[Coder]] completed `T39` at `Tasks/Done/T39_Coder-Implement-Warrior-Attack-Prototype-Stackspire.md`: Player now has `WarriorAttack`, uses aim-held cooldown attacks, damages enemies inside a short 180-degree arc, and flashes the generated Warrior slash sprite.
- [[Coder]] completed `T40` at `Tasks/Done/T40_Coder-Implement-GameOver-Flow-Stackspire.md`: Player death now captures run result stats, loads GameOver, displays final score, rooms climbed, coins, banked coins, and killed-by source, with Restart to ClassSelect and Main Menu to MainMenu.
- [[Coder]] should run `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md` after T23 and before Player, Enemy, Projectile, RoomBounds, and Exit prefab implementation.
- [[QA]] should use `Tasks/Open/T42_QA-Create-Vertical-Slice-Checklist-Stackspire.md` now that T40 GameOver flow exists.
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
