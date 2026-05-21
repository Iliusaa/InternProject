# Stackspire MVP Architecture Backlog

## 1. Technical Assumptions

- Stackspire is implemented in the existing `InternUnity/` Unity 2D URP project.
- MVP target platform is Android phone in portrait orientation only.
- Active UI/design reference resolution is 1080 x 1920.
- The current Unity project is near-baseline: URP 2D settings, `SampleScene`, default Input System actions, no visible gameplay scripts or prefabs yet.
- The first implementation milestone is a playable vertical slice, not final polish.
- Placeholder sprites, primitive colliders, and debug UI are acceptable until final portrait assets are ready.
- Unity Canvas can use Screen Space - Overlay for MVP unless implementation discovers a concrete reason to use Camera canvas.
- Gameplay code should use small, testable MonoBehaviours with one responsibility each.
- Runtime communication should use serialized references, cached references, C# events, UnityEvents, or small interfaces. Avoid per-frame scene searches.
- Player movement uses `Rigidbody2D`.
- One reusable room template is sufficient for MVP.
- Scene flow can start with separate scenes for MainMenu, ClassSelect, Game, UpgradeMenu, and GameOver, with Pause as an overlay inside Game.
- Save data can use a simple local JSON or PlayerPrefs-backed service for MVP, provided high score, total coins, and upgrade levels persist after app restart.
- Unity layers are grouped by collision/rendering need, not by assigning a unique layer to each object instance.

## 2. Architecture Areas

### Scene flow

Owns loading and routing between MainMenu, ClassSelect, Game, UpgradeMenu, and GameOver. Pause is an overlay state in Game. Scene flow must support Restart returning to ClassSelect and pause abandon behavior skipping GameOver.

### Input

Owns virtual joystick components, touch zones, aim hold/release state, editor keyboard fallback, editor aim fallback, and input handoff into player movement/combat components.

### Combat

Owns damage application, attack cooldowns, Warrior melee arc, Archer projectile, Mage projectile, projectile wall behavior, class specials, and damage source labels for killed-by reporting.

### Enemy systems

Owns shared enemy health/death behavior, enemy type labels, death events, contact damage, Grunt chase, Dasher lunge, Shooter wandering/shooting, and enemy prefab conventions.

### Player systems

Owns player movement, health, invulnerability, death event, selected class application, upgrade stat application, armor special handling, and player prefab composition.

### Room progression

Owns room controller, spawn points, enemy composition by room number, room clear detection, north exit lock/unlock, room advance, rooms climbed, and full-room portrait framing.

### Save system

Owns high score, total banked coins, upgrade levels, class specials, run coin banking, Greed bonus calculation, reset/debug tooling, and persistence after app restart.

### UI/HUD

Owns SafeAreaRoot, portrait Canvas, MainMenu UI, ClassSelect UI, Game HUD, Pause Overlay, UpgradeMenu, GameOver result binding, button states, upgrade states, and dynamic text.

### Asset pipeline

Owns folder conventions, generated asset import locations, placeholder asset strategy, portrait asset spec dependency, sprite sorting conventions, and preventing obsolete landscape assets from entering MVP scenes.

### Build pipeline

Owns Android build target, portrait orientation lock, package/product settings, build scenes, aspect-ratio validation, release candidate generation, and build smoke checks.

## 3. Epics

### Epic A: Unity foundation

Prepare the Unity project for MVP work: folders, baseline scene sanity, Android target settings, layers, sorting layers, collision matrix, and default prefab conventions.

### Epic B: Scene management

Implement the navigable MVP shell and runtime flow between MainMenu, ClassSelect, Game, UpgradeMenu, and GameOver.

### Epic C: Portrait mobile setup

Implement portrait-safe UI infrastructure, safe area handling, virtual joystick placement, and 1080 x 1920 reference layout.

### Epic D: Player controller

Implement player movement, health, damage, death, invulnerability, selected class application, and upgrade-modified stats.

