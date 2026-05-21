# Stackspire MVP Workflow Roadmap

## 1. Project Summary

Stackspire is a portrait-only Android roguelite tower climber. The approved source of truth is `Intern/GDD.md`, with portrait mobile UI requirements in `Intern/Docs/UIUX_MVP_SPEC.md`. The MVP target is a playable Unity build where the player chooses Warrior, Archer, or Mage, clears stacked rooms, earns score and coins, dies, banks coins through GameOver, buys permanent upgrades, and restarts stronger.

Current project state:
- The portrait GDD is BA-approved and uses 1080 x 1920 as the active reference frame.
- The portrait UI/UX MVP spec is complete and implementation-ready.
- Open routing includes Architect handoffs for portrait implementation decomposition and Unity object-layer clarification.
- Some older open handoffs still reflect pre-portrait or landscape assumptions and must be treated as superseded unless reconciled.
- `InternUnity/` exists as a Unity 2D URP project with default project structure, SampleScene, default Input System actions, URP 2D settings, and no visible gameplay implementation yet.

MVP goal:
- Deliver a portrait-only Android MVP with the full core loop: class select, room combat, enemy kills, score, coins, room progression, death, GameOver, permanent upgrades, persistence, and restart flow.

Current implementation maturity:
- Product/design maturity is high: core rules, UI/UX flow, mobile layout, scoring, coin economy, death flow, and upgrade requirements are specified.
- Architecture maturity is early: Unity layers, scene structure, prefab boundaries, runtime services, and implementation decomposition still need Architect decisions.
- Code maturity is baseline: the Unity project is present but gameplay/UI systems have not yet been implemented.
- Art maturity is partial: portrait asset specs and generated assets require reconciliation before final asset production.

## 2. Core Gameplay Loop

Gameplay flow:
- The player starts on Main Menu.
- Start Run opens Class Select.
- The player chooses Warrior, Archer, or Mage.
- The Game scene starts a tower room with the player near the south entrance.
- The player moves with the left virtual stick and aims/attacks with the right virtual stick.
- Enemies spawn in the active room.
- Enemy kills immediately award score and current-run coins.
- When all enemies die, the north exit unlocks and room-clear score is awarded.
- The player moves through the north exit to start the next room.
- Rooms become harder as the player climbs.
- The run ends when player health reaches 0.
- GameOver shows run results and banks current-run coins exactly once.
- The player can restart, open upgrades, or return to Main Menu.

Player progression:
- Score measures run performance and high score.
- Coins are earned from kills and banked after death through GameOver.
- Banked coins buy permanent upgrades.
- Permanent upgrades improve future runs through more health, more damage, more speed, more coin gain, and one class special per class.

Room/tower structure:
- The tower is a vertical sequence of fixed-screen rooms.
- The MVP can use one reusable room template with spawn variation.
- The full room must fit on a portrait phone screen with no camera scrolling.
- The south entrance and player spawn sit above the bottom control zone.
- The north exit remains locked until the room is cleared.
- Rooms climbed counts completed room transitions, not the current room number.

## 3. MVP Scope

Main menu:
- Start Run.
- Upgrades.
- High score and total coins display.
- Portrait-safe layout.

Class select:
- Warrior, Archer, and Mage choices.
- Clear selected state.
- Start Run returns to Game with selected class.
- Restart from GameOver or Pause returns to Class Select before the next run.

Combat:
- Warrior short melee arc.
- Archer straight projectile.
- Mage slower high-damage projectile.
- Attacks autofire while the right aim stick is held.
- Releasing aim stick stops new attacks.
- Damage, cooldowns, and projectile behavior use tunable values where practical.

Enemies:
- Grunt chase enemy.
- Dasher windup/lunge enemy.
- Shooter wandering ranged enemy.
- Enemy health and room composition scale by room rules.
- Enemies deal 1 heart damage through contact or projectile behavior as specified.

Room progression:
- One portrait room template is sufficient for MVP.
- Enemy spawning follows room thresholds.
- Last enemy death unlocks the north exit.
- Entering the unlocked north exit starts the next room.
- No score is awarded for entering the exit.

Coins:
- Every enemy kill grants 1 current-run coin before Greed bonus.
- Current-run coins are banked once when GameOver opens.
- Greed bonus is calculated at run end and rounds down.

Score:
- Enemy kill grants +20 score.
- Room clear grants +25 score.
- Score is not used to buy upgrades.
- High score persists after app restart.

Upgrades:
- Toughness: +1 max heart, 5 levels.
- Power: +10% attack damage, 5 levels.
- Agility: +5% move speed, 5 levels.
- Greed: +10% coins earned, 5 levels.
- Warrior special: one armor hit at start of each room, capped at 1.
- Archer special: double shot with second arrow after 0.08 sec.
- Mage special: unlimited penetration until wall.

Save system:
- Persist high score.
- Persist total banked coins.
- Persist purchased upgrade levels and class specials.
- Data must survive app restart.

