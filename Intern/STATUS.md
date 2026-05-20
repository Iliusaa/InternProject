---
project: "Stackspire"
phase: "portrait downstream reset"
sprint: 0
build: "none"
last_updated: "2026-05-20"
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
- [x] Warrior style-probe exploration completed by [[ArtDirector]]; Probe 04 mobile-grotesque approved as canonical visual direction

## In Progress
- [ ] Obsolete landscape generated asset cleanup routed to [[ArtDirector]]
- [ ] Portrait asset-spec rebuild pending [[UIUXDesigner]]
- [ ] Portrait implementation-card creation pending [[Architect]]
- [ ] Landscape-dependent art generation remains paused until portrait asset specs are rebuilt
- [ ] Unity object-layer technical plan pending [[Architect]]
- [ ] MVP art and implementation handoffs blocked from execution until portrait asset specs and implementation cards are refreshed
- [ ] Probe 04 reusable asset-generation skill routed to [[ArtDirector]]

## Next
- [ ] Run [[ArtDirector]] on `Tasks/Open/ArtDirector-Convert-Probe04-Asset-Generation-Skill-Stackspire.md` to create the official reusable Probe 04 skill document and one UI panel example
- [ ] Run [[ArtDirector]] on `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`
- [ ] Run [[UIUXDesigner]] on `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md`
- [ ] Run [[Architect]] on `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md`
- [ ] Run [[Coder]] on `Tasks/Open/Coder-Check-UnityMCP-Connection-Stackspire.md` to verify UnityMCP connectivity before implementation work continues
- [ ] Run [[Architect]] on `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`
- [ ] Run [[ArtDirector]] on `Tasks/Open/UIUX_Art_Asset_Request.md` only after portrait asset requirements are reconciled
- [ ] Use `Tasks/Open/UIUX_Unity_Implementation.md` after Architect decomposes portrait implementation cards
- [ ] Use `Tasks/Open/UIUX_QA_Checklist.md` after UI implementation exists

## Blockers
- Unity object-layer setup is a technical implementation blocker until [[Architect]] defines concrete layers, sorting layers, collision layers, tags, or prefab grouping.
- `Docs/AssetSpecs/` and `Tasks/Open/UIUX_Art_Asset_Request.md` still contain old landscape sizing and must be rebuilt before new production UI art generation.
- Existing generated landscape UI/HUD/screen assets must be audited and removed or marked deprecated before portrait QA.
- Production MVP art generation remains blocked by portrait asset-spec reconciliation, but the Probe 04 reusable skill task is explicitly style-system work and must not replace or integrate MVP assets.

---

> [[PM]]: update this file at the end of every session.
> Keep Done/In Progress/Next accurate - all other agents read this first.
> Also update [[TASKS]] and regenerate [[CONTEXT]].