### Epic E: Combat

Implement class attacks, projectile behavior, attack cooldowns, damage delivery, and class special mechanics.

### Epic F: Enemy AI

Implement shared enemy base behavior, Grunt, Dasher, Shooter, enemy projectiles, and death event hooks.

### Epic G: Progression

Implement room flow, room scaling, score, run coins, coin banking, high score, permanent upgrades, and class specials.

### Epic H: UI/HUD

Implement menu screens, HUD binding, GameOver result screen, Pause Overlay, UpgradeMenu, dynamic labels, and reusable UI prefabs.

### Epic I: Save system

Implement persistent data model, load/save service, upgrade purchase persistence, high score persistence, total coins persistence, and reset/debug support.

### Epic J: QA/debugging

Implement debug playtest controls, validation scenes, smoke checks, Android portrait checks, and release candidate readiness criteria.

## 4. Backlog Items

### ARCH-BL-001

Title: Unity project audit and baseline setup

Description: Audit `InternUnity/`, confirm Unity/package state, create MVP folder structure, and ensure the project enters Play Mode cleanly.

Dependencies: None.

Acceptance criteria:
- Project opens and enters Play Mode without console errors caused by missing setup.
- Folders exist for `Scripts`, `Prefabs`, `Scenes`, `ScriptableObjects`, `Generated`, `UI`, `Audio`, and `Tests` if tests are used.
- Current Unity packages and input backend are documented.
- Existing SampleScene/default state is documented as baseline or replaced by an MVP bootstrap scene.

Priority: P0

Risk level: Medium

### ARCH-BL-002

Title: Android portrait project settings

Description: Configure target platform and orientation settings for portrait-only Android MVP.

Dependencies: ARCH-BL-001.

Acceptance criteria:
- Android is configured as an intended build target.
- Portrait orientation is enforced.
- Landscape autorotation is disabled for MVP.
- Product name and bundle identifier no longer use default placeholder names.
- Build scene list is ready for MVP scenes.

Priority: P0

Risk level: Medium

### ARCH-BL-003

Title: Unity layers, sorting layers, and collision matrix

Description: Define technical object grouping for collisions, rendering order, and raycast/UI separation.

Dependencies: ARCH-BL-001.

Acceptance criteria:
- Unity layers are defined for Player, Enemy, PlayerProjectile, EnemyProjectile, RoomBounds, Exit, PickupOrReward if needed, and UI where needed.
- Sorting layers cover Background, Room, Characters, Projectiles, VFX, and UI.
- Collision matrix supports player/enemy/projectile/wall/exit behavior without unique per-object layers.
- Decision is documented for Coder implementation.

Priority: P0

Risk level: High

### ARCH-BL-004

Title: Scene flow skeleton

Description: Create MainMenu, ClassSelect, Game, UpgradeMenu, and GameOver scenes with simple navigation.

Dependencies: ARCH-BL-001, ARCH-BL-002.

Acceptance criteria:
- MainMenu routes to ClassSelect and UpgradeMenu.
- ClassSelect routes to Game.
- Game can route to GameOver through a debug trigger.
- GameOver routes to ClassSelect, UpgradeMenu, and MainMenu.
- Scenes are included in build settings.

Priority: P0

Risk level: Medium

### ARCH-BL-005

Title: Runtime scene navigation service

Description: Implement a small scene navigation component or service to centralize MVP scene loading.

Dependencies: ARCH-BL-004.

Acceptance criteria:
- Navigation methods exist for MainMenu, ClassSelect, Game, UpgradeMenu, and GameOver.
- Restart flow routes to ClassSelect.
- Game scene can request GameOver with a run result reference.
- No gameplay logic is embedded in button-only scripts.

Priority: P0

Risk level: Medium

### ARCH-BL-006

Title: Portrait Canvas and SafeAreaRoot

Description: Implement reusable Canvas setup and safe-area root for all MVP UI screens.

Dependencies: ARCH-BL-004.

