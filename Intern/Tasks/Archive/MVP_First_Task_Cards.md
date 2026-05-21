# MVP First Task Cards

## Global Setup Dependency

After MVP-001 and before any Player, Enemy, Projectile, RoomBounds, Exit, or gameplay prefab implementation, run `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md`. It implements Architect decision `D02` for Unity Layers, Sorting Layers, tags, prefab groups, and the Physics2D collision matrix.

# MVP-001

## Status

Done on 2026-05-21. Audit note: `Intern/Docs/MVP-001_Unity_Baseline_Audit.md`.

## Goal

Audit the current `InternUnity/` project and establish a clean runnable baseline for MVP implementation.

## Context

The Unity project is currently near-baseline with URP 2D settings, `SampleScene`, default Input System actions, and no visible MVP gameplay scripts or prefabs. This card verifies the project can be safely built on before gameplay work starts.

## Files Likely Involved

- `InternUnity/Assets/`
- `InternUnity/Assets/Scenes/`
- `InternUnity/ProjectSettings/`
- `InternUnity/Packages/manifest.json`
- Optional audit note under `Intern/Tasks/Open/` or `Intern/Docs/`

## Implementation Steps

1. Open or inspect the Unity project structure.
2. Verify packages, active input backend, URP 2D assets, and existing scenes.
3. Create missing project folders: `Assets/Scripts`, `Assets/Prefabs`, `Assets/ScriptableObjects`, `Assets/Generated`, `Assets/UI`, `Assets/Audio`, and `Assets/Tests` if needed.
4. Confirm the current scene enters Play Mode without console errors.
5. Document any blocking setup gaps found during the audit.

## Acceptance Criteria

- `InternUnity/` has the required MVP folder structure.
- The project enters Play Mode without setup-related console errors.
- Current Unity package/input/render pipeline state is documented.
- No gameplay behavior is introduced by this card.

## Test Instructions

Open `InternUnity` in Unity, load the current scene, enter Play Mode, and check the Console for errors.

## Dependencies

None.

## Out Of Scope

- Scene flow.
- Gameplay implementation.
- Android build production.
- Final project settings polish.

# MVP-002

## Status

Done on 2026-05-21. Created `MainMenu`, `ClassSelect`, `Game`, and `GameOver` scene flow skeleton with `SceneNavigator`.

## Goal

Create the initial MVP scene bootstrap with MainMenu, ClassSelect, Game, and GameOver scenes.

## Context

The MVP needs a basic scene path before gameplay systems can be tested end to end. This card creates the skeleton flow only, using placeholder UI and buttons.

## Files Likely Involved

- `InternUnity/Assets/Scenes/MainMenu.unity`
- `InternUnity/Assets/Scenes/ClassSelect.unity`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Scenes/GameOver.unity`
- `InternUnity/Assets/Scripts/SceneFlow/SceneNavigator.cs`
- `InternUnity/ProjectSettings/EditorBuildSettings.asset`

## Implementation Steps

1. Create the four MVP scenes.
2. Add all four scenes to build settings in flow order.
3. Implement a simple `SceneNavigator` MonoBehaviour with methods for loading MainMenu, ClassSelect, Game, and GameOver.
4. Add placeholder buttons to MainMenu, ClassSelect, Game, and GameOver.
5. Wire MainMenu Start to ClassSelect.
6. Wire ClassSelect Start to Game.
7. Add a temporary debug button/key in Game to load GameOver.
8. Wire GameOver Restart to ClassSelect and Main Menu to MainMenu.

## Acceptance Criteria

- MainMenu loads ClassSelect.
- ClassSelect loads Game.
- Game can load GameOver through a temporary debug trigger.
- GameOver can load ClassSelect and MainMenu.
- All scenes are in build settings.

## Test Instructions

Enter Play Mode from MainMenu and click through MainMenu -> ClassSelect -> Game -> GameOver -> ClassSelect -> Game.

## Dependencies

- MVP-001.

## Out Of Scope

- Final UI layout.
- UpgradeMenu.
- Pause overlay.
- Real death handling.
- Save data.

# MVP-003

## Status

Done on 2026-05-21. Created `Assets/Prefabs/UI/PortraitCanvasRoot.prefab` and verified MVP scene Canvas roots use 1080 x 1920 Scale With Screen Size settings.

## Goal

Create a reusable portrait Canvas root for MVP UI screens.

## Context

The UI/UX spec requires portrait phone layout at 1080 x 1920 with Canvas Scaler set to Scale With Screen Size. This card creates the common Canvas setup, separate from safe-area behavior.

## Files Likely Involved

- `InternUnity/Assets/Scenes/MainMenu.unity`
- `InternUnity/Assets/Scenes/ClassSelect.unity`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Scenes/GameOver.unity`
- `InternUnity/Assets/Prefabs/UI/PortraitCanvasRoot.prefab`

