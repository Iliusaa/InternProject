# Game Design Document - Stackspire

> Written by: [[GameDesigner]]
> Validated by: [[BA]]
> Last updated: 2026-05-13

---

## Elevator Pitch
Stackspire is a casual 2D roguelite tower-climbing game where the player chooses a class, clears vertically stacked enemy rooms, earns score and coins from kills, and spends coins on permanent upgrades to climb higher on future runs.

---

## Design Pillars
- Instant readability: the player always understands where enemies, exits, attacks, coins, and danger are.
- Short runs: one run should feel meaningful in 3-7 minutes.
- Simple mastery: movement is easy, but positioning, class range, and room-to-room survival create skill expression.
- Always progressing: even a failed run earns coins that improve future attempts.

---

## Target Feeling
The game should feel quick, punchy, and approachable. The player should think, "one more room," then "one more run." Combat should be simple enough for casual play but distinct enough that Warrior, Archer, and Mage each feel like a different route through the same tower.

---

## Core Loop
1. Player starts a run by choosing Warrior, Archer, or Mage.
2. Player enters a tower room, moves with keyboard or left-stick controls, and aims/attacks with mouse or right-stick controls.
3. Each enemy kill adds score and automatically awards its coin reward.
4. When all enemies in the room are defeated, the north exit opens.
5. Player moves north to enter the next room stacked above the current room.
6. Rooms get harder as the player climbs.
7. Run ends when player health reaches 0.
8. Final score is saved, earned coins are banked, and the player returns to the upgrade menu.
9. Player buys permanent upgrades and starts another run.

Core loop in one sentence: clear enemies in the current room, collect coins, go north to the next harder room, and use permanent upgrades to climb farther next run.

---

## Platform & Controls
- Platform: Android, landscape-only layout.
- Development input: keyboard WASD for movement; editor/debug aiming may use mouse or right-stick simulation.
- Mobile input: left virtual stick for analog movement and right virtual stick for aiming/shooting.
- Attack input: attacks autofire while the right aim stick is held; releasing the aim stick stops firing.
- Target frame rate: 60 fps.
- Camera: fixed 2D top-down camera per room; no scrolling inside a room.

### Control Map
| Action | Keyboard | Android |
|--------|----------|---------|
| Move up | W | Left virtual stick up |
| Move left | A | Left virtual stick left |
| Move down | S | Left virtual stick down |
| Move right | D | Left virtual stick right |
| Aim / attack | Mouse or right-stick simulation | Hold right virtual stick |
| Pause | Esc | Pause button |

---

## Game Structure
The tower is built from separate rectangular rooms placed vertically. Each cleared room unlocks a north doorway. Entering the doorway loads or activates the next room above it.

### Room Rules
- Player spawns near the south entrance.
- North exit is locked while enemies remain.
- Enemies spawn when the player enters the room.
- Coins are added automatically to the current run coin counter when an enemy drops them.
- Player cannot return to previous rooms during a run.
- Room count climbed is part of the final score summary.

### Run End
A run ends when the player's health reaches 0. The player keeps all coins earned during the run.

---

## Player Classes
The player chooses one class at the start of each run. Classes share the same movement and health rules but differ by attack range, rhythm, and positioning style.

| Class | Weapon | Attack Type | Strength | Weakness |
|-------|--------|-------------|----------|----------|
| Warrior | Sword | Short melee arc | Safest close-range damage | Must stand near enemies |
| Archer | Bow | Straight projectile | Long range and fast shots | Lower hit damage |
| Mage | Staff | Slower magic projectile | Higher damage and pierce potential | Slower attack rhythm |

### Warrior
- Attack: short sword slash in the facing direction.
- Range: short melee arc.
- Damage: high.
- Rate: medium.
- Intended play: dodge into openings, slash enemies, retreat before being surrounded.

### Archer
- Attack: arrow projectile in the facing direction.
- Range: long.
- Damage: medium-low.
- Rate: fast.
- Intended play: keep distance, kite enemies, pick targets before they close in.

### Mage
- Attack: magic bolt projectile in the facing direction.
- Range: medium-long.
- Damage: high.
- Rate: slow.
- MVP special: magic bolts penetrate unlimited enemies until hitting a wall after the one-time Mage special upgrade.
- Intended play: line up enemies, fire carefully, use spacing to cover slower attacks.

---