Acceptance criteria:
- Canvas Scaler uses Scale With Screen Size.
- Reference resolution is 1080 x 1920.
- Match is 0.5.
- SafeAreaRoot stretches children to `Screen.safeArea`.
- Placeholder UI stays inside visible bounds at portrait aspect ratios.

Priority: P0

Risk level: Medium

### ARCH-BL-007

Title: Virtual joystick input foundation

Description: Implement reusable left/right virtual joystick components for movement and aim/attack hold.

Dependencies: ARCH-BL-006.

Acceptance criteria:
- Left joystick outputs analog direction and magnitude.
- Right joystick outputs aim direction and held/released state.
- Released joystick returns zero vector and not-held state.
- Touch zones are lower-left and lower-right inside safe area.
- Editor-visible debug values can verify joystick output.

Priority: P0

Risk level: Medium

### ARCH-BL-008

Title: Editor debug input fallback

Description: Provide keyboard movement and editor aim/attack fallback for faster local testing.

Dependencies: ARCH-BL-007.

Acceptance criteria:
- WASD provides movement in editor.
- Mouse or keyboard/right-stick simulation can provide aim/attack state in editor.
- Debug input does not break mobile joystick input.
- Input source can be tested without final UI art.

Priority: P1

Risk level: Low

### ARCH-BL-009

Title: Player prefab composition

Description: Create the initial Player prefab with Rigidbody2D, collider, movement hook, health hook, and placeholder sprite.

Dependencies: ARCH-BL-003, ARCH-BL-007.

Acceptance criteria:
- Player prefab exists under `Assets/Prefabs`.
- Player has Rigidbody2D and Collider2D.
- Player is assigned to correct layer/sorting configuration.
- Player can be spawned in Game scene near south entrance.

Priority: P0

Risk level: Medium

### ARCH-BL-010

Title: Player movement component

Description: Move the player from input vectors using GDD movement multipliers.

Dependencies: ARCH-BL-009.

Acceptance criteria:
- Movement uses Rigidbody2D.
- Full horizontal movement uses 0.8x multiplier.
- Full vertical movement uses 1.0x multiplier.
- Diagonal movement normalizes after axis multipliers.
- Partial joystick tilt moves slower than full tilt.

Priority: P0

Risk level: Medium

### ARCH-BL-011

Title: Player health and damage component

Description: Track hearts, damage, invulnerability, death, and killed-by source.

Dependencies: ARCH-BL-009.

Acceptance criteria:
- Player starts with 5 hearts by default.
- Damage removes 1 heart unless invulnerable.
- Invulnerability window defaults to 0.5 sec.
- Death fires once at 0 health.
- Death event includes the damage source that killed the player.

Priority: P0

Risk level: Medium

### ARCH-BL-012

Title: Class selection state

Description: Store selected class from ClassSelect and provide it to Game runtime.

Dependencies: ARCH-BL-004, ARCH-BL-005.

Acceptance criteria:
- Warrior, Archer, and Mage can be selected.
- Warrior can be preselected by default.
- Game scene can read selected class.
- Selection persists across scene load for the next run.

Priority: P0

Risk level: Low

### ARCH-BL-013

Title: Class combat data model

Description: Define tunable combat values for Warrior, Archer, and Mage.

Dependencies: ARCH-BL-012.

Acceptance criteria:
- Class damage and cooldowns are serialized or ScriptableObject-driven.
- Warrior default damage is 2 and cooldown is 0.55 sec.
- Archer default damage is 1 and cooldown is 0.35 sec.
- Mage default damage is 3 and cooldown is 0.85 sec.
- Future Power upgrade can modify attack damage cleanly.

Priority: P1

Risk level: Medium

### ARCH-BL-014

Title: Damage receiver interface and damage payload

Description: Create shared damage contracts for player, enemies, melee, projectiles, and killed-by labels.

Dependencies: ARCH-BL-011.

