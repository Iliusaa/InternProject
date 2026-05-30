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
| T22 | Configure Unity layers, sorting layers, and collision matrix | Coder | done | T23; Architect decision D02 | Completed: `Tasks/Done/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md`; Unity layers, sorting layers, collision matrix, and prefab folders configured |
| T23 | Audit Unity baseline | Coder | done | - | Completed: `Tasks/Done/T23_Coder-Audit-Unity-Baseline-Stackspire.md`; baseline audit handoff is no longer in `Tasks/Open/` |
| T24 | Create MVP scene bootstrap | Coder | done | T23 | Completed: `Tasks/Done/T24_Coder-Create-MVP-Scene-Bootstrap-Stackspire.md`; MainMenu, ClassSelect, Game, and GameOver scene bootstrap completed |
| T25 | Create portrait Canvas root | Coder | done | T24 | Completed: `Tasks/Done/T25_Coder-Create-Portrait-Canvas-Root-Stackspire.md`; reusable portrait Canvas root completed |
| T26 | Implement safe-area root | Coder | done | T25 | Completed: `Tasks/Done/T26_Coder-Implement-Safe-Area-Root-Stackspire.md`; reusable `SafeAreaRoot` added |
| T27 | Implement virtual joystick | Coder | done | T26 | Completed: `Tasks/Done/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`; reusable `VirtualJoystick` prefab and Game scene instances added |
| T28 | Create player input reader | Coder | done | T27 | Completed: `Tasks/Done/T28_Coder-Create-Player-Input-Reader-Stackspire.md`; created `PlayerInputReader`, wired Game scene joysticks, and added editor keyboard/mouse fallback |
| T29 | Implement player movement | Coder | done | T22; T28 | Completed: `Tasks/Done/T29_Coder-Implement-Player-Movement-Stackspire.md`; created `PlayerMovement`, Player prefab, generated warrior sprite import, and wired Game scene player input |
| T30 | Implement player health and damage | Coder | done | T29 | Completed: `Tasks/Done/T30_Coder-Implement-Player-Health-Damage-Stackspire.md`; created `DamagePayload`, `PlayerHealth`, 5-heart default, invulnerability, health/death events, and killed-by source storage |
| T31 | Implement enemy base | Coder | done | T22; T30 | Completed: `Tasks/Done/T31_Coder-Implement-Enemy-Base-Stackspire.md`; created `EnemyBase`, generated Grunt placeholder prefab, damage receiving, health/death events, and one-shot death handling |
| T32 | Implement Grunt chase | Coder | done | T31 | Completed: `Tasks/Done/T32_Coder-Implement-Grunt-Chase-Stackspire.md`; created `GruntChase`, Grunt prefab, Rigidbody2D target chase, contact damage, and `Grunt` damage source label |
| T33 | Implement room manager | Coder | done | T32 | Completed: `Tasks/Done/T33_Coder-Implement-Room-Manager-Stackspire.md`; created `RoomManager`, wired Game scene spawn points, spawns 2 Room 1 Grunts, tracks active enemies, and fires room clear once |
| T34 | Implement north exit lock | Coder | done | T22; T33 | Completed: `Tasks/Done/T34_Coder-Implement-North-Exit-Lock-Stackspire.md`; created `NorthExit`, locked/unlocked visuals, room-clear unlock, player advance trigger, room increment, and respawn flow |
| T35 | Implement run coin counter | Coder | done | T33 | Completed: `Tasks/Done/T35_Coder-Implement-Run-Coin-Counter-Stackspire.md`; created `RunCoinCounter`, RoomManager enemy-death event, +1 coin per enemy death, reset, change event, and debug inspector count |
| T36 | Implement run score counter | Coder | done | T33; T34 | Completed: `Tasks/Done/T36_Coder-Implement-Run-Score-Counter-Stackspire.md`; adds enemy death and room-clear score events |
| T37 | Implement Game HUD prototype | Coder | done | T26; T34; T35; T36 | Completed: `Tasks/Done/T37_Coder-Implement-Game-HUD-Prototype-Stackspire.md`; binds Hearts, Score, Room, and Coins HUD labels |
| T38 | Implement class selection state | Coder | done | T24 | Completed: `Tasks/Done/T38_Coder-Implement-Class-Selection-State-Stackspire.md`; runtime class selection now flows from ClassSelect to Game |
| T39 | Implement Warrior attack prototype | Coder | done | T28; T31; T38 | Completed: `Tasks/Done/T39_Coder-Implement-Warrior-Attack-Prototype-Stackspire.md`; Warrior melee attack now damages enemies inside a 180-degree aim arc |
| T40 | Implement GameOver flow | Coder | done | T30; T34; T35; T36 | Completed: `Tasks/Done/T40_Coder-Implement-GameOver-Flow-Stackspire.md`; run death captures result stats, loads GameOver, and wires Restart/Main Menu navigation |
| T41 | Implement save system stub | Coder | done | T23 | Completed: `Tasks/Done/T41_Coder-Implement-Save-System-Stub-Stackspire.md`; PlayerPrefs JSON save stores high score, banked coins, upgrade levels, and class special flags |
| T42 | Create vertical-slice QA checklist | QA | done | T40 | Completed: `Tasks/Done/T42_QA-Create-Vertical-Slice-Checklist-Stackspire.md`; checklist: `Docs/QA/Vertical-Slice-Checklist-Stackspire.md` |
| T43 | Audit completed T## generated/project asset integration | Coder | done | Completed T## tasks; generated asset pass | Completed: `Tasks/Done/T43_Coder-Audit-Completed-T-Generated-Assets-Stackspire.md`; imported suitable generated button and joystick base assets, documented missing joystick thumb, and did not broadly reopen completed work |
| T44 | Create Stackspire fullscreen class-select and room concepts | ArtDirector | done | Probe04 style anchor; rejected 2026-05-30 concepts removed | Completed: `Tasks/Done/T44_ArtDirector-Create-Stackspire-Fullscreen-Concepts.md`; generated 2 class-selection concepts and 2 in-game room concepts under `Assets/Generated/MVP/screens/`, with matching prompt logs and Unity PNG mirrors |

---

> Agents: append new rows - never delete rows.
> [[PM]]: update Status column after each handoff.
> Status values: `pending` . `in_progress` . `done` . `blocked`
> See [[STATUS]] for current sprint state.
