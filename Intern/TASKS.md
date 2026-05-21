# TASKS

| ID | Title | Agent | Status | Depends On | Notes |
|----|-------|-------|--------|------------|-------|
| T00 | Setup vault | PM | done | - | Initial scaffold |
| T01 | Create current-style UI/UX concept image | ArtDirector | done | Approved GDD art style; UI/UX MVP spec | Output: `Assets/Generated/UI/stackspire_game_hud_style_concept.png`; task moved to `Tasks/Done/` |
| T02 | Create MVP UI/UX specification | UIUXDesigner | done | Approved GDD | Existing spec found at `Docs/UIUX_MVP_SPEC.md`; no `Docs/UIUX-Spec.md` task needed |
| T03 | Create MVP visual design reference | UIUXDesigner | done | May 16 GDD art direction | Existing reference found at `Docs/Visual-Design.md` |
| T04 | Validate May 16 scoring, coin, reference-resolution, and art-direction GDD updates | BA | done | GameDesigner May 16 update | BA review added to `GDD.md` on 2026-05-17 |
| T05 | Clarify object-layer rule | Architect | done | BA May 17 review | Decision recorded as `D02` in `Knowledge/decisions.md`; completed handoff moved to `Tasks/Done/Architect-Clarify-Object-Layer-Rule-Stackspire.md` |
| T06 | Create MVP implementation cards | Architect | resolved/archived | Portrait GDD rewrite and BA validation | Superseded by MVP_first_task_cards. Archived: `Tasks/Archive/Architect-Create-MVP-Implementation-Cards-Stackspire.md` |
| T07 | Generate MVP UI art asset set | ArtDirector | blocked | Portrait UI/UX spec and asset requirement reconciliation | Existing handoff uses landscape specs: `Tasks/Open/UIUX_Art_Asset_Request.md` |
| T08 | Decompose and implement MVP Unity UI | Architect → Coder | blocked | Portrait UI/UX spec and Architect decomposition | Existing handoff uses pre-portrait `Docs/UIUX_MVP_SPEC.md`: `Tasks/Open/UIUX_Unity_Implementation.md` |
| T09 | QA MVP UI implementation | QA | pending | Implemented Unity UI | Handoff: `Tasks/Open/UIUX_QA_Checklist.md` |
| T10 | Update UI/UX spec for May 17 clarifications | UIUXDesigner | blocked | `GDD.md` May 17 clarifications | Fold into portrait rewrite; original handoff: `Tasks/Open/UIUX-Update-May17-Clarifications-Stackspire.md` |
| T11 | Check UnityMCP server connection | Coder | done | Unity Editor open for Stackspire | Completed by Coder; report: `Tasks/Done/Coder-Check-UnityMCP-Connection-Stackspire.md`; external bridge: `Bridge/` |
| T12 | Rewrite GDD for portrait mobile | GameDesigner | done | Stakeholder orientation change | `GDD.md` is portrait-only and BA-approved; task moved to `Tasks/Done/GameDesigner-Rewrite-GDD-Portrait-Mobile-Stackspire.md` |
| T13 | Rewrite UI/UX spec for portrait mobile | UIUXDesigner | done | T12 complete and BA validated | `Docs/UIUX_MVP_SPEC.md` is portrait-only; task moved to `Tasks/Done/UIUX-Rewrite-Spec-Portrait-Mobile-Stackspire.md` |
| T14 | Validate portrait GDD rewrite | BA | done | T12 | BA approval recorded in `GDD.md`; task moved to `Tasks/Done/BA-Validate-Portrait-GDD-Stackspire.md` |
| T15 | Rebuild portrait asset specs | UIUXDesigner | pending | Portrait UI/UX spec | Handoff: `Tasks/Open/UIUX-Rebuild-AssetSpecs-Portrait-Mobile-Stackspire.md`; required before new ArtDirector generation |
| T16 | Create portrait MVP implementation cards | Architect | resolved/archived | BA-approved portrait GDD and portrait UI/UX spec | Superseded by MVP_first_task_cards. Archived: `Tasks/Archive/Architect-Create-Portrait-MVP-Implementation-Cards-Stackspire.md` |
| T17 | Remove obsolete landscape generated assets | ArtDirector | pending | Portrait GDD and UI/UX pivot | Handoff: `Tasks/Open/ArtDirector-Remove-Obsolete-Landscape-Assets-Stackspire.md`; delete only confirmed obsolete layout assets and hand off broken references to Coder |
| T18 | Update Unity gitignore rules | Coder | done | - | Completed by Coder; report: `Tasks/Done/Coder-Update-Unity-Gitignore-Stackspire.md`; no QA handoff per user instruction |
| T19 | Generate Warrior style probe batch | ArtDirector | done | Approved dark-fantasy art direction and existing MVP character references | Completed by ArtDirector; report: `Tasks/Done/ArtDirector-Warrior-Style-Probe-Batch-Stackspire.md`; approved anchor: `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png` |
| T20 | Convert Probe 04 into reusable asset-generation skill | ArtDirector | done | T19 complete; Probe 04 approved as canonical style anchor | Completed by ArtDirector; report: `Tasks/Done/ArtDirector-Convert-Probe04-Asset-Generation-Skill-Stackspire.md`; reusable skill: `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`; example panel: `Assets/Generated/StyleProbes/warrior/probe04_ui_panel_example.png` |
| T21 | Generate missing Stackspire assets using Probe04 asset skill | ArtDirector | pending | T20 complete; Probe04 skill and style anchor available | Handoff: `Tasks/Open/ArtDirector-Generate-Missing-Stackspire-Assets-Probe04.md`; direct production pass for missing gameplay/UI assets under `Assets/Generated/`; one object/state per PNG; prompt logs required; no QA handoff |
| T22 | Configure Unity layers, sorting layers, and collision matrix | Coder | pending | T23; Architect decision D02 | Handoff: `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md`; decomposed from `MVP_first_task_cards` global setup dependency; must run before Player/Enemy/Projectile/RoomBounds/Exit prefab cards |
| T23 | Audit Unity baseline | Coder | pending | - | Handoff: `Tasks/Open/T23_Coder-Audit-Unity-Baseline-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-001 |
| T24 | Create MVP scene bootstrap | Coder | pending | T23 | Handoff: `Tasks/Open/T24_Coder-Create-MVP-Scene-Bootstrap-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-002 |
| T25 | Create portrait Canvas root | Coder | pending | T24 | Handoff: `Tasks/Open/T25_Coder-Create-Portrait-Canvas-Root-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-003 |
| T26 | Implement safe-area root | Coder | pending | T25 | Handoff: `Tasks/Open/T26_Coder-Implement-Safe-Area-Root-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-004 |
| T27 | Implement virtual joystick | Coder | pending | T26 | Handoff: `Tasks/Open/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-005 |
| T28 | Create player input reader | Coder | pending | T27 | Handoff: `Tasks/Open/T28_Coder-Create-Player-Input-Reader-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-006 |
| T29 | Implement player movement | Coder | pending | T22; T28 | Handoff: `Tasks/Open/T29_Coder-Implement-Player-Movement-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-007 |
| T30 | Implement player health and damage | Coder | pending | T29 | Handoff: `Tasks/Open/T30_Coder-Implement-Player-Health-Damage-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-008 |
| T31 | Implement enemy base | Coder | pending | T22; T30 | Handoff: `Tasks/Open/T31_Coder-Implement-Enemy-Base-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-009 |
| T32 | Implement Grunt chase | Coder | pending | T31 | Handoff: `Tasks/Open/T32_Coder-Implement-Grunt-Chase-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-010 |
| T33 | Implement room manager | Coder | pending | T32 | Handoff: `Tasks/Open/T33_Coder-Implement-Room-Manager-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-011 |
| T34 | Implement north exit lock | Coder | pending | T22; T33 | Handoff: `Tasks/Open/T34_Coder-Implement-North-Exit-Lock-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-012 |
| T35 | Implement run coin counter | Coder | pending | T33 | Handoff: `Tasks/Open/T35_Coder-Implement-Run-Coin-Counter-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-013 |
| T36 | Implement run score counter | Coder | pending | T33; T34 | Handoff: `Tasks/Open/T36_Coder-Implement-Run-Score-Counter-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-014 |
| T37 | Implement Game HUD prototype | Coder | pending | T26; T34; T35; T36 | Handoff: `Tasks/Open/T37_Coder-Implement-Game-HUD-Prototype-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-015 |
| T38 | Implement class selection state | Coder | pending | T24 | Handoff: `Tasks/Open/T38_Coder-Implement-Class-Selection-State-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-016 |
| T39 | Implement Warrior attack prototype | Coder | pending | T28; T31; T38 | Handoff: `Tasks/Open/T39_Coder-Implement-Warrior-Attack-Prototype-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-017 |
| T40 | Implement GameOver flow | Coder | pending | T30; T34; T35; T36 | Handoff: `Tasks/Open/T40_Coder-Implement-GameOver-Flow-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-018 |
| T41 | Implement save system stub | Coder | pending | T23 | Handoff: `Tasks/Open/T41_Coder-Implement-Save-System-Stub-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-019 |
| T42 | Create vertical-slice QA checklist | QA | pending | T40 | Handoff: `Tasks/Open/T42_QA-Create-Vertical-Slice-Checklist-Stackspire.md`; decomposed from `MVP_first_task_cards` MVP-020 |

---

> Agents: append new rows - never delete rows.
> [[PM]]: update Status column after each handoff.
> Status values: `pending` . `in_progress` . `done` . `blocked`
> See [[STATUS]] for current sprint state.