Acceptance criteria:
- Damage payload includes amount and source label.
- Enemy and player damage components can receive damage through a common call pattern.
- Killed-by strings can be passed through final lethal damage.
- Combat code does not need per-enemy special cases for basic damage.

Priority: P0

Risk level: Medium

### ARCH-BL-015

Title: Warrior attack prototype

Description: Implement short melee arc attack driven by right-stick aim hold.

Dependencies: ARCH-BL-007, ARCH-BL-013, ARCH-BL-014.

Acceptance criteria:
- Holding aim stick repeatedly attacks on Warrior cooldown.
- Releasing aim stick stops new attacks.
- Attack checks a short 180-degree arc in aim direction.
- Enemies in arc take Warrior damage.
- Attack can hit multiple enemies in the arc.

Priority: P0

Risk level: Medium

### ARCH-BL-016

Title: Projectile foundation

Description: Implement reusable projectile movement, collision, damage, range/wall destruction, and owner/source metadata.

Dependencies: ARCH-BL-003, ARCH-BL-014.

Acceptance criteria:
- Projectile moves in assigned direction.
- Projectile applies damage to valid targets.
- Projectile is destroyed on room wall collision unless penetration allows otherwise.
- Projectile has source label for killed-by and hit attribution.
- Player and enemy projectiles can use different layers.

Priority: P1

Risk level: Medium

### ARCH-BL-017

Title: Archer attack

Description: Implement straight projectile attack for Archer.

Dependencies: ARCH-BL-013, ARCH-BL-016.

Acceptance criteria:
- Holding aim stick fires arrows on Archer cooldown.
- Arrows travel in aim direction.
- Arrows damage enemies.
- Releasing aim stick stops new shots.
- Double-shot special can be added without rewriting base attack flow.

Priority: P2

Risk level: Medium

### ARCH-BL-018

Title: Mage attack

Description: Implement slower high-damage magic projectile attack for Mage.

Dependencies: ARCH-BL-013, ARCH-BL-016.

Acceptance criteria:
- Holding aim stick fires magic bolts on Mage cooldown.
- Bolts damage enemies for Mage damage.
- Bolts are destroyed on wall by default.
- Mage penetration special can switch bolts to pass through enemies until wall.

Priority: P2

Risk level: Medium

### ARCH-BL-019

Title: Enemy base prefab and component

Description: Implement shared enemy health, death event, enemy type label, and placeholder prefab base.

Dependencies: ARCH-BL-003, ARCH-BL-014.

Acceptance criteria:
- EnemyBase supports max/current health.
- Enemy death event fires once.
- Enemy type label is available for score/coin/killed-by systems.
- Enemy prefab has Collider2D and Rigidbody2D where needed.
- Enemy can be damaged and removed or disabled on death.

Priority: P0

Risk level: Medium

### ARCH-BL-020

Title: Grunt chase enemy

Description: Implement Grunt movement directly toward the player and contact damage.

Dependencies: ARCH-BL-011, ARCH-BL-019.

Acceptance criteria:
- Grunt moves toward player.
- Grunt contact damage source label is `Grunt`.
- Contact damage respects player invulnerability.
- Grunt can be killed by Warrior attack.

Priority: P0

Risk level: Medium

### ARCH-BL-021

Title: Dasher enemy

Description: Implement Dasher windup, straight-line lunge, cooldown, and contact damage.

Dependencies: ARCH-BL-019, ARCH-BL-020.

Acceptance criteria:
- Dasher pauses before lunging.
- Dasher lunges in a straight line.
- Dasher stops on room wall.
- Dasher contact damage source label is `Dasher`.
- Windup, dash duration, and cooldown are tunable.

Priority: P2

Risk level: Medium

### ARCH-BL-022

Title: Shooter enemy

Description: Implement Shooter wandering behavior and slow projectile firing.

Dependencies: ARCH-BL-016, ARCH-BL-019.

