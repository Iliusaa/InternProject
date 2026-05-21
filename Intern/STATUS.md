---
project: "Stackspire"
phase: "portrait downstream reset"
sprint: 0
build: "none"
last_updated: "2026-05-21"
---

# STATUS

## Done
- [x] Gameplay MVP GDD approved for Architect handoff
- [x] Dark fantasy art style clarified; current MVP perspective is three-quarter top-down
- [x] MVP UI/UX spec found at `Docs/UIUX_MVP_SPEC.md`
- [x] MVP visual design reference found at `Docs/Visual-Design.md`
- [x] UI/UX HUD style concept image completed by [[ArtDirector]]
- [x] May 16 scoring, coin reward, reference resolution, and three-quarter top-down art direction updates validated by [[BA]]
- [x] May 17 BA clarification answers captured in `GDD.md`
- [x] Text-only MVP asset specification package created at `Docs/AssetSpecs/`
- [x] Portrait-only GDD rewrite approved by [[BA]] with 1080 x 1920 bounds
- [x] Portrait-only UI/UX spec rewrite completed in `Docs/UIUX_MVP_SPEC.md`
- [x] Root Unity `.gitignore` created and verified by [[Coder]] without QA handoff
- [x] UnityMCP connection verified by [[Coder]] and reusable external bridge added under `Bridge/`
- [x] Warrior style-probe exploration completed by [[ArtDirector]]; Probe 04 mobile-grotesque approved as canonical visual direction
- [x] Probe 04 reusable asset-generation skill completed by [[ArtDirector]] with one UI panel example
- [x] MVP workflow roadmap created at `Roadmaps/MVP_Workflow_Roadmap.md`
- [x] MVP architecture backlog created at `Backlog/MVP_Architecture_Backlog.md`
- [x] First MVP implementation task cards created at `Tasks/Open/MVP_First_Task_Cards.md`
- [x] Superseded Architect implementation-card handoffs archived under `Tasks/Archive/`
- [x] Unity object-layer technical plan resolved by [[Architect]] in decision `D02`; Coder setup handoff created
- [x] `MVP_First_Task_Cards.md` normalized into actionable task files `T22` through `T42` under `Tasks/Open/`
- [x] BA Coder kickoff clarifications documented and approved in `Tasks/Done/BA-Coder-Kickoff-Clarifications-Stackspire-MVP-2026-05-21.md`
- [x] Completed `T##` generated/project asset audit completed by [[Coder]] as `T43`; generated scene button and joystick base sprites were imported into Unity, and missing joystick thumb art was documented
- [x] `T28` player input reader completed by [[Coder]]; `PlayerInputReader` exposes movement, aim, and attack-held values from joysticks with editor keyboard/mouse fallback

## In Progress
- [ ] Obsolete landscape generated asset cleanup routed to [[ArtDirector]]
- [ ] Portrait asset-spec rebuild pending [[UIUXDesigner]]
- [ ] Missing Stackspire asset production pass routed to [[ArtDirector]] using the Probe04 skill

## Next
- [ ] Run [[ArtDirector]] on `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md` for a direct missing-asset production pass using the Probe04 skill
- [ ] Run [[ArtDirector]] on `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`
- [ ] Run [[UIUXDesigner]] on `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md`
- [ ] Run [[Coder]] on `Tasks/Open/T23_Coder-Audit-Unity-Baseline-Stackspire.md` as the first MVP implementation task
- [ ] Run [[Coder]] on `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md` after T23 and before prefab implementation
- [ ] Use decomposed `Tasks/Open/T24_...` through `Tasks/Open/T41_...` for first Coder implementation handoffs
- [ ] Run [[QA]] on `Tasks/Open/T42_QA-Create-Vertical-Slice-Checklist-Stackspire.md` after T40 GameOver flow exists
- [ ] Run [[ArtDirector]] on `Tasks/Open/UIUX_Art_Asset_Request.md` only after portrait asset requirements are reconciled
- [ ] Use `Tasks/Open/UIUX_Unity_Implementation.md` as supporting UI context after first MVP task cards begin implementation
- [ ] Use `Tasks/Open/UIUX_QA_Checklist.md` after UI implementation exists

## Blockers
- Unity object-layer setup remains a Coder project-settings task before gameplay prefab work, but the Architect decision blocker is resolved in `D02`.
- `Docs/AssetSpecs/` and `Tasks/Open/UIUX_Art_Asset_Request.md` still contain old landscape sizing and must be rebuilt before new production UI art generation.
- Existing generated landscape UI/HUD/screen assets must be audited and removed or marked deprecated before portrait QA.
- The legacy `Tasks/Open/UIUX_Art_Asset_Request.md` remains blocked by portrait asset-spec reconciliation. The direct Probe04 missing-asset production pass in `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md` is allowed to fill empty/missing generated folders without QA approval and must not overwrite approved MVP assets.

---

> [[PM]]: update this file at the end of every session.
> Keep Done/In Progress/Next accurate - all other agents read this first.
> Also update [[TASKS]] and regenerate [[CONTEXT]].
