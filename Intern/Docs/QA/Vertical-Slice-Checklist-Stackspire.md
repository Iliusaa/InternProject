# Stackspire Vertical Slice QA Checklist

Owner: [[QA]]
Source task: T42
Date: 2026-05-22
Status: Ready for execution

## Scope

This checklist verifies the first playable Stackspire vertical slice after T40 GameOver flow and T41 save persistence:

`MainMenu -> ClassSelect -> Game -> clear room -> advance -> die -> GameOver -> Restart`

Primary expected Room 1 values:

- Spawned enemies: 2 Grunts.
- Score after both Grunts die and the room clears: 65.
- Coins after both Grunts die: 2.
- Rooms Climbed before entering the first north exit: 0.
- Rooms Climbed after entering the first north exit and then dying in Room 2: 1.

## Test Environment

- Unity project: `InternUnity/`.
- Scene flow: `MainMenu`, `ClassSelect`, `Game`, `GameOver`.
- Target form factor: portrait Android phone using 1080 x 1920 reference bounds.
- Acceptable execution targets for this slice: Unity Play Mode for functional smoke, Android device for portrait safe-area and touch validation.
- Record screenshots or clips for any failed visual, layout, or control test.

## Debug Playtest Controls

Available partial debug aids:

- `SceneNavigator` supports GameOver debug loading in `Game` through the configured `G` key and `DebugGameOverButton`.
- `RunScoreCounter` exposes `debugCurrentRunScore` in the inspector.
- `RunCoinCounter` exposes `debugCurrentRunCoins` in the inspector.
- `WarriorAttack` draws temporary attack-arc debug rays when `drawDebugArc` is enabled.
- `SelectedClassDebugDisplay` shows the selected class in `Game`.
- `SaveDebugControls` has inspector context menu actions to refresh and reset save data.

Missing Coder follow-up:

- Add `Assets/Scripts/Debug/DebugPlaytestControls.cs` or equivalent with commands to damage player, kill all enemies, and print run state.
- Optional but useful: expose a room-clear shortcut and a save-clear button in a debug-only QA panel.

The missing full debug controls do not block this checklist because the T42 deliverable only requires recording their absence.

## Scene Flow

- [ ] Given the app starts from `MainMenu`, when the scene loads, then Start Run is visible and no critical UI is clipped by portrait safe areas.
- [ ] Given `MainMenu`, when Start Run is selected, then `ClassSelect` loads.
- [ ] Given `ClassSelect`, when Warrior is selected, then the selected class state is visible or inspectable as Warrior.
- [ ] Given Warrior is selected, when Start Run is selected, then `Game` loads.
- [ ] Given `Game` has loaded, when the HUD appears, then hearts, score, room, coins, movement joystick, and aim joystick are visible without incoherent overlap.
- [ ] Given `GameOver` is reached by player death, when Restart is selected, then the flow returns to `ClassSelect`.
- [ ] Given `GameOver` is reached by player death, when Main Menu is selected, then the flow returns to `MainMenu`.

## Movement And Controls

- [ ] Given the player is in `Game`, when the left virtual joystick is dragged upward, then the player moves upward.
- [ ] Given the player is in `Game`, when the left virtual joystick is dragged left or right, then the player moves horizontally.
- [ ] Given the player is in `Game`, when the left virtual joystick is released, then movement input returns to zero and the player stops accelerating from joystick input.
- [ ] Given Play Mode editor fallback is active, when WASD is used, then player movement still responds for QA without mobile touch input.
- [ ] Given the portrait HUD is visible, when both joysticks are idle, then joystick visuals do not hide the north exit, player spawn, or active enemies.
- [ ] Given an Android phone with top or bottom safe areas, when the HUD is shown, then joystick touch areas and top HUD controls remain inside safe-area bounds.

## Warrior Attack And Grunt Death

- [ ] Given Warrior is selected and a Grunt is inside the short aim arc, when the right aim joystick is held toward that Grunt, then Warrior attacks repeatedly by cooldown.
- [ ] Given a Grunt is inside the Warrior 180-degree arc, when an attack fires, then the Grunt takes damage.
- [ ] Given a Grunt is outside or behind the Warrior 180-degree arc, when an attack fires, then that Grunt does not take damage from that swing.
- [ ] Given multiple Grunts are inside the arc, when one swing fires, then multiple Grunts can be damaged by the same swing.
- [ ] Given the right aim joystick is released, when cooldown time passes, then no new Warrior attacks start.
- [ ] Given a Grunt reaches 0 health, when death resolves, then the Grunt is removed or visibly inactive and no longer counts as an active enemy.

## Room 1 Clear And North Exit