Acceptance criteria:
- Shooter changes random movement direction on interval.
- Shooter moves slowly while alive.
- Shooter fires projectile every 3 sec by default.
- Shooter projectile damage source label is `Shooter Projectile`.
- Projectile deals 1 heart to player.

Priority: P2

Risk level: High

### ARCH-BL-023

Title: Room template and bounds

Description: Create a portrait-readable room template with walls, spawn points, player start, and north exit placement.

Dependencies: ARCH-BL-003, ARCH-BL-009.

Acceptance criteria:
- Full room is visible in portrait Game view without camera scrolling.
- Player spawns near south entrance above bottom joystick visuals.
- North exit is visible above HUD conflict area.
- Room walls stop player and projectiles.
- Spawn points avoid immediate thumb-control zones.

Priority: P0

Risk level: High

### ARCH-BL-024

Title: North exit lock/unlock component

Description: Implement exit state and trigger behavior for locked and unlocked north exit.

Dependencies: ARCH-BL-023.

Acceptance criteria:
- Exit starts locked.
- Locked exit blocks or ignores advance.
- Unlocked exit allows room advance.
- Exit state can drive placeholder visual state or debug label.

Priority: P0

Risk level: Medium

### ARCH-BL-025

Title: Room controller vertical slice

Description: Spawn Room 1, track active enemies, unlock exit on clear, and advance room count.

Dependencies: ARCH-BL-020, ARCH-BL-024.

Acceptance criteria:
- Room 1 starts with 2 Grunts.
- Last enemy death unlocks north exit.
- Room clear event fires once and can award score.
- Entering unlocked exit starts the next room.
- Rooms climbed increases only after entering unlocked exit.

Priority: P0

Risk level: High

### ARCH-BL-026

Title: Room enemy scaling

Description: Add MVP enemy composition and health scaling by room number.

Dependencies: ARCH-BL-021, ARCH-BL-022, ARCH-BL-025.

Acceptance criteria:
- Rooms 1-3 use Grunts only.
- Room 4 adds Dasher.
- Room 7 adds Shooter.
- Room 10+ uses random mix respecting caps.
- Every 5 rooms starting at room 10 increases enemy health by +1.
- Max total enemies per room is tunable.

Priority: P2

Risk level: High

### ARCH-BL-027

Title: Score counter

Description: Track run score from enemy kills and room clears.

Dependencies: ARCH-BL-019, ARCH-BL-025.

Acceptance criteria:
- Enemy kill grants +20 score immediately.
- Room clear grants +25 score immediately when the last enemy dies.
- Entering north exit grants no score.
- Score changed event is available for HUD.

Priority: P0

Risk level: Low

### ARCH-BL-028

Title: Run coin counter

Description: Track current-run coins from enemy kills.

Dependencies: ARCH-BL-019.

Acceptance criteria:
- Enemy kill grants +1 current-run coin.
- Current-run coins reset at new run start.
- Coin changed event is available for HUD.
- No physical coin pickup is required for MVP.

Priority: P0

Risk level: Low

### ARCH-BL-029

Title: Run result model

Description: Capture final score, rooms climbed, current-run coins, killed-by source, high score state, and banked coin values for GameOver.

Dependencies: ARCH-BL-011, ARCH-BL-025, ARCH-BL-027, ARCH-BL-028.

Acceptance criteria:
- Player death creates one run result.
- Result includes final score.
- Result includes rooms climbed.
- Result includes current-run coins.
- Result includes killed-by source.
- Result supports total banked coins after deposit once save system exists.

Priority: P0

Risk level: Medium

### ARCH-BL-030

Title: Save data service

Description: Persist high score, total banked coins, upgrade levels, and class specials.

Dependencies: ARCH-BL-001.

Acceptance criteria:
- Save loads on app start or service initialization.
- Save writes high score, banked coins, upgrade levels, and class special purchases.
- Data persists after app restart.
- Debug reset is available in editor.
- Save service has clear API and does not depend on UI objects.

Priority: P1

Risk level: High