## Implementation Steps

1. Create a `PortraitCanvasRoot` prefab with Canvas, Canvas Scaler, and Graphic Raycaster.
2. Set Canvas to Screen Space - Overlay.
3. Set Canvas Scaler to Scale With Screen Size.
4. Set Reference Resolution to `1080 x 1920`.
5. Set Match Width Or Height to `0.5`.
6. Add the prefab or equivalent scene root to the current MVP scenes.

## Acceptance Criteria

- A reusable portrait Canvas root exists.
- Canvas reference resolution is `1080 x 1920`.
- Canvas Scaler match value is `0.5`.
- Placeholder UI appears correctly in portrait Game view.

## Test Instructions

Set Game view to 1080 x 1920 and verify placeholder buttons render inside the portrait frame in each MVP scene.

## Dependencies

- MVP-002.

## Out Of Scope

- Safe-area resizing.
- Final screen layouts.
- HUD binding.
- Virtual joystick logic.

# MVP-004

## Goal

Implement safe-area support for portrait UI.

## Context

All edge UI, menu headers, HUD, bottom buttons, and joystick touch zones must respect phone safe areas. This card adds the reusable safe-area behavior only.

## Files Likely Involved

- `InternUnity/Assets/Scripts/UI/SafeAreaRoot.cs`
- `InternUnity/Assets/Prefabs/UI/PortraitCanvasRoot.prefab`
- MVP scene UI roots

## Implementation Steps

1. Create `SafeAreaRoot` MonoBehaviour.
2. On enable and resolution/safe-area change, adjust the attached `RectTransform` anchors to match `Screen.safeArea`.
3. Add `SafeAreaRoot` as a child under the portrait Canvas.
4. Move placeholder screen content under `SafeAreaRoot`.
5. Keep implementation generic and reusable across scenes.

## Acceptance Criteria

- `SafeAreaRoot` stretches to `Screen.safeArea`.
- UI children remain visible within safe area.
- Behavior works when Game view aspect changes.
- No screen-specific UI logic is embedded in `SafeAreaRoot`.

## Test Instructions

Test Game view at 1080 x 1920 and a taller phone aspect. Verify placeholder controls remain inside the visible safe region.

## Dependencies

- MVP-003.

## Out Of Scope

- Final menu layout.
- HUD binding.
- Device-specific QA pass.

# MVP-005

## Goal

Implement a reusable virtual joystick component.

## Context