## Player Stats
| Stat | Starting Value | Notes |
|------|----------------|-------|
| Health | 5 hearts | Taking damage removes 1 heart |
| Move speed | 1.0x | Modified by permanent upgrades |
| Attack damage | Class-specific | Modified by permanent upgrades |
| Attack cooldown | Class-specific | Modified by permanent upgrades |
| Coin magnet radius | Not in MVP | Coins are awarded automatically on enemy death |

---

## Enemies
MVP uses three enemy types. They should be readable with distinct silhouettes and simple behavior.

| Enemy | Behavior | Score | Coin Drop |
|-------|----------|-------|-----------|
| Grunt | Walks directly toward player | 10 | 1 |
| Dasher | Pauses, then lunges in a straight line | 20 | 2 |
| Shooter | Keeps distance and fires slow projectiles | 30 | 3 |

### Enemy Scaling
- Room 1 starts with 2 Grunts.
- Rooms 1-3 use Grunts only.
- Room 4 adds 1 Dasher to the room mix.
- Rooms 6+ use 2 Dashers where Dashers are included.
- Room 7 adds 1 Shooter to the room mix.
- Rooms 8+ use 2 Shooters where Shooters are included.
- Rooms 10+ use any random enemy mix that obeys the room cap and per-type caps; no fixed weights are required for MVP.
- Room 10+ caps: maximum 10 total enemies by default, maximum 10 Grunts, maximum 4 Dashers, maximum 4 Shooters.
- The maximum total enemies per room must be stored as a tunable value so it can be changed later.
- Every 5 rooms starting at room 10, enemy health increases by +1.

---

## Scoring
Score is earned by killing enemies. Score does not buy upgrades; it is used for run ranking and high score.

| Action | Score |
|--------|-------|
| Kill Grunt | +10 |
| Kill Dasher | +20 |
| Kill Shooter | +30 |
| Clear room | +25 |
| Climb to next room | +10 x room number |

Final score = enemy kill score + room clear score + climb bonus.

### Score Timing Rules
- Enemy kill score is added immediately when an enemy reaches 0 health.
- Clear room score is added immediately when the last enemy in the current room reaches 0 health and the north exit unlocks.
- Climb bonus is awarded when the player enters the north exit and advances to the next room.
- Room numbering is 1-based. Room 1 is the first combat room of a run.
- If the last enemy dies before the player reaches 0 health, the room clear score is awarded even if the player dies before entering the next room.

---

## Coins & Meta-Progression
Coins are earned by killing enemies and are banked after the run ends. Coins are spent in the permanent upgrade menu. Upgrades affect all future runs unless marked class-specific.

### Permanent Upgrade Tracks
| Upgrade | Effect | Levels | Cost Pattern |
|---------|--------|--------|--------------|
| Toughness | +1 max heart | 5 | 25, 50, 100, 175, 275 |
| Power | +10% attack damage | 5 | 30, 60, 120, 210, 330 |
| Agility | +5% move speed | 5 | 20, 45, 90, 160, 250 |
| Greed | +10% coins earned | 5 | 35, 70, 140, 245, 385 |
| Class Special | One class-specific special upgrade | 1 per class | 500 |

### Class Special Upgrades
Each class has one one-time MVP special upgrade that costs 500 coins.

| Class | Special Upgrade |
|-------|-----------------|
| Warrior | Start each room with 1 armor hit |
| Archer | Double shot: each attack fires one arrow, then fires a second arrow in the same direction after 0.08 sec |
| Mage | Penetration: magic bolts pass through unlimited enemies until hitting a wall |

### Economy Goals
- A short failed run should buy or noticeably progress toward one early upgrade.
- A strong run should buy one mid-tier upgrade.
- Coins should reward kills, not passive survival.

---

## Scenes
| Scene | Purpose |
|-------|---------|
| MainMenu | Start run, open upgrades, view high score |
| ClassSelect | Choose Warrior, Archer, or Mage |
| UpgradeMenu | Spend banked coins on permanent upgrades |
| Game | Tower rooms, combat, score, coins, health |
| GameOver | Final score, rooms climbed, coins earned, restart/menu |

---