### ARCH-BL-031

Title: Coin banking and high score submission

Description: Bank current-run coins and update high score at GameOver, exactly once.

Dependencies: ARCH-BL-029, ARCH-BL-030.

Acceptance criteria:
- Current-run coins deposit immediately when GameOver opens.
- Deposit happens exactly once per run result.
- Greed bonus can be applied at deposit time.
- High score updates only through GameOver.
- Pause abandon does not submit high score or bank current-run coins.

Priority: P1

Risk level: High

### ARCH-BL-032

Title: Upgrade data and purchase rules

Description: Implement upgrade definitions, costs, levels, affordability, and purchase behavior.

Dependencies: ARCH-BL-030.

Acceptance criteria:
- Toughness, Power, Agility, and Greed each have 5 levels and approved costs.
- Warrior, Archer, and Mage specials each cost 500 and are one-time purchases.
- Purchase deducts banked coins and persists state.
- Cannot buy unaffordable or maxed upgrades.
- Upgrade state is queryable by UI and gameplay.

Priority: P2

Risk level: Medium

### ARCH-BL-033

Title: Upgrade effect application

Description: Apply saved upgrade effects to new runs and active class behavior.

Dependencies: ARCH-BL-013, ARCH-BL-030, ARCH-BL-032.

Acceptance criteria:
- Toughness modifies max hearts for new run.
- Power modifies attack damage additively from base values.
- Agility modifies move speed additively from base value.
- Greed modifies run-end coin payout.
- Class specials affect only their specified class behavior.

Priority: P2

Risk level: High

### ARCH-BL-034

Title: MainMenu UI binding

Description: Implement MainMenu UI with Start Run, Upgrades, high score, and total coins.

Dependencies: ARCH-BL-004, ARCH-BL-006, ARCH-BL-030.

Acceptance criteria:
- Start Run opens ClassSelect.
- Upgrades opens UpgradeMenu.
- High score is displayed.
- Total banked coins are displayed.
- Layout follows portrait safe-area rules.

Priority: P1

Risk level: Medium

### ARCH-BL-035

Title: ClassSelect UI binding

Description: Implement class selection cards/buttons and Start Run behavior.

Dependencies: ARCH-BL-006, ARCH-BL-012.

Acceptance criteria:
- Warrior, Archer, and Mage choices are visible.
- Selected class state is obvious with placeholder UI.
- Start Run loads Game with selected class.
- No scrolling is required for three default class choices.

Priority: P0

Risk level: Medium

### ARCH-BL-036

Title: Game HUD binding

Description: Bind HUD to health, score, room number, run coins, pause, and joystick controls.

Dependencies: ARCH-BL-006, ARCH-BL-007, ARCH-BL-011, ARCH-BL-025, ARCH-BL-027, ARCH-BL-028.

Acceptance criteria:
- Hearts appear top-left.
- Score and Room appear top-center.
- Coins and Pause appear top-right.
- Movement and aim sticks appear in lower thumb zones.
- HUD values update from gameplay events.
- Central combat lane remains readable.

Priority: P0

Risk level: High

### ARCH-BL-037

Title: GameOver UI binding

Description: Show final run result and route GameOver actions.

Dependencies: ARCH-BL-005, ARCH-BL-029, ARCH-BL-031.

Acceptance criteria:
- Shows final score.
- Shows rooms climbed.
- Shows current-run coins collected.
- Shows total banked coins after deposit.
- Shows killed-by source.
- Restart routes to ClassSelect.
- Upgrades routes to UpgradeMenu.
- Main Menu routes to MainMenu.

Priority: P1

Risk level: Medium

### ARCH-BL-038

Title: Pause overlay behavior

Description: Implement Pause Overlay with Resume, Restart, and Main Menu abandon behavior.

Dependencies: ARCH-BL-005, ARCH-BL-036.