- [ ] Given `Game` starts Room 1, when spawned enemies are counted, then exactly 2 Grunts are active.
- [ ] Given Room 1 still has at least one active Grunt, when the player enters the north exit trigger, then the exit rejects advancement and Room remains 1.
- [ ] Given the first Room 1 Grunt dies, when HUD updates, then score is 20 and coins are 1.
- [ ] Given the second Room 1 Grunt dies, when room clear resolves, then score is 65 and coins are 2.
- [ ] Given both Room 1 Grunts are dead, when the room clear event resolves, then the north exit changes to its unlocked visual state.
- [ ] Given the north exit is unlocked, when the player enters it, then Room updates from 1 to 2.
- [ ] Given the player enters the unlocked north exit, when Room 2 starts, then score remains 65 and no extra score is awarded for advancing.
- [ ] Given Room 2 starts, when the north exit state is checked, then it is locked again until the new room is cleared.

## HUD Values

- [ ] Given a fresh run starts, when the HUD appears, then score shows `Score 0000`, room shows `Room 1`, and coins show `Coins 000`.
- [ ] Given the player kills one Grunt, when the HUD updates, then score shows 20 and coins show 1.
- [ ] Given the player clears Room 1, when the HUD updates, then score shows 65 and coins show 2.
- [ ] Given the player advances to Room 2, when the HUD updates, then room shows `Room 2`.
- [ ] Given the player takes non-lethal Grunt contact damage, when damage resolves, then health/hearts decrease by 1 and the player is not immediately damaged again during the invulnerability window.
- [ ] Given HUD text changes during combat, when enemies and player are moving, then dynamic text remains readable and does not overlap controls.

## Death And GameOver

- [ ] Given the player dies in Room 1 before entering the north exit, when GameOver opens, then Rooms Climbed shows 0.
- [ ] Given the player dies after clearing Room 1 but before entering the north exit, when GameOver opens, then Final Score shows 65, Coins Earned shows 2, and Rooms Climbed shows 0.
- [ ] Given the player dies after advancing to Room 2, when GameOver opens, then Rooms Climbed shows 1.
- [ ] Given Grunt contact is the killing hit, when GameOver opens, then Killed By shows `Grunt` or the current implemented Grunt damage-source label.
- [ ] Given a run ends with 2 current-run coins, when GameOver opens, then Total Banked Coins includes the newly deposited 2 coins exactly once.
- [ ] Given GameOver stats are displayed, when the screen is inspected, then Final Score, Rooms Climbed, Coins Earned, Banked Coins, Killed By, Restart, and Main Menu are visible.
- [ ] Given GameOver has rendered once, when navigating away and back through a new run, then stale previous run stats are not shown before the new run ends.

## Save Persistence Smoke

- [ ] Given no save exists or save was reset, when save data is loaded, then high score and total banked coins start at 0.
- [ ] Given a run ends with score 65 and 2 coins, when GameOver opens, then high score is at least 65 and total banked coins increase by 2.
- [ ] Given Play Mode is stopped and started after a saved run, when save data is read, then high score and total banked coins persist.
- [ ] Given save data is reset through `SaveDebugControls`, when save data is loaded again, then high score and total banked coins return to 0.

## Generated Asset Coverage

- [ ] Given generated primary button art is used in scene buttons, when buttons are viewed in portrait, then button text remains dynamic and readable.
- [ ] Given generated joystick base art is used for movement and aim controls, when combat is active, then the bases do not obscure player, enemy, projectile, or exit readability.
- [ ] Given generated north-exit locked/unlocked assets are used, when the exit changes state, then locked and unlocked states are distinguishable without relying only on color.
- [ ] Given generated GameOver stat panel art is used, when GameOver stats render, then dynamic text stays readable against the panel.
- [ ] Given generated Warrior slash art is used, when attacks fire, then slash feedback communicates the attack without hiding Grunts or collision outcomes.

Generated asset follow-ups to keep visible:

- `ui_joystick_thumb` is still missing and currently represented by a placeholder.
- Some full-screen/generated screen mockups remain reference-only because baked layout or static text would reduce dynamic text readability.
- Continue rejecting any generated asset that contains baked score, coins, room, killed-by, button, or upgrade text.

## Portrait Device And Safe Area

- [ ] Given a 9:16 portrait target, when each scene is viewed, then no critical text, buttons, joystick zones, or HUD values are clipped.
- [ ] Given a 9.5:20 portrait target, when each scene is viewed, then top HUD and bottom joysticks remain inside safe areas.
- [ ] Given a 10:21 portrait target, when each scene is viewed, then the combat lane remains clear and controls remain reachable.
- [ ] Given Android gesture navigation or a bottom safe area, when joysticks are used, then touch controls are not blocked by the system gesture area.

## Known Out Of Scope For This Slice

- Archer and Mage combat behavior beyond class selection state.
- Dasher and Shooter enemy behavior.
- Upgrade menu purchase flow and upgrade effects.
- Pause overlay behavior and Pause Restart discard behavior, unless implemented by a later task.
- Audio feedback.
- Automated Unity Test Framework coverage.
- Final art polish for all UI, characters, rooms, and VFX.
- Full Android build certification or store-readiness testing.

## Failure Reporting

For each failed checklist item, create a bug handoff in `Intern/Tasks/Open/` with:

1. Steps to reproduce.
2. Expected result.
3. Actual result.
4. Screenshot or screen recording path, or `not captured` if the failure is code/data-only.
5. Severity: Critical, High, Medium, or Low.