## Systems
| System | Description | Priority |
|--------|-------------|----------|
| Player Movement | WASD-style 2D movement with collision | MVP |
| Class Combat | Warrior slash, Archer arrow, Mage bolt | MVP |
| Room Flow | Spawn room, lock exit, clear enemies, unlock north exit, advance | MVP |
| Enemy AI | Grunt chase, Dasher lunge, Shooter ranged attack | MVP |
| Health & Damage | Player hearts, enemy health, death handling | MVP |
| Score | Add score from kills, room clears, and climb bonus | MVP |
| Coin Economy | Automatic coin awards from enemy kills, bank after run | MVP |
| Permanent Upgrades | Upgrade menu and saved permanent stat bonuses | MVP |
| Save Data | High score, total coins, purchased upgrades | MVP |
| UI/HUD | Health, score, coins, room number, pause | MVP |
| Audio Feedback | Attack, hit, coin, room clear, game over sounds | MVP |

---

## UI
### In-Run HUD
- Hearts in top-left.
- Score in top-center.
- Current run coins in top-right.
- Room number below score.
- Pause button near top corner on Android.
- Left virtual movement stick bottom-left.
- Right virtual aim/attack stick bottom-right.

### Upgrade Menu
- Shows total banked coins.
- Lists permanent upgrade tracks.
- Each upgrade row shows name, level, effect, cost, and buy button.
- Disabled buy button if the player cannot afford the next level.

---

## Art Style
- Style: clean 2D cartoon fantasy with readable silhouettes, slightly chunky shapes, and high-contrast combat effects.
- Camera view: top-down or three-quarter top-down.
- Palette: deep stone grays for tower floors, warm torch golds, cool blue magic, green enemy accents, red damage flashes.
- Characters: small heroic fantasy avatars with oversized weapons for readability.
- Rooms: square stone chambers stacked vertically, with a clear south entrance and north exit.
- Effects: sword arc slash, arrow streak, magic bolt glow, coin sparkle, room-clear door glow.

### FLUX Prompt Direction
Clean mobile game art, 2D cartoon fantasy tower room, readable top-down stone chamber, warm torchlight, high contrast silhouettes, chunky heroic character proportions, polished casual roguelite style, vibrant but not noisy, transparent background for characters and enemies where applicable.

---

## Audio
- BGM: light fantasy action loop, upbeat but not intense.
- Warrior attack SFX: short metal slash.
- Archer attack SFX: bow twang and arrow hit.
- Mage attack SFX: soft magic cast and impact.
- Enemy hit SFX: quick impact pop.
- Coin award SFX: bright chime.
- Room clear SFX: satisfying door unlock tone.
- Game over SFX: short low sting.

---

## MVP Scope
The MVP is playable when the player can choose a class, enter rooms, kill enemies, earn score and coins, die, spend permanent upgrades, and restart stronger.

- [ ] Three selectable classes: Warrior, Archer, Mage.
- [ ] One room template that can be reused with escalating enemy spawns.
- [ ] North exit unlocks only after all enemies die.
- [ ] At least three enemy types: Grunt, Dasher, Shooter.
- [ ] Score increases from enemy kills and room clears.
- [ ] Coins are awarded automatically from enemy kills and are banked after the run.
- [ ] Permanent upgrade menu with Toughness, Power, Agility, Greed, and one class special upgrade per class.
- [ ] Save high score, total coins, and purchased upgrade levels.
- [ ] Game over screen with score, rooms climbed, coins earned, and restart.

---

## Out of Scope (v1)
- Procedural room layouts beyond simple spawn variations.
- Boss fights.
- Equipment drops.
- Consumable items.
- More than three classes.
- Complex talent trees.
- Multiplayer.
- Online leaderboards.
- Ads, IAP, analytics.
- Narrative campaign.

---

## Balance Defaults
These values are recommended MVP defaults for implementation and QA. Values that affect balance, enemy counts, rewards, upgrade costs, movement, attack timing, health, projectile behavior, and room scaling should be stored as tunable settings where practical so they can be changed later without rewriting system logic.

| Value | Default |
|-------|---------|
| Room size | 12 x 18 world units |
| Player health | 5 hearts |
| Enemy contact damage | 1 heart |
| Warrior damage | 2 |
| Archer damage | 1 |
| Mage damage | 3 |
| Warrior cooldown | 0.55 sec |
| Archer cooldown | 0.35 sec |
| Mage cooldown | 0.85 sec |
| Player move speed | 5 units/sec |
| Base coin unit value | 1 coin |
| Horizontal movement multiplier | 1.0x |
| Vertical movement multiplier | 0.75x |
| Damage invulnerability window | 0.5 sec |
| Archer double-shot delay | 0.08 sec |

