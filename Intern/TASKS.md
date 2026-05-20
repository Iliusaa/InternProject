# TASKS

| ID | Title | Agent | Status | Depends On | Notes |
|----|-------|-------|--------|------------|-------|
| T00 | Setup vault | PM | done | - | Initial scaffold |
| T01 | Create current-style UI/UX concept image | ArtDirector | done | Approved GDD art style; UI/UX MVP spec | Output: `Assets/Generated/UI/stackspire_game_hud_style_concept.png`; task moved to `Tasks/Done/` |
| T02 | Create MVP UI/UX specification | UIUXDesigner | done | Approved GDD | Existing spec found at `Docs/UIUX_MVP_SPEC.md`; no `Docs/UIUX-Spec.md` task needed |
| T03 | Create MVP visual design reference | UIUXDesigner | done | May 16 GDD art direction | Existing reference found at `Docs/Visual-Design.md` |
| T04 | Validate May 16 scoring, coin, reference-resolution, and art-direction GDD updates | BA | done | GameDesigner May 16 update | BA review added to `GDD.md` on 2026-05-17 |
| T05 | Clarify object-layer rule | Architect | pending | BA May 17 review | Handoff: `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md` |
| T06 | Create MVP implementation cards | Architect | blocked | Portrait GDD rewrite and BA validation | Existing handoff uses pre-portrait approved GDD: `Tasks/Open/Architect-Create-MVP-Implementation-Cards-Stackspire.md` |
| T07 | Generate MVP UI art asset set | ArtDirector | blocked | Portrait UI/UX spec and asset requirement reconciliation | Existing handoff uses landscape specs: `Tasks/Open/UIUX_Art_Asset_Request.md` |
| T08 | Decompose and implement MVP Unity UI | Architect → Coder | blocked | Portrait UI/UX spec and Architect decomposition | Existing handoff uses pre-portrait `Docs/UIUX_MVP_SPEC.md`: `Tasks/Open/UIUX_Unity_Implementation.md` |
| T09 | QA MVP UI implementation | QA | pending | Implemented Unity UI | Handoff: `Tasks/Open/UIUX_QA_Checklist.md` |
| T10 | Update UI/UX spec for May 17 clarifications | UIUXDesigner | blocked | `GDD.md` May 17 clarifications | Fold into portrait rewrite; original handoff: `Tasks/Open/UIUX-Update-May17-Clarifications-Stackspire.md` |
| T11 | Check UnityMCP server connection | Coder | pending | Unity Editor open for Stackspire | Handoff: `Tasks/Open/Coder-Check-UnityMCP-Connection-Stackspire.md` |
| T12 | Rewrite GDD for portrait mobile | GameDesigner | done | Stakeholder orientation change | `GDD.md` is portrait-only and BA-approved; task moved to `Tasks/Done/GameDesigner-Rewrite-GDD-Portrait-Mobile-Stackspire.md` |
| T13 | Rewrite UI/UX spec for portrait mobile | UIUXDesigner | done | T12 complete and BA validated | `Docs/UIUX_MVP_SPEC.md` is portrait-only; task moved to `Tasks/Done/UIUX-Rewrite-Spec-Portrait-Mobile-Stackspire.md` |
| T14 | Validate portrait GDD rewrite | BA | done | T12 | BA approval recorded in `GDD.md`; task moved to `Tasks/Done/BA-Validate-Portrait-GDD-Stackspire.md` |
| T15 | Rebuild portrait asset specs | UIUXDesigner | pending | Portrait UI/UX spec | Handoff: `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md`; required before new ArtDirector generation |
| T16 | Create portrait MVP implementation cards | Architect | pending | BA-approved portrait GDD and portrait UI/UX spec | Handoff: `Tasks/Open/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md` |
| T17 | Remove obsolete landscape generated assets | ArtDirector | pending | Portrait GDD and UI/UX pivot | Handoff: `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`; delete only confirmed obsolete layout assets and hand off broken references to Coder |
| T18 | Update Unity gitignore rules | Coder | done | - | Completed by Coder; report: `Tasks/Done/Coder-Update-Unity-Gitignore-Stackspire.md`; no QA handoff per user instruction |

---

> Agents: append new rows - never delete rows.
> [[PM]]: update Status column after each handoff.
> Status values: `pending` . `in_progress` . `done` . `blocked`
> See [[STATUS]] for current sprint state.