The MVP requires lower-left movement stick and lower-right aim/attack stick. This card implements the core joystick behavior without connecting it to player movement or combat.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Input/VirtualJoystick.cs`
- `InternUnity/Assets/Prefabs/UI/VirtualJoystick.prefab`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `VirtualJoystick` MonoBehaviour using pointer down, drag, and pointer up events.
2. Expose normalized direction, analog magnitude, and held state.
3. Add serialized active radius and dead zone fields.
4. Reset output to zero when released.
5. Create a placeholder joystick prefab with base and thumb visuals.
6. Add two joystick instances to Game scene: move left, aim right.

## Acceptance Criteria

- Joystick outputs direction and magnitude while dragged.
- Joystick held state is true while pressed and false when released.
- Thumb visual returns to center on release.
- Two joystick instances can operate independently.

## Test Instructions

Enter Play Mode in Game scene, drag each joystick, and inspect live output in Inspector or debug text.

## Dependencies

- MVP-004.

## Out Of Scope

- Player movement.
- Combat firing.
- Final joystick art.

# MVP-006

## Goal

Create an input abstraction for movement and aim/attack.

## Context

Gameplay components should not directly know whether input came from mobile joystick or editor fallback. This card creates a small input bridge consumed by player movement and combat.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Input/PlayerInputReader.cs`
- `InternUnity/Assets/Scripts/Input/VirtualJoystick.cs`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `PlayerInputReader` MonoBehaviour.
2. Reference movement joystick and aim joystick through serialized fields.
3. Expose read-only movement vector, aim vector, and attack held state.
4. Add editor fallback for WASD movement.
5. Add editor fallback for aim/attack using mouse or a simple key-held direction.
6. Keep all values normalized and safe when joystick references are missing.

## Acceptance Criteria

- Movement vector is available to gameplay code.
- Aim vector and attack-held state are available to gameplay code.
- WASD movement works in editor.
- Mobile joystick input remains supported.
- No gameplay movement or combat is implemented in this component.

## Test Instructions

Enter Play Mode and verify movement/aim/attack values change with joystick input and editor fallback.

## Dependencies

- MVP-005.

## Out Of Scope

- Player movement.
- Attack cooldowns.
- Input rebinding.

# MVP-007

## Goal

Implement player movement using `Rigidbody2D`.

## Context

The GDD requires analog movement, horizontal 0.8x multiplier, vertical 1.0x multiplier, and diagonal normalization after axis multipliers.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Player/PlayerMovement.cs`
- `InternUnity/Assets/Prefabs/Player.prefab`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create a placeholder Player prefab with `Rigidbody2D`, `Collider2D`, and placeholder sprite.
2. Create `PlayerMovement` MonoBehaviour.
3. Reference `PlayerInputReader`.
4. Apply movement in physics update through `Rigidbody2D`.
5. Serialize base move speed.
6. Apply horizontal multiplier `0.8`.
7. Apply vertical multiplier `1.0`.
8. Normalize diagonal after applying axis multipliers.

## Acceptance Criteria

- Player moves from input.
- Partial analog tilt moves slower than full tilt.
- Full horizontal movement is slower than full vertical movement.
- Diagonal movement does not exceed intended speed.
- Movement uses `Rigidbody2D`, not transform-only movement.

## Test Instructions

In Game scene, move using WASD and joystick. Compare horizontal and vertical travel over a fixed duration.

## Dependencies

- MVP-006.

## Out Of Scope

- Room bounds.
- Animation.
- Upgrade speed modifiers.
- Enemy collision behavior.

# MVP-008

## Goal

Implement the player HP and damage system.

## Context

The run ends when player health reaches 0. GameOver must know what killed the player. This card creates the player health behavior and events only.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Combat/DamagePayload.cs`
- `InternUnity/Assets/Scripts/Player/PlayerHealth.cs`
- `InternUnity/Assets/Prefabs/Player.prefab`

## Implementation Steps

1. Create a `DamagePayload` struct/class with damage amount and source label.
2. Create `PlayerHealth` MonoBehaviour.
3. Add serialized max hearts defaulting to 5.
4. Track current hearts.
5. Implement `TakeDamage(DamagePayload payload)`.
6. Add 0.5 sec default invulnerability after damage.
7. Expose health changed and died events.
8. Store killed-by source from lethal damage.

## Acceptance Criteria

- Player starts with 5 hearts by default.
- Damage removes hearts.
- Invulnerability prevents rapid repeated damage.
- Death event fires once at 0 health.
- Death event includes killed-by source.

## Test Instructions