### MVP Combat Defaults
| Value | Default |
|-------|---------|
| Movement analog magnitude | Respected; partial stick tilt moves slower than full tilt |
| Warrior slash arc | 180 degrees in aim direction |
| Warrior slash range | 1 character height |
| Warrior slash damage timing | Instant on attack trigger |
| Warrior slash target count | Can hit multiple enemies in the arc |
| Warrior slash animation duration | 0.75 sec |
| Archer projectile speed | 1 character height/sec |
| Archer projectile damage | 1 |
| Mage projectile speed | 1 character height/sec |
| Mage projectile damage | 3 |
| Projectile max range | Full visible room/screen until wall collision |
| Projectile hit area | Enemy mesh plus 15 pixels in all directions |
| Projectile wall behavior | Destroyed when hitting room walls |
| Shooter projectile speed | 0.5 character height/sec |

### MVP Enemy Defaults
| Enemy | Health | Movement | Attack |
|-------|--------|----------|--------|
| Grunt | 6 | Moves toward player at 1.2x base player speed | Contact damage only |
| Dasher | 5 | Stationary outside dash; 2 sec windup, 2 sec dash, 2 sec cooldown; stops on wall | Contact damage only |
| Shooter | 4 | Moves toward player at 0.5x base player speed until player is inside 30% visible-screen attack radius | Fires every 3 sec; projectile deals 1 heart |

---

## Acceptance Criteria For BA Review
- The core loop can be tested with placeholder art.
- The win-forward action is always moving north after clearing a room.
- Death condition is explicit: player health reaches 0.
- Score and coin currencies have separate purposes.
- Permanent upgrades are small, understandable, and saved between runs.
- MVP scope fits a small Unity prototype without requiring procedural generation, bosses, or complex content pipelines.

## MVP System Acceptance Criteria
- On Android, the game runs in landscape layout with the left movement stick bottom-left and the right aim/attack stick bottom-right.
- Holding the right aim stick causes the selected class to attack repeatedly at its cooldown; releasing the right aim stick stops new attacks.
- While moving vertically at full stick tilt, the player moves at 0.75x horizontal full-tilt speed.
- Enemy kill, room clear, climb bonus, current run coins, room number, and health changes are visible in HUD values or device logs.
- A killed Grunt adds +10 score and +1 run coin; a killed Dasher adds +20 score and +2 run coins; a killed Shooter adds +30 score and +3 run coins.
- When the last enemy in a room dies, the north exit unlocks and +25 score is added.
- When the player enters the unlocked north exit, the next room starts and the climb bonus adds `10 x completed room number`.
- When player health reaches 0, the run ends, the GameOver screen shows final score, rooms climbed, and coins earned, and the earned coins are added to banked coins.
- After app restart, high score, total banked coins, and purchased upgrade levels remain saved.

---

> [[BA]]: add clarification questions below this line after review.

---

## BA Review - 2026-05-13

Status: Not approved yet. The core loop is clear enough to prototype with placeholder art, and the MVP direction is reasonable, but several requirements can still be implemented in different ways. These must be resolved before Architect creates implementation cards.

### Validation Notes
- The main loop is testable: choose class, clear room, move north, die, bank coins, buy upgrades, restart.
- The win-forward action is explicit: after enemies are defeated, the player exits north.
- The death condition is explicit: player health reaches 0.
- Score and coins have separate purposes.
- Out-of-scope items are clear enough for MVP boundaries.