GameOver:
- Shows final score.
- Shows rooms climbed.
- Shows current-run coins collected.
- Shows total banked coins after deposit.
- Shows killed-by source.
- Offers Restart, Upgrades, and Main Menu.

Portrait mobile UI:
- Uses 1080 x 1920 reference resolution.
- Respects safe areas.
- HUD top-left hearts, top-center Score/Room, top-right Coins/Pause.
- Movement stick lower-left.
- Aim/attack stick lower-right.
- Central combat lane remains readable.

## 4. Workstreams

### Architecture

Owns Unity structure, scene flow, component boundaries, prefab responsibilities, event flow, object layers, sorting layers, collision matrix, and implementation decomposition. Architecture must resolve the object-layer blocker before broad Coder work begins.

### Gameplay

Owns player run lifecycle, room state, room transitions, health/death, score events, coin events, room scaling, and run result generation.

### Combat

Owns class-specific attacks, damage application, projectile behavior, cooldowns, attack input consumption, and class special effects.

### Enemy AI

Owns enemy health, death hooks, Grunt chase, Dasher lunge, Shooter movement/projectiles, enemy contact damage, and enemy scaling integration.

### UIUX

Owns implementation fidelity to the portrait UI/UX spec, safe-area layout, HUD binding, menu screens, upgrade states, GameOver presentation, reusable UI prefabs, and placeholder-art readability.

### Mobile Input

Owns virtual joystick behavior, touch zones, right-stick attack hold/release state, analog magnitude, editor keyboard fallback, and portrait thumb-zone ergonomics.

### Save/Progression

Owns banked coins, high score, upgrade purchases, class specials, run-end coin banking, persistence, reset/debug tools, and future-run stat application.

### QA

Owns acceptance verification against GDD and UI/UX spec, vertical-slice smoke tests, room/score/coin edge cases, save persistence, GameOver correctness, and portrait safe-area checks.

### Build/Release

Owns Android build configuration, portrait orientation lock, device/aspect validation, performance sanity, package naming, and release-candidate build generation.

## 5. Development Phases

### Phase 0 Audit

Objectives:
- Audit `InternUnity/` project state.
- Confirm Unity version, packages, URP 2D setup, scenes, input backend, and Android settings.
- Identify obsolete landscape assumptions in open handoffs or assets.
- Define Unity layers, sorting layers, collision layers, tags, and prefab grouping.

Dependencies:
- Approved portrait `GDD.md`.
- Approved `Docs/UIUX_MVP_SPEC.md`.
- Architect object-layer handoff.

Exit criteria:
- Unity project enters Play Mode without errors.
- Required project folders exist.
- Portrait Android settings gaps are documented.
- Object-layer technical blocker is resolved or converted into explicit implementation work.
- Stale landscape handoffs/assets are marked superseded or queued for cleanup.

### Phase 1 Foundation

Objectives:
- Create MainMenu, ClassSelect, Game, and GameOver scene skeletons.
- Add portrait Canvas and SafeAreaRoot.
- Add virtual joystick foundation.
- Add selected-class runtime state.
- Add basic player prefab with movement and health.

Dependencies:
- Phase 0 exit criteria.

Exit criteria:
- MainMenu -> ClassSelect -> Game -> GameOver navigation works with placeholders.
- Portrait UI root uses 1080 x 1920 reference resolution.
- Left joystick outputs movement.
- Right joystick outputs aim direction and hold/release state.
- Player can move with mobile input and editor fallback.
- Player health can take damage and fire death once.

### Phase 2 Playable Loop

Objectives:
- Implement Warrior attack prototype.
- Implement EnemyBase and Grunt chase behavior.
- Implement one room controller with locked north exit.
- Implement score and current-run coin counters.
- Bind basic HUD values.
- Create first vertical slice from start to death to GameOver.

Dependencies:
- Phase 1 foundation.
- Enemy/player collision layer setup.

Exit criteria:
- Player selects Warrior and starts a run.
- Room 1 spawns 2 Grunts.
- Warrior can kill Grunts.
- Grunts can damage and kill player.
- Last enemy death unlocks north exit.
- Entering unlocked exit advances room count.
- Score and current-run coins update correctly.
- GameOver shows final score, rooms climbed, coins earned, and killed-by source.

### Phase 3 Systems Expansion

Objectives:
- Add Archer and Mage combat.
- Add Dasher and Shooter enemies.
- Add full room scaling rules.
- Add permanent upgrades and save data.
- Add upgrade menu functionality.
- Add class specials.
- Add exact coin banking and high score behavior.

Dependencies:
- Phase 2 playable loop.
- Save/progression architecture.
- Upgrade UI shell.

Exit criteria:
- All three classes are playable.
- All three enemy types appear according to room thresholds.
- Score and coins follow GDD timing.
- Coins bank exactly once when GameOver opens.
- Upgrade purchases persist.
- Upgrade effects apply to future runs.
- High score persists and is not submitted on pause abandon.

### Phase 4 UI/Polish