Use a temporary debug key or inspector method to apply damage repeatedly and verify health, invulnerability, and death event behavior.

## Dependencies

- MVP-007.

## Out Of Scope

- HUD hearts.
- GameOver scene transition.
- Toughness upgrade.
- Warrior armor special.

# MVP-009

## Goal

Implement the basic enemy base component.

## Context

Enemies need shared health, damage receiving, death events, type labels, and hooks for score/coins/room clear. This card does not implement AI.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Enemies/EnemyBase.cs`
- `InternUnity/Assets/Scripts/Combat/DamagePayload.cs`
- `InternUnity/Assets/Prefabs/Enemies/EnemyBase.prefab`

## Implementation Steps

1. Create `EnemyBase` MonoBehaviour.
2. Add serialized enemy type label.
3. Add serialized max health.
4. Track current health.
5. Implement damage receiving using `DamagePayload`.
6. Fire death event exactly once.
7. Disable or destroy enemy on death.
8. Create a placeholder enemy prefab.

## Acceptance Criteria

- Enemy can receive damage.
- Enemy dies when health reaches 0.
- Death event fires exactly once.
- Enemy type label is available to listeners.
- Placeholder prefab exists.

## Test Instructions

Place an enemy in Game scene, apply debug damage, and verify it dies and fires death once.

## Dependencies

- MVP-008.

## Out Of Scope

- Enemy AI.
- Contact damage.
- Score and coins.
- Room spawning.

# MVP-010

## Goal

Implement basic enemy chase behavior for Grunt.

## Context

The first playable vertical slice needs Grunts that walk directly toward the player and damage on contact.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Enemies/GruntChase.cs`
- `InternUnity/Assets/Prefabs/Enemies/Grunt.prefab`
- `InternUnity/Assets/Prefabs/Player.prefab`

## Implementation Steps

1. Create `GruntChase` MonoBehaviour.
2. Reference the player target through serialized field or scene setup.
3. Move toward player using `Rigidbody2D`.
4. Serialize move speed.
5. On contact with player, call `PlayerHealth.TakeDamage` with source label `Grunt`.
6. Ensure damage respects player invulnerability.
7. Create Grunt prefab using EnemyBase plus GruntChase.

## Acceptance Criteria

- Grunt moves toward player.
- Grunt damages player on contact.
- Damage source label is `Grunt`.
- Grunt can die through EnemyBase damage.
- No Dasher or Shooter behavior is included.

## Test Instructions

Place Player and Grunt in Game scene. Enter Play Mode and verify the Grunt chases, damages, and can be killed through debug damage.

## Dependencies

- MVP-009.

## Out Of Scope

- Room spawning.
- Enemy scaling.
- Dash or ranged attacks.

# MVP-011

## Goal

Implement a basic room manager for the first playable room.

## Context

Room 1 must spawn 2 Grunts, track active enemies, and emit room-clear state when all enemies are dead.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Rooms/RoomManager.cs`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Prefabs/Enemies/Grunt.prefab`

## Implementation Steps

1. Create `RoomManager` MonoBehaviour.
2. Add serialized enemy prefab reference.
3. Add serialized spawn point list.
4. Spawn 2 Grunts for Room 1.
5. Track spawned active enemies.
6. Subscribe to enemy death events.
7. Fire room clear event when all active enemies are dead.
8. Track current room number starting at 1.

## Acceptance Criteria

- Room 1 spawns exactly 2 Grunts.
- RoomManager tracks active enemies.
- Room clear event fires exactly once when both Grunts die.
- Current room number starts at 1.

## Test Instructions

Start Game scene, kill both Grunts using debug damage, and verify room clear event/log fires once.

## Dependencies

- MVP-010.

## Out Of Scope

- North exit behavior.
- Room scaling.
- Dasher/Shooter spawning.
- Room art polish.

# MVP-012

## Goal

Implement locked north exit logic.

## Context