### Blocking Clarification Questions
1. How is player facing determined for attacks: last movement direction, current movement direction, nearest enemy, or a separate aim direction?
2. Can the player move diagonally on keyboard and virtual D-pad? If yes, is diagonal movement speed normalized to match cardinal movement speed?
3. What exact behavior should occur while the player holds the attack button: one attack per press, auto-repeat at cooldown, or button hold ignored after the first attack?
4. What are the exact Warrior slash dimensions for MVP: arc angle, range in world units, active duration, and whether one slash can hit multiple enemies?
5. What are the exact Archer and Mage projectile values for MVP: projectile speed, lifetime or max range, collision size, and whether projectiles are destroyed on walls?
6. How often can the player take contact damage while overlapping an enemy: once on first contact, once per enemy cooldown, or every fixed invulnerability window?
7. What are the MVP movement and combat values for each enemy type: health, move speed, attack range, attack cooldown, projectile speed for Shooter, and dash windup/distance/cooldown for Dasher?
8. What is the exact room spawn formula, including the starting enemy count in room 1 and how enemy types are selected after rooms 4 and 7?
9. When is the climb bonus awarded: when the north exit unlocks, when the player enters it, or when the next room starts? Is room numbering 1-based?
10. Does the clear-room score apply to every cleared room, including the room where the player dies if all enemies are defeated before death?
11. Coins are described as touch pickup, but player stats include a coin magnet radius. Is coin magnet behavior in MVP, or should MVP use collision pickup only?
12. How should Greed's +10% coin bonus round fractional coin rewards: round down per pickup, round up per pickup, or apply and round once at run end?
13. Is Class Mastery part of MVP? It appears in permanent upgrades but is omitted from the MVP checklist.
14. How do permanent upgrade modifiers stack: additive from base values, multiplicative per level, or fixed derived values in a table?
15. What observable save-data acceptance criteria should QA use for high score, total coins, and upgrade levels after app restart?

### Required Before Architect Handoff
- Add exact MVP numeric defaults for attack shapes, projectile behavior, enemy behavior, damage cadence, and room spawns.
- Decide whether Class Mastery and coin magnet behavior are in MVP or out of scope.
- Add system-level acceptance criteria that QA can verify from screenshots, HUD values, or device logs.

---

## Stakeholder Clarifications - 2026-05-13

Status: Partial answers received. Superseded by `Stakeholder Clarifications Round 2 - 2026-05-13` below.

### Captured Decisions
- Platform/control framing changes to mobile landscape. The game uses one virtual stick for movement and one virtual stick for aiming/shooting.
- Movement supports analog direction on mobile. Vertical-axis movement should be slower than horizontal-axis movement.
- Attacks autofire in the current aim-stick direction.
- Warrior slash range is about one character height, covers about a 180-degree arc, applies damage instantly, can hit multiple enemies, and plays a slash animation lasting 0.5-1.0 seconds.
- Archer and Mage projectile range covers the full room/screen, projectiles travel at 1 character height per second for MVP unless revised, projectile hit area is enemy mesh plus 15 pixels in all directions, and projectiles are destroyed by room walls.
- Player takes damage on first contact with an enemy.
- Grunt has 6 health, moves at 1.2x base player speed, does not use an attack action, and deals contact damage only.
- Dasher has 5 health, has a 2-second windup, dashes across the whole screen, stops when it hits a wall, and deals contact damage only.
- Shooter projectile speed is 0.5x character height per second.
- Room 1 spawns 2 Grunts.
- Room 4 adds 1 Dasher.
- Room 6 and later spawn 2 Dashers where Dashers are included.
- Room 7 adds 1 Shooter.
- Room 8 and later spawn 2 Shooters where Shooters are included.
- Room 10 and later use random enemy selection, with a maximum of 10 enemies per room and a target average of 8 enemies per room.
- Enemy health increases by +1 every 5 rooms starting at room 10.
- Score bonuses are awarded instantly to the score counter; coins are awarded when collected during play.
- MVP includes one special class upgrade per class, purchased once. Example: Archer double-shot costs 500 coins.

### Remaining BA Questions - Superseded By Round 2
1. Confirm the orientation change: should the GDD replace "portrait-first layout" with "landscape-only mobile layout"?
2. What exact vertical movement speed multiplier should be used: for example, 0.75x vertical speed while horizontal remains 1.0x?
3. Is movement analog magnitude respected, or does any stick tilt move the player at full speed in that direction?
4. What happens when the aim stick is released: stop firing, keep firing in last aim direction, or keep direction but stop firing?
5. For Warrior autofire, does the slash trigger only while the aim stick is held, or also when the aim stick is tapped/flicked?
6. Should Archer and Mage have different projectile speeds, or should both use 1 character height per second in MVP?
7. What are Archer and Mage projectile damage values after applying the existing damage table: Archer 1 and Mage 3?
8. After first contact damage, when can the same enemy damage the player again: after the player separates and touches again, after a fixed invulnerability time, or never from that enemy until room reset?
9. What are Dasher movement speed outside the dash, dash active duration, and cooldown after a dash ends?
10. What are Shooter health, movement behavior, preferred distance, shot cooldown, and projectile damage?
11. You wrote "mage" in room 7 and 8 enemy spawning. Should this be "Shooter" enemy, or is Mage a fourth enemy type?
12. For rooms 10+, what random enemy rules should QA expect: fixed weighted percentages, or any mix capped at 10 enemies?
13. What are the exact one-time class special upgrades for Warrior, Archer, and Mage, including cost and observable effect?
14. Should coin magnet remain out of MVP, since pickup is currently touch-only?
15. Should Greed coin bonus round per pickup or once at run end?