Acceptance criteria:
- Pause opens overlay and pauses gameplay.
- Resume returns to gameplay.
- Restart discards current-run coins, does not submit high score, skips GameOver, and routes to ClassSelect.
- Main Menu matches abandon behavior and routes to MainMenu.
- No confirmation modal is required for MVP.

Priority: P1

Risk level: High

### ARCH-BL-039

Title: UpgradeMenu UI binding

Description: Implement upgrade list UI, banked coins display, affordability states, and buy actions.

Dependencies: ARCH-BL-006, ARCH-BL-032.

Acceptance criteria:
- Shows banked coins.
- Shows Toughness, Power, Agility, Greed, and class specials.
- Shows level, effect, next effect or max state, cost, and buy button.
- Unaffordable buttons show `Need X`.
- Maxed and bought states are disabled and clear.

Priority: P2

Risk level: Medium

### ARCH-BL-040

Title: Asset import and placeholder conventions

Description: Define where placeholder and generated assets live and how prefabs reference them.

Dependencies: ARCH-BL-001.

Acceptance criteria:
- `Assets/Generated/` is used for generated art.
- Placeholder assets are clearly named and isolated.
- No obsolete landscape full-screen assets are assigned to portrait MVP scenes.
- Sorting/pivot/import rules are documented for player, enemy, projectile, UI, and room sprites.

Priority: P1

Risk level: Medium

### ARCH-BL-041

Title: Debug playtest controls

Description: Add development-only controls for fast vertical-slice validation.

Dependencies: ARCH-BL-025, ARCH-BL-029.

Acceptance criteria:
- Debug controls can damage player.
- Debug controls can kill all enemies.
- Debug controls can add score/coins.
- Debug controls can advance room or reset run.
- Debug output can print score, coins, health, room, rooms climbed, and killed-by source.

Priority: P1

Risk level: Low

### ARCH-BL-042

Title: QA vertical slice checklist

Description: Create a repeatable smoke checklist for the first playable vertical slice.

Dependencies: ARCH-BL-041.

Acceptance criteria:
- Checklist covers MainMenu -> ClassSelect -> Game -> clear room -> advance -> die -> GameOver -> Restart.
- Checklist verifies joystick movement, Warrior attack, Grunt chase/damage, room clear, score, coins, HUD, death, and GameOver stats.
- Checklist includes expected Room 1 score/coin values after clearing 2 Grunts.
- Checklist records known gaps outside the vertical slice.

Priority: P1

Risk level: Low

### ARCH-BL-043

Title: Android build smoke

Description: Produce and validate an Android build once the vertical slice is playable.

Dependencies: ARCH-BL-002, ARCH-BL-036, ARCH-BL-042.

Acceptance criteria:
- Build completes for Android.
- App launches in portrait.
- MainMenu, ClassSelect, Game, HUD, and GameOver are reachable.
- Touch joysticks respond on device or emulator.
- No landscape rotation is observed.

Priority: P2

Risk level: High

### ARCH-BL-044

Title: Release candidate validation

Description: Validate the complete MVP build against GDD and UI/UX acceptance criteria.

Dependencies: ARCH-BL-026, ARCH-BL-033, ARCH-BL-038, ARCH-BL-039, ARCH-BL-043.

Acceptance criteria:
- All three classes are playable.
- All three enemy types appear.
- Score, coins, room progression, GameOver, upgrades, and save persistence pass.
- Portrait UI passes 9:16, 9.5:20, 10:21, and safe-area checks.
- Pause abandon behavior passes.
- No out-of-scope systems are present.

Priority: P3

Risk level: High

## 5. Dependency Order