The north exit is locked while enemies remain and unlocks when RoomManager reports room clear. Entering the unlocked exit advances room state.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Rooms/NorthExit.cs`
- `InternUnity/Assets/Scripts/Rooms/RoomManager.cs`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `NorthExit` MonoBehaviour.
2. Add locked/unlocked state.
3. Start locked.
4. Subscribe to RoomManager room-clear event and unlock.
5. Ignore or reject player trigger while locked.
6. On unlocked player trigger, notify RoomManager to advance.
7. Add placeholder visual/debug state for locked/unlocked.
8. Update RoomManager to increment room number and respawn first-slice enemies on advance.

## Acceptance Criteria

- Exit starts locked.
- Player cannot advance through locked exit.
- Exit unlocks after all enemies die.
- Entering unlocked exit increments room number.
- Advancing does not grant score by itself.

## Test Instructions

Try entering the north exit before clearing enemies, then clear enemies and enter again. Verify room number advances only after unlock.

## Dependencies

- MVP-011.

## Out Of Scope

- Full room scaling.
- Door art.
- Exit locked toast UI.

# MVP-013

## Goal

Implement the current-run coin counter.

## Context

Every enemy kill awards 1 current-run coin automatically. Physical coin pickup and coin magnet are out of MVP.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Run/RunCoinCounter.cs`
- `InternUnity/Assets/Scripts/Enemies/EnemyBase.cs`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `RunCoinCounter` MonoBehaviour.
2. Subscribe to enemy death events from RoomManager or spawned enemies.
3. Add 1 current-run coin per enemy death.
4. Expose coin changed event.
5. Reset current-run coins on new run start.
6. Add debug inspector display or log.

## Acceptance Criteria

- Each enemy death adds +1 current-run coin.
- Current-run coin count updates immediately on enemy death.
- Current-run coins can reset at run start.
- No pickup interaction is required.

## Test Instructions

Kill both Room 1 Grunts and verify current-run coins equal 2.

## Dependencies

- MVP-011.

## Out Of Scope

- Banked coins.
- Greed bonus.
- Save data.
- Coin UI art.

# MVP-014

## Goal

Implement the run score counter.

## Context

Enemy kills grant +20 score. Room clear grants +25 score immediately when the last enemy dies. Entering the north exit grants no score.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Run/RunScoreCounter.cs`
- `InternUnity/Assets/Scripts/Rooms/RoomManager.cs`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `RunScoreCounter` MonoBehaviour.
2. Subscribe to enemy death events.
3. Add +20 score per enemy death.
4. Subscribe to room clear event.
5. Add +25 score on room clear.
6. Expose score changed event.
7. Reset score on new run start.

## Acceptance Criteria

- Each enemy death adds +20 score immediately.
- Room clear adds +25 score once.
- Entering north exit adds no score.
- Clearing Room 1 with 2 Grunts results in 65 score.

## Test Instructions

Kill both Room 1 Grunts and verify score equals 65 before entering the north exit. Enter exit and verify score remains 65.

## Dependencies

- MVP-011.
- MVP-012.

## Out Of Scope

- High score.
- GameOver result display.
- Score float animations.

# MVP-015

## Goal

Implement a basic Game HUD prototype.

## Context

The vertical slice needs visible health, score, room, and current-run coins. Final UI art and polish are not required.

## Files Likely Involved

- `InternUnity/Assets/Scripts/UI/GameHudBinder.cs`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Prefabs/UI/PortraitCanvasRoot.prefab`

## Implementation Steps

1. Add placeholder HUD text under SafeAreaRoot in Game scene.
2. Create `GameHudBinder` MonoBehaviour.
3. Bind to `PlayerHealth`, `RunScoreCounter`, `RunCoinCounter`, and `RoomManager`.
4. Display Hearts, Score, Room, and Coins.
5. Place HUD values in portrait-safe zones: hearts top-left, score/room top-center, coins top-right.
6. Keep joystick visuals in lower-left and lower-right.

## Acceptance Criteria