Objectives:
- Implement full portrait HUD and menu layouts.
- Integrate placeholder or portrait-ready generated assets.
- Add Pause Overlay with Resume, Restart, and Main Menu behavior.
- Add UI states for buttons, selected class, upgrade affordability, maxed, and bought.
- Add readable combat feedback for damage, room clear, locked exit, score, and coins.

Dependencies:
- Phase 3 systems.
- Reconciled portrait asset specs for final art pass.

Exit criteria:
- All MVP screens match portrait UI/UX structure.
- Safe-area behavior works on target aspect ratios.
- Pause Restart and Pause Main Menu abandon current run correctly.
- GameOver action stack routes correctly.
- UI remains readable with placeholder or final art.
- Dynamic labels are Unity UI text, not baked into sprites.

### Phase 5 QA & Release Candidate

Objectives:
- Validate full MVP against GDD and UI/UX acceptance criteria.
- Run portrait aspect and safe-area checks.
- Validate save persistence after app restart.
- Validate Android build configuration and installable build.
- Fix MVP-blocking defects only.

Dependencies:
- Phase 4 UI/polish.
- Android build environment available.

Exit criteria:
- Android build launches portrait-only.
- Core loop is playable end to end.
- Required GameOver stats are correct.
- Upgrade persistence survives app restart.
- UI passes 9:16, 9.5:20, 10:21, and safe-area checks.
- No out-of-scope systems are present.
- Release-candidate build is ready for stakeholder review.

## 6. Risks & Blockers

- Unity object-layer setup is unresolved until Architect defines concrete layers, sorting layers, collision matrix, tags, and prefab grouping.
- `InternUnity/` is still near-baseline, so implementation risk is concentrated in first integration passes.
- Existing project settings still show default landscape/window assumptions and must be corrected for portrait Android.
- Older open handoffs may contain obsolete landscape requirements and must not drive implementation.
- Portrait asset specs and art requests need reconciliation before final UI art generation.
- If save data is implemented late, GameOver, Upgrades, and high score behavior may require rework.
- If room framing is not validated early on a portrait Game view, combat readability and joystick placement may drift from the approved design.
- If Coder cards are too broad, components may violate the Architect one-behavior responsibility rule.

## 7. Architect Handoff Requirements

Architect must provide Coder-ready implementation cards after this roadmap, with each card scoped to one MonoBehaviour, one prefab, or one scene setup.

Required Architect outputs:
- Unity project baseline card.
- Scene flow skeleton cards.
- Portrait Canvas and SafeAreaRoot card.
- Virtual joystick card.
- Player movement and health cards.
- Class selection and combat cards.
- Enemy base and enemy behavior cards.
- Room controller and north-exit cards.
- Score, run coin, GameOver result, and save/progression cards.
- HUD and menu binding cards.
- Pause behavior cards.
- QA/debug validation card.

Each Architect card must include:
- Task ID.
- Goal.
- Files or areas likely involved.
- Implementation steps.
- Dependencies.
- Acceptance criteria.
- Test notes.
- Out-of-scope boundaries.

Architect must also document:
- Unity Layers.
- Sorting Layers.
- Collision matrix.
- Required tags.
- Prefab grouping conventions.
- Event boundaries between gameplay, UI, save data, and scene flow.

## 8. MVP Definition of Done

The Stackspire portrait Android MVP is done when:

- The game builds and launches on Android in portrait orientation only.
- Main Menu, Class Select, Game, Pause Overlay, Upgrade Menu, and GameOver are reachable.
- Warrior, Archer, and Mage are selectable and playable.
- Left virtual stick controls movement.
- Right virtual stick controls aim and autofire.
- Releasing the right stick stops new attacks.
- Movement uses horizontal 0.8x, vertical 1.0x, and normalized diagonals after axis multipliers.
- The room fits on portrait phone screen without scrolling.
- Enemies spawn, attack, take damage, and die.
- Grunt, Dasher, and Shooter are implemented.
- Room 1 starts with 2 Grunts.
- Room scaling follows the approved thresholds.
- North exit stays locked until all enemies die.
- Room clear grants +25 score.
- Enemy kill grants +20 score and +1 current-run coin.
- Entering the north exit advances rooms climbed but grants no score.
- Player death opens GameOver before any menu transition.
- GameOver shows final score, rooms climbed, current-run coins, total banked coins after deposit, and killed-by source.
- Death in Room 1 before entering the first north exit shows Rooms Climbed 0.
- Current-run coins deposit exactly once when GameOver opens.
- Pause Restart and Pause Main Menu abandon the active run, discard current-run coins, do not submit high score, and skip GameOver.
- Permanent upgrades can be purchased with banked coins.
- Upgrade levels, class specials, total banked coins, and high score persist after app restart.
- Portrait HUD and menus respect safe areas and remain readable on target phone aspect ratios.
- Final or placeholder assets preserve central combat readability.
- QA checklist passes for core gameplay, UI flow, save persistence, and Android portrait presentation.