1. ARCH-BL-001 Unity project audit and baseline setup
2. ARCH-BL-002 Android portrait project settings
3. ARCH-BL-003 Unity layers, sorting layers, and collision matrix
4. ARCH-BL-004 Scene flow skeleton
5. ARCH-BL-005 Runtime scene navigation service
6. ARCH-BL-006 Portrait Canvas and SafeAreaRoot
7. ARCH-BL-007 Virtual joystick input foundation
8. ARCH-BL-009 Player prefab composition
9. ARCH-BL-010 Player movement component
10. ARCH-BL-011 Player health and damage component
11. ARCH-BL-012 Class selection state
12. ARCH-BL-014 Damage receiver interface and damage payload
13. ARCH-BL-019 Enemy base prefab and component
14. ARCH-BL-020 Grunt chase enemy
15. ARCH-BL-023 Room template and bounds
16. ARCH-BL-024 North exit lock/unlock component
17. ARCH-BL-025 Room controller vertical slice
18. ARCH-BL-015 Warrior attack prototype
19. ARCH-BL-027 Score counter
20. ARCH-BL-028 Run coin counter
21. ARCH-BL-029 Run result model
22. ARCH-BL-035 ClassSelect UI binding
23. ARCH-BL-036 Game HUD binding
24. ARCH-BL-037 GameOver UI binding
25. ARCH-BL-041 Debug playtest controls
26. ARCH-BL-042 QA vertical slice checklist
27. ARCH-BL-030 Save data service
28. ARCH-BL-031 Coin banking and high score submission
29. ARCH-BL-032 Upgrade data and purchase rules
30. ARCH-BL-039 UpgradeMenu UI binding
31. ARCH-BL-013 Class combat data model
32. ARCH-BL-016 Projectile foundation
33. ARCH-BL-017 Archer attack
34. ARCH-BL-018 Mage attack
35. ARCH-BL-021 Dasher enemy
36. ARCH-BL-022 Shooter enemy
37. ARCH-BL-026 Room enemy scaling
38. ARCH-BL-033 Upgrade effect application
39. ARCH-BL-034 MainMenu UI binding
40. ARCH-BL-038 Pause overlay behavior
41. ARCH-BL-040 Asset import and placeholder conventions
42. ARCH-BL-008 Editor debug input fallback
43. ARCH-BL-043 Android build smoke
44. ARCH-BL-044 Release candidate validation

## 6. Technical Risks

- Object layers and collision matrix are a current blocker; poor setup will cause combat, projectiles, exits, and UI raycasts to conflict.
- Portrait room framing may not work with default camera or room size and needs early validation in Game view.
- Safe area and joystick zones can obscure gameplay if implemented late.
- Save data and GameOver banking have exact timing requirements; adding them after UI is complete may cause rework.
- Pause abandon behavior can accidentally bank coins or submit high score unless run lifecycle is explicit.
- Projectile logic must support both player and enemy projectiles without cross-damaging incorrect targets.
- Enemy scaling depends on all enemy prefabs and room spawn rules; it should follow the vertical slice, not precede it.
- Input System defaults may not match the desired touch/joystick architecture and need early smoke testing.
- Generated or obsolete landscape assets may be accidentally wired into portrait scenes if asset conventions are not documented.
- Android build settings currently appear default-oriented and must be corrected before release validation.

## 7. Recommended Implementation Sequence

1. Establish Unity baseline and portrait Android settings.
2. Resolve layers, sorting layers, and collision matrix.
3. Build scene flow skeleton.
4. Add portrait Canvas, SafeAreaRoot, and virtual joystick foundation.
5. Create player prefab, movement, health, and class selection state.
6. Add shared damage payload and EnemyBase.
7. Implement Grunt and Room 1 vertical slice with locked north exit.
8. Add Warrior attack, score counter, run coin counter, HUD binding, and GameOver stats.
9. Add debug playtest controls and QA vertical-slice checklist.
10. Add save data, coin banking, high score, upgrade definitions, and UpgradeMenu.
11. Expand combat to Archer and Mage.
12. Add projectile foundation, Dasher, Shooter, and full room scaling.
13. Apply upgrade effects and class specials.
14. Complete MainMenu, Pause Overlay, UI state polish, and asset conventions.
15. Run Android build smoke.
16. Run release candidate validation against GDD and UI/UX acceptance criteria.