- HUD displays current hearts.
- HUD displays score.
- HUD displays current room.
- HUD displays current-run coins.
- HUD updates when values change.
- Central combat lane remains readable.

## Test Instructions

Damage player, kill enemies, clear room, and advance room. Verify all HUD values update.

## Dependencies

- MVP-004.
- MVP-012.
- MVP-013.
- MVP-014.

## Out Of Scope

- Final UI sprites.
- HUD animations.
- Pause overlay.
- Upgrade UI.

# MVP-016

## Goal

Implement basic class selection data.

## Context

ClassSelect must record Warrior, Archer, or Mage and pass that choice into Game. Warrior is enough for the first combat prototype, but the data must support all three MVP classes.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Classes/PlayerClassId.cs`
- `InternUnity/Assets/Scripts/Classes/ClassSelectionState.cs`
- `InternUnity/Assets/Scripts/UI/ClassSelectBinder.cs`
- `InternUnity/Assets/Scenes/ClassSelect.unity`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `PlayerClassId` enum with Warrior, Archer, Mage.
2. Create runtime `ClassSelectionState`.
3. Default selection to Warrior.
4. Add placeholder class buttons in ClassSelect.
5. Update selection when class buttons are clicked.
6. Ensure Start Run loads Game with selected class available.
7. Add temporary debug display in Game showing selected class.

## Acceptance Criteria

- Warrior, Archer, and Mage can be selected.
- Warrior is default if no explicit selection occurs.
- Game scene can read selected class.
- Selected class survives scene transition from ClassSelect to Game.

## Test Instructions

Select each class in ClassSelect, start Game, and verify the Game debug display shows the selected class.

## Dependencies

- MVP-002.

## Out Of Scope

- Final class card layout.
- Archer/Mage combat.
- Class upgrades.

# MVP-017

## Goal

Implement the Warrior attack prototype.

## Context

The first playable combat loop uses Warrior melee. Holding the right aim stick should repeatedly attack at cooldown; releasing stops attacks.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Combat/WarriorAttack.cs`
- `InternUnity/Assets/Scripts/Combat/DamagePayload.cs`
- `InternUnity/Assets/Prefabs/Player.prefab`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create `WarriorAttack` MonoBehaviour.
2. Reference `PlayerInputReader`.
3. Serialize damage defaulting to 2.
4. Serialize cooldown defaulting to 0.55 sec.
5. Serialize arc angle defaulting to 180 degrees.
6. Serialize short melee range.
7. While attack is held, perform attacks by cooldown.
8. Detect enemies in the aim-direction arc.
9. Apply `DamagePayload` to hit enemies.
10. Add temporary debug visualization or logs for hits.

## Acceptance Criteria

- Holding aim stick attacks repeatedly.
- Releasing aim stick stops new attacks.
- Attack uses the aim direction.
- Enemies inside the short 180-degree arc take damage.
- Enemies outside the arc do not take damage.
- Multiple enemies in the arc can be hit.

## Test Instructions

Place Grunts around the player, hold aim toward them, and verify only enemies in arc take damage.

## Dependencies

- MVP-006.
- MVP-009.
- MVP-016.

## Out Of Scope

- Archer attack.
- Mage attack.
- Final slash VFX.
- Audio.
- Power upgrade.

# MVP-018

## Goal

Implement basic GameOver flow and run stats transfer.

## Context

When player health reaches 0, GameOver must appear before any menu transition and show final score, rooms climbed, current-run coins, total banked coins placeholder/stub, and killed-by source.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Run/RunResult.cs`
- `InternUnity/Assets/Scripts/Run/RunEndController.cs`
- `InternUnity/Assets/Scripts/UI/GameOverBinder.cs`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Scenes/GameOver.unity`

## Implementation Steps