---

## Stakeholder Clarifications Round 2 - 2026-05-13

Status: Most BA blockers resolved. Superseded by `Stakeholder Clarifications Round 3 - 2026-05-13` below.

### Captured Decisions
- Orientation is landscape-only mobile.
- Official MVP movement multipliers are horizontal 1.0x and vertical 0.75x.
- Movement stick analog magnitude affects player speed.
- Releasing the aim stick stops firing completely.
- Warrior slash autofires only while the aim stick is held.
- Archer and Mage projectiles both use the MVP speed of 1 character height per second.
- Archer projectile damage is 1. Mage projectile damage is 3.
- After taking contact damage, the player has 0.5 seconds of invulnerability before the same or another enemy can damage the player again.
- Dasher does not move outside its dash. Dasher windup is 2 seconds, dash active duration is 2 seconds, and post-dash cooldown is 2 seconds.
- Shooter has 4 health, deals 1 heart of projectile damage, fires every 3 seconds, and moves toward the player at 0.5x default player speed until the player is inside attack radius.
- Shooter attack radius is 30% of the visible screen.
- Room 7 and Room 8 use Shooter enemies; "Mage" was a typo and is not a fourth enemy type.
- Room 10+ randomization caps are: maximum 10 total enemies per room, maximum 10 Grunts, maximum 4 Dashers, and maximum 4 Shooters.
- One-time class special upgrades are included in MVP. Each costs 500 coins.
- Warrior special upgrade: starts each room with 1 armor hit.
- Archer special upgrade: double shot.
- Mage special upgrade: attacks penetrate enemies.
- Coins are not touch pickups in MVP. Gold is automatically added to the player when it drops.
- Greed coin bonus is calculated once when the run ends.

### Remaining BA Questions - Superseded By Round 3
1. For rooms 10+, should enemy randomization use fixed weights, or is any random mix valid as long as it obeys the total cap and per-type caps?
2. For Archer double shot, are both arrows fired in the same aim direction, or should they fire with a spread angle? If spread, what angle?
3. For Mage penetration, how many enemies can one attack pass through: exactly 1 extra enemy, or unlimited until it hits a wall?

---

## Stakeholder Clarifications Round 3 - 2026-05-13

Status: Resolved. Superseded by `BA Approval - 2026-05-13` below.

### Captured Decisions
- Rooms 10+ do not need fixed enemy weights for MVP. Any random enemy mix is valid if it obeys the total room cap and per-type caps.
- The default maximum total enemies per room is 10, and this cap must be stored as a tunable value so it can be changed later.
- Archer double shot fires two arrows in the same aim direction, one after the other, not as a spread shot.
- Archer double-shot delay uses the recommended MVP default of 0.08 sec between arrow spawns.
- Mage penetration is unlimited until the projectile hits a wall.
- Future class special behavior, including possible Mage homing projectiles, is allowed to change after MVP. For current MVP implementation, Mage uses unlimited penetration only.
- Projectile speeds, enemy health values, rewards, room caps, upgrade costs, and other balance values use the GDD's recommended MVP defaults and should be implemented as tunable values where practical.

### Remaining BA Question
None.

---

## BA Approval - 2026-05-13

Status: Approved for Architect handoff.

### Approval Notes
- The current MVP requirements have no remaining BA-blocking ambiguities.
- Numeric combat, enemy, scoring, reward, room cap, and upgrade values are approved as recommended MVP defaults, not permanent balance locks.
- Any future class special changes, such as adding Mage homing projectiles, are out of scope for the current MVP cards unless a later task explicitly changes the requirement.

### Architect Handoff Scope
- Create implementation task cards from the approved MVP GDD.
- Preserve balance values as tunable settings where practical.
- Keep first implementation focused on placeholder-art playable systems before polish.