1. Create `RunResult` data type.
2. Create simple runtime holder for last run result.
3. Create `RunEndController`.
4. Subscribe to `PlayerHealth` death event.
5. On death, collect score, rooms climbed, current-run coins, and killed-by source.
6. Set total banked coins to current stub/save value if available, otherwise 0.
7. Load GameOver scene.
8. Create `GameOverBinder` to display run result values.
9. Wire Restart to ClassSelect and Main Menu to MainMenu.

## Acceptance Criteria

- Player death loads GameOver.
- GameOver shows final score.
- GameOver shows rooms climbed.
- GameOver shows current-run coins.
- GameOver shows killed-by source.
- Death in Room 1 before north exit shows Rooms Climbed 0.
- Restart returns to ClassSelect.

## Test Instructions

Start Game, take lethal Grunt damage before clearing Room 1, and verify GameOver shows Rooms Climbed 0 and Killed By Grunt.

## Dependencies

- MVP-008.
- MVP-012.
- MVP-013.
- MVP-014.

## Out Of Scope

- Permanent coin banking.
- High score.
- Upgrade routing.
- New High Score badge.

# MVP-019

## Goal

Implement a save system stub for MVP progression values.

## Context

The first GameOver flow can use a stub, but the project needs a save API early so later coin banking, upgrades, and high score do not rewrite UI and run flow.

## Files Likely Involved

- `InternUnity/Assets/Scripts/Save/SaveData.cs`
- `InternUnity/Assets/Scripts/Save/SaveService.cs`
- `InternUnity/Assets/Scripts/Debug/SaveDebugControls.cs`

## Implementation Steps

1. Create `SaveData` with high score, total banked coins, upgrade levels, and class special flags.
2. Create `SaveService` with Load, Save, and Reset methods.
3. Use PlayerPrefs or local JSON for stub persistence.
4. Load default values when no save exists.
5. Add simple methods to get/set high score and banked coins.
6. Add debug reset method available in editor.

## Acceptance Criteria

- Save data loads with default values on first run.
- High score can be set and saved.
- Total banked coins can be set and saved.
- Data persists after stopping and starting Play Mode if using PlayerPrefs, or after app restart if built.
- Save reset clears stored values.
- Save service does not depend on UI scene objects.

## Test Instructions

Set high score and coins through debug controls, save, stop Play Mode, restart Play Mode, and verify values load.

## Dependencies

- MVP-001.

## Out Of Scope

- Full upgrade purchase UI.
- Coin banking exact timing.
- Greed bonus.
- Cloud save.

# MVP-020

## Goal

Create the debug QA checklist for the first playable vertical slice.

## Context

Before expanding systems, the team needs a repeatable smoke test for the first playable slice: scene flow, movement, Warrior attack, Grunt, room clear, score, coins, HUD, death, and GameOver.

## Files Likely Involved

- `Intern/Docs/QA/` or `Intern/Tasks/Open/`
- `InternUnity/Assets/Scripts/Debug/DebugPlaytestControls.cs`
- `InternUnity/Assets/Scenes/Game.unity`

## Implementation Steps

1. Create a markdown checklist for first vertical-slice QA.
2. Add expected values for Room 1: 2 Grunts, 2 coins, 65 score after clear.
3. Include test path: MainMenu -> ClassSelect -> Game -> clear room -> advance -> die -> GameOver -> Restart.
4. Add debug playtest controls if missing: damage player, kill all enemies, print run state.
5. Include known out-of-scope gaps for this slice.

## Acceptance Criteria

- A QA checklist file exists.
- Checklist covers scene flow.
- Checklist covers joystick/player movement.
- Checklist covers Warrior attack and Grunt death.
- Checklist covers room clear and locked/unlocked exit.
- Checklist covers score, coins, HUD, death, and GameOver stats.
- Debug controls are available or explicitly listed as not yet implemented.

## Test Instructions

Run the checklist manually from MainMenu and record pass/fail notes for each vertical-slice behavior.

## Dependencies

- MVP-018.

## Out Of Scope

- Automated tests.
- Android release candidate validation.
- Archer, Mage, Dasher, Shooter.
- Upgrade menu QA.
