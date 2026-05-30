# Game Design Document - Stackspire

> Written by: [[GameDesigner]]
> Validation state: approved by [[BA]] for portrait MVP downstream routing
> Last updated: 2026-05-30

---

## Quick Links
- [[#Elevator Pitch]]
- [[#Design Pillars]]
- [[#Target Feeling]]
- [[#Core Loop]]
- [[#Platform & Controls]]
- [[#Game Structure]]
- [[#Player Classes]]
- [[#Player Stats]]
- [[#Enemies]]
- [[#Scoring]]
- [[#Coins & Meta-Progression]]
- [[#Scenes]]
- [[#Systems]]
- [[#UI]]
- [[#Art Style]]
- [[#Audio]]
- [[#MVP Scope]]
- [[#Out of Scope (v1)]]
- [[#Balance Defaults]]
- [[#Acceptance Criteria For BA Review]]
- [[#Review Notes]]

---

## Elevator Pitch
Stackspire is a portrait-only Android roguelite tower climber where the player chooses a class, clears stacked enemy rooms, earns score and coins from kills, and spends banked coins on permanent upgrades to climb farther on future runs.

[[#Quick Links|Back to Top]]

---

## Design Pillars
- **Instant readability:** enemies, exits, attacks, coins, health, and danger must stay readable on a phone held upright.
- **Short runs:** one run should feel meaningful in 3-7 minutes.
- **Simple mastery:** movement and aiming are simple, while positioning, range, and room-to-room survival create skill expression.
- **Always progressing:** even failed runs earn coins that improve future attempts.

[[#Quick Links|Back to Top]]

---

## Target Feeling
The game should feel quick, punchy, and approachable. The player should think, "one more room," then "one more run." Combat should be simple enough for casual play but distinct enough that [[#Warrior]], [[#Archer]], and [[#Mage]] each feel like a different route through the same tower.

[[#Quick Links|Back to Top]]

---

## Core Loop
1. Player starts a run by choosing [[#Warrior]], [[#Archer]], or [[#Mage]].
2. Player enters a tower room, moves with one lower-left virtual movement stick, and attacks automatically through target-assisted class attacks.
3. Each enemy kill adds score and automatically awards its coin reward.
4. When all enemies in the room are defeated, the north exit opens.
5. Player moves north to enter the next room stacked above the current room.
6. Rooms get harder as the player climbs.
7. Run ends when player health reaches 0.
8. The GameOver screen appears first, showing final score, rooms climbed, current-run coins collected, what killed the player, and restart/menu/upgrade options.
9. Earned coins are banked through the GameOver flow; if the player opens upgrades, banked coins can be spent on [[#Permanent Upgrade Tracks|permanent upgrades]] before starting another run.

**Core loop in one sentence:** clear enemies in the current room, collect coins, go north to the next harder room, and use permanent upgrades to climb farther next run.

[[#Quick Links|Back to Top]]

---

## Platform & Controls
- **Platform:** Android mobile phones.
- **Orientation:** portrait-only.
- **Reference dimension bounds:** 1080 x 1920.
- **Development input:** keyboard WASD for movement. Editor/debug attack uses the same auto-attack rules as mobile; optional mouse/keyboard debug input may be used only to inspect target selection and must not be required for normal play.
- **Mobile input:** one lower-left virtual stick for analog movement.
- **Attack input:** normal attacks are automatic. When at least one valid enemy target exists, the selected class attacks at its cooldown using the target-assisted aiming rules below. There is no dedicated aim joystick and no required attack button in MVP.
- **Target frame rate:** 60 fps.
- **Camera:** fixed 2D three-quarter top-down camera per room; no scrolling inside a room.
- **Phone ergonomics:** primary thumb controls sit in the lower third of the screen, outside the combat-critical center lane and clear of system safe areas.

### Control Map
| Action | Keyboard / Debug | Android Phone |
|--------|------------------|---------------|
| Move up | W | Left virtual stick up |
| Move left | A | Left virtual stick left |
| Move down | S | Left virtual stick down |
| Move right | D | Left virtual stick right |
| Aim / attack | Auto-attack with optional debug target inspection | Automatic target-assisted attacks; no aim stick |
| Pause | Esc | Pause button near upper safe area |

### Portrait Control Requirements
- The movement stick is anchored in the lower-left safe zone.
- The lower-right area does not contain a second virtual stick in MVP.
- Stick visuals must not cover the player spawn lane, the north exit, or enemy telegraphs.
- The playable room is framed above the lower control zone, with enough lower margin that the player's thumb does not hide nearby enemies.
- Movement analog magnitude is respected; partial stick tilt moves slower than full tilt.
- Full vertical movement uses a 1.0x multiplier and full horizontal movement uses a 0.8x multiplier. Diagonal movement must be normalized after these axis multipliers are applied.

### Single-Joystick Aim And Attack Rules
- **Player intent:** the player focuses on positioning, spacing, dodging, and choosing when to approach or kite. The game handles attack firing and target assistance so combat stays readable on portrait phones.
- **Facing direction:** while moving, the player's facing direction is the normalized movement direction after axis multipliers. When movement returns to zero, the player keeps the last non-zero facing direction. If no facing direction exists yet, default facing is north/up.
- **Valid target:** an alive, active enemy in the current room that can receive player damage. Warrior valid targets must be inside melee acquisition range: Warrior slash range plus a 0.25 character-height buffer. Archer and Mage valid targets are alive active enemies inside the current room bounds; MVP rooms do not require manual line-of-sight aiming.
- **Auto-attack trigger:** if at least one valid enemy target exists and the class cooldown is ready, the player performs one normal attack automatically. If no valid enemy exists, no normal attack is created.
- **Target priority:** when multiple enemies are valid, prefer enemies in front of the player's current facing direction within a 120-degree cone. Within that cone, pick the closest enemy. If no enemy is in that cone, pick the closest valid enemy overall.
- **Soft target lock:** after an attack chooses a target, keep that target for up to 0.75 seconds if it remains valid. Break the lock immediately if the target dies, leaves the room, becomes invalid, or another enemy moves dangerously close inside the Warrior's melee range.
- **Attack direction:** attacks use the direction from the player to the chosen target at the moment the attack is fired. If the target becomes invalid during startup, fall back to the current facing direction for that one attack.
- **Standing still:** standing still does not stop attacking. The player keeps facing the last movement direction and continues auto-attacking valid targets by cooldown using the same target priority and soft-lock rules.
- **No precision touch aiming:** MVP must not require drag aiming, a second stick, or precise tap targeting during combat.
- **Anti-frustration rule:** target assistance should prefer immediate threats close to the player over distant enemies when the player would otherwise attack away from a nearby danger.
- **Kiting limit:** Archer and Mage can attack while moving, but their cooldowns and projectile speeds remain the primary limit on kiting. Do not add a manual fire requirement to solve kiting.

[[#Quick Links|Back to Top]]

---

## Game Structure
The tower is built from separate rectangular rooms placed vertically. Each cleared room unlocks a north doorway. Entering the doorway loads or activates the next room above it.

### Room Rules
- Player spawns near the south entrance.
- North exit is locked while enemies remain.
- Enemies spawn when the player enters the room.
- Coins are added automatically to the current run coin counter when an enemy drops them.
- Player cannot return to previous rooms during a run.
- Rooms climbed is part of the final score summary.
- Rooms climbed counts completed room transitions, not the current room number.
- A player who dies in Room 1 before entering the north exit has climbed 0 rooms.
- A cleared room only counts as climbed after the player enters the unlocked north exit and the next room starts.

### Portrait Room Framing
- Rooms remain vertical tower chambers with a visible south entrance and north exit.
- The room's combat area must be readable inside the 1080 x 1920 reference frame.
- The north exit must sit high enough to be visible above HUD elements.
- The south entrance and player spawn area must sit above the bottom control zone.
- Enemy spawn positions must avoid the immediate thumb-control zones so enemies are not hidden by controls at spawn time.
- Projectiles and dash paths use the active room bounds and stop on room walls.

### Run End
A run ends when the player's health reaches 0. The GameOver screen is shown before any automatic menu transition. The player keeps all coins earned during the run after the GameOver flow banks them.

### Death Summary
The GameOver screen must show:
- Final score.
- Rooms climbed.
- Current-run coins collected.
- Total banked coins after deposit.
- What killed the player, using the damage source that reduced health to 0.

### Restart From Pause
Restart is enabled from the Pause Overlay. Restart from Pause abandons the current run immediately, discards current-run coins, does not submit the current run score to high score, and starts the restart flow without showing GameOver.

[[#Quick Links|Back to Top]]

---

## Player Classes
The player chooses one class at the start of each run. Classes share the same movement and health rules but differ by attack range, rhythm, and positioning style.

| Class | Weapon | Attack Type | Strength | Weakness |
|-------|--------|-------------|----------|----------|
| [[#Warrior]] | Sword | Short melee arc | Safest close-range damage | Must stand near enemies |
| [[#Archer]] | Bow | Straight projectile | Long range and fast shots | Lower hit damage |
| [[#Mage]] | Staff | Slower magic projectile | Higher damage and pierce potential | Slower attack rhythm |

### Warrior
- **Attack:** short sword slash toward the current target-assisted attack direction.
- **Range:** short melee arc.
- **Damage:** high.
- **Rate:** medium.
- **Intended play:** dodge into openings, slash enemies, retreat before being surrounded.
- **Single-joystick behavior:** Warrior only attacks when an enemy is inside melee acquisition range. Target priority favors the closest enemy in front of the player's facing direction, but immediately favors a close enemy inside melee range if that enemy is the most dangerous nearby threat.
- **Standing still:** Warrior keeps the last facing direction and continues slashing valid nearby targets by cooldown.

### Archer
- **Attack:** arrow projectile toward the current target-assisted attack direction.
- **Range:** long.
- **Damage:** medium-low.
- **Rate:** fast.
- **Intended play:** keep distance, kite enemies, pick targets before they close in.
- **Single-joystick behavior:** Archer auto-fires when any enemy is available in the room and line/path rules allow a shot. Movement direction biases target selection, but closest valid target fallback keeps Archer usable while dodging.
- **Standing still:** Archer keeps firing at the current soft-locked or closest valid target by cooldown.

### Mage
- **Attack:** magic bolt projectile toward the current target-assisted attack direction.
- **Range:** medium-long.
- **Damage:** high.
- **Rate:** slow.
- **MVP special:** magic bolts penetrate unlimited enemies until hitting a wall after the one-time Mage special upgrade.
- **Intended play:** line up enemies, fire carefully, use spacing to cover slower attacks.
- **Single-joystick behavior:** Mage auto-fires at a valid target by cooldown. Movement direction biases target selection so the player can line up shots through positioning, but the nearest valid enemy fallback prevents missed input precision from dominating.
- **Standing still:** Mage keeps the current soft target if valid; otherwise fires toward the highest-priority valid target.

### Normal Attacks And Class Specials
- Normal attacks require no dedicated attack button in MVP.
- Class specials do not add a second control:
  - Warrior special remains passive armor at the start of each room.
  - Archer special fires the second arrow in the same direction as the auto-fired first arrow after 0.08 sec.
  - Mage special makes auto-fired bolts penetrate enemies until hitting a wall.
- Future active class specials, if added later, need a separate design pass and are out of MVP scope.

[[#Quick Links|Back to Top]]

---

## Player Stats
| Stat | Starting Value | Notes |
|------|----------------|-------|
| Health | 5 hearts | Taking damage removes 1 heart |
| Move speed | 1.0x | Modified by [[#Permanent Upgrade Tracks]] |
| Attack damage | Class-specific | Modified by [[#Permanent Upgrade Tracks]] |
| Attack cooldown | Class-specific | Modified by [[#Permanent Upgrade Tracks]] |
| Coin magnet radius | Not in MVP | Coins are awarded automatically on enemy death |

[[#Quick Links|Back to Top]]

---

## Enemies
MVP uses three enemy types. They should be readable with distinct silhouettes and simple behavior.

| Enemy | Behavior | Score | Coin Drop |
|-------|----------|-------|-----------|
| [[#Enemy Scaling|Grunt]] | Walks directly toward player | 20 | 1 |
| [[#Enemy Scaling|Dasher]] | Pauses, then lunges in a straight line | 20 | 1 |
| [[#Enemy Scaling|Shooter]] | Wanders slowly in random directions and fires slow projectiles from anywhere in the room | 20 | 1 |

### Enemy Scaling
- Room 1 starts with 2 Grunts.
- Rooms 1-3 use Grunts only.
- Room 4 adds 1 Dasher to the room mix.
- Rooms 6+ use 2 Dashers where Dashers are included.
- Room 7 adds 1 Shooter to the room mix.
- Rooms 8+ use 2 Shooters where Shooters are included.
- Rooms 10+ use any random enemy mix that obeys the room cap and per-type caps; no fixed weights are required for MVP.
- **Room 10+ caps:** maximum 10 total enemies by default, maximum 10 Grunts, maximum 4 Dashers, maximum 4 Shooters.
- The maximum total enemies per room must be stored as a tunable value so it can be changed later.
- Every 5 rooms starting at room 10, enemy health increases by +1.

[[#Quick Links|Back to Top]]

---

## Scoring
Score is earned by killing enemies and clearing rooms. Score does not buy upgrades; it is used for run ranking and high score.

| Action | Score |
|--------|-------|
| Kill any enemy | +20 |
| Clear room | +25 |

Final score = enemy kill score + room clear score.

### Score Timing Rules
- Enemy kill score is added immediately when an enemy reaches 0 health.
- Clear room score is added immediately when the last enemy in the current room reaches 0 health and the north exit unlocks.
- No score is awarded for entering the north exit or advancing to the next room in MVP.
- Room numbering is 1-based. Room 1 is the first combat room of a run.
- If the last enemy dies before the player reaches 0 health, the room clear score is awarded even if the player dies before entering the next room.

[[#Quick Links|Back to Top]]

---

## Coins & Meta-Progression
Coins are earned by killing enemies and are banked after the run ends. Coins are spent in the [[#Upgrade Menu]]. Upgrades affect all future runs unless marked class-specific.

Every enemy rewards 1 coin per kill in MVP.

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
| Warrior | 1 armor hit that refreshes at the start of each room, carries over if unused, is capped at 1, and absorbs damage before health |
| Archer | Double shot: each attack fires one arrow, then fires a second arrow in the same direction after 0.08 sec |
| Mage | Penetration: magic bolts pass through unlimited enemies until hitting a wall |

### Upgrade Calculation Rules
- Power and Agility bonuses stack additively from base values for MVP.
- Power and Agility values must remain editable for future balance changes.
- Greed coin bonus is calculated once when the run ends and fractional bonus coins round down.

### Economy Goals
- A short failed run should buy or noticeably progress toward one early upgrade.
- A strong run should buy one mid-tier upgrade.
- Coins should reward kills, not passive survival.

[[#Quick Links|Back to Top]]

---

## Scenes
| Scene | Purpose |
|-------|---------|
| MainMenu | Start run, open upgrades, view high score |
| ClassSelect | Choose [[#Warrior]], [[#Archer]], or [[#Mage]] |
| UpgradeMenu | Spend banked coins on permanent upgrades |
| Game | Tower rooms, combat, score, coins, health |
| GameOver | Final score, rooms climbed, coins earned, restart/menu |

[[#Quick Links|Back to Top]]

---

## Systems
| System | Description | Priority |
|--------|-------------|----------|
| Player Movement | WASD-style debug movement and mobile analog movement with collision | MVP |
| Class Combat | Warrior slash, Archer arrow, Mage bolt | MVP |
| Room Flow | Spawn room, lock exit, clear enemies, unlock north exit, advance | MVP |
| Enemy AI | Grunt chase, Dasher lunge, Shooter ranged attack | MVP |
| Health & Damage | Player hearts, armor, enemy health, death handling | MVP |
| Score | Add score from enemy kills and room clears | MVP |
| Coin Economy | Automatic coin awards from enemy kills, bank after run | MVP |
| Permanent Upgrades | Upgrade menu and saved permanent stat bonuses | MVP |
| Save Data | High score, total coins, purchased upgrades | MVP |
| UI/HUD | Portrait health, score, coins, room number, pause, virtual sticks | MVP |
| Audio Feedback | Attack, hit, coin, room clear, game over sounds | MVP |

[[#Quick Links|Back to Top]]

---

## UI
All UI must be designed for portrait phones using the 1080 x 1920 reference bounds. Menus and overlays should respect top and bottom safe areas and avoid placing critical text below thumb controls.

### In-Run HUD
- Hearts sit in the upper-left safe zone.
- Pause sits in the upper-right safe zone.
- Score and room number sit in a compact upper-center stack.
- Current-run coins sit near the top HUD, readable without crowding hearts or pause.
- The central combat lane remains visually clear.
- Movement stick sits lower-left.
- No aim/attack stick is shown in MVP.
- The bottom control zone may use translucent movement-stick visuals but must not hide player damage, enemy telegraphs, or the south entrance.

### Main Menu
- Title and primary Start action are centered in the upper and middle screen area.
- Upgrade and secondary actions sit below Start as portrait-friendly stacked buttons.
- High score and total coins remain visible without requiring horizontal side panels.

### Class Select
- Warrior, Archer, and Mage choices are arranged as vertically scroll-free portrait cards or a compact stacked selector.
- The selected class must be obvious through frame, accent color, and weapon silhouette.
- Start Run remains reachable near the lower-middle area above the system safe zone.

### Upgrade Menu
- Shows total banked coins at the top.
- Lists [[#Permanent Upgrade Tracks]] in a vertical list.
- Each upgrade row shows name, level, effect, cost, and buy button.
- Disabled buy button if the player cannot afford the next level.
- The list may scroll vertically if phone safe areas or text size require it.

### Pause Overlay
- Dims the active game view.
- Shows Resume, Restart, and Main Menu actions in a centered vertical stack.
- Restart must clearly represent abandoning the current run and discarding current-run coins.

### Game Over
- Shows final score.
- Shows rooms climbed.
- Shows current-run coins collected.
- Shows total banked coins after deposit.
- Shows what killed the player.
- Provides Restart, Upgrades, and Main Menu actions as portrait stacked buttons.

[[#Quick Links|Back to Top]]

---

## Art Style
- **Style:** original 2D dark fantasy dungeon cartoon with grotesque hand-drawn proportions, thick ink outlines, scuffed texture, and vulnerable small heroes. The mood should feel grim, strange, and absurd rather than clean heroic fantasy.
- **Reference intent:** use compact dungeon-crawler readability references for simple expressive forms, tiny player avatars, and grotesque enemy silhouettes; use dark fantasy contrast references for oppressive shadows, candlelit warmth, and desaturated blood tones. Do not copy exact characters, UI, logos, enemy designs, icons, or proprietary symbols from reference games.
- **Camera view:** three-quarter top-down perspective for rooms, characters, enemies, projectiles, VFX, and world props. Strict top-down art is not used for MVP unless an implementation placeholder explicitly requires it.
- **Portrait composition:** rooms, backgrounds, screen art, and UI must be composed for a tall 1080 x 1920 phone frame with clear top HUD space, bottom control space, and an unobstructed central combat lane.
- **Characters:** tiny, fragile, doll-like adventurers with oversized heads, anxious expressions, and oversized class weapons. Warrior, Archer, and Mage must remain readable at mobile scale through weapon silhouette first, costume detail second.
- **Enemies:** warped dungeon creatures with clear black-outline silhouettes, uneven anatomy, and unsettling but stylized shapes.
- **Horror / gore ceiling:** maximum MVP gore is brief stylized blood particles when the player or enemies are hit. No visible body horror, dismemberment, exposed organs, lingering gore piles, or realistic wound detail.
- **Rooms:** stone chambers stacked vertically, with crooked masonry, grime, candle pools, heavy corner shadows, and a clear south entrance and north exit.
- **Effects:** sword arc slash, arrow streak, magic bolt glow, coin sparkle, damage flash, and room-clear door glow. Effects should use brighter values than the background so combat remains readable against the dark palette.
- **Mobile readability:** backgrounds stay low-saturation and low-detail near the combat plane; interactables, enemies, projectiles, coins, hearts, and exits use strong value contrast and thick outlines.
- **UI coverage:** the dark fantasy palette applies to every screen and UI asset, including Main Menu, Class Select, Upgrade Menu, HUD, Pause Overlay, and Game Over.
- **Class accents:** Warrior uses dark dried-crimson tones only; Archer uses sickly green; Mage uses occult blue-violet.
- **Damage color rule:** bright red is reserved for enemy hits, player damage, danger telegraphs, urgent UI feedback, and damage particles. Warrior class UI and weapon accents must use darker crimson so they do not compete with damage readability.
- **Chroma key color rule:** `#00FF00` is reserved only for raw generated sprite assets that intentionally use a chroma-key background. Do not use `#00FF00` in gameplay art, UI, VFX, materials, particles, indicators, icons, palette swatches, or final in-game visuals.

### Dark Fantasy Palette Direction
| Palette Role | Colors | Usage |
|--------------|--------|-------|
| Ink / void | `#0E0B10`, `#17131A`, `#262129` | outlines, deepest shadows, room corners |
| Dungeon stone | `#343038`, `#4B4447`, `#6D6461` | floors, walls, props, neutral UI panels |
| Dark crimson / Warrior | `#6E151D`, `#9E2527` | Warrior accents, dried blood tones, dark red class identity |
| Bright damage red | `#D64A32` | enemy hits, player damage, danger telegraphs, urgent UI feedback |
| Torch / coin gold | `#8F5A24`, `#C18432`, `#E0B75C` | coins, torches, unlocked doors, reward emphasis |
| Sickly green | `#35533B`, `#587642`, `#8A9B55` | poison, enemy accents, Archer accent option |
| Occult blue-violet | `#26364F`, `#415C78`, `#7B6A9B` | Mage attacks, magic UI accents, rare highlights |
| Bone / parchment | `#B8A487`, `#D6C6A1` | readable UI text fields, heart outlines, small highlights |
| Chroma key green | `#00FF00` | raw generated sprite backgrounds only; forbidden in final game visuals |

### FLUX Prompt Direction
Original 2D dark fantasy mobile game art, grotesque hand-drawn three-quarter top-down dungeon crawler, tall portrait phone composition, compact stone tower chamber, thick black ink outlines, tiny vulnerable heroic character with oversized weapon, exaggerated enemy silhouettes, scuffed painterly texture, oppressive shadows, candle amber, dark dried crimson, bright red hit particles only, bruised violet, ash gray, sickly green accents, readable combat shapes, high contrast, transparent background for characters and enemies where applicable, no text, no body horror, no realistic gore.

### Art Reference Guardrails
- Treat *The Binding of Isaac* and *Darkest Dungeon* as broad readability, mood, and palette references only.
- All Stackspire characters, enemies, UI icons, room props, and symbols must be original.
- Asset prompts should describe the desired visual traits directly instead of asking FLUX to reproduce either reference game.

[[#Quick Links|Back to Top]]

---

## Audio
- **BGM:** light fantasy action loop, upbeat but not intense.
- **Warrior attack SFX:** short metal slash.
- **Archer attack SFX:** bow twang and arrow hit.
- **Mage attack SFX:** soft magic cast and impact.
- **Enemy hit SFX:** quick impact pop.
- **Coin award SFX:** bright chime.
- **Room clear SFX:** satisfying door unlock tone.
- **Game over SFX:** short low sting.

[[#Quick Links|Back to Top]]

---

## MVP Scope
The MVP is playable when the player can choose a class, enter rooms, kill enemies, earn score and coins, die, spend permanent upgrades, and restart stronger.

- [ ] Portrait-only Android phone presentation using 1080 x 1920 reference bounds.
- [ ] Three selectable classes: Warrior, Archer, Mage.
- [ ] One room template that can be reused with escalating enemy spawns.
- [ ] North exit unlocks only after all enemies die.
- [ ] At least three enemy types: Grunt, Dasher, Shooter.
- [ ] Score increases from enemy kills and room clears.
- [ ] Coins are awarded automatically from enemy kills and are banked after the run.
- [ ] Permanent upgrade menu with Toughness, Power, Agility, Greed, and one class special upgrade per class.
- [ ] Save high score, total coins, and purchased upgrade levels.
- [ ] Game over screen with score, rooms climbed, coins earned, total banked coins, what killed the player, restart, upgrades, and main menu.

[[#Quick Links|Back to Top]]

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

[[#Quick Links|Back to Top]]

---

## Balance Defaults
These values are recommended MVP defaults for implementation and QA. Values that affect balance, enemy counts, rewards, upgrade costs, movement, attack timing, health, projectile behavior, and room scaling should be stored as tunable settings where practical so they can be changed later without rewriting system logic.

| Value | Default |
|-------|---------|
| Reference dimension bounds | 1080 x 1920 |
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
| Enemy kill score | 20 score points |
| Room clear score | 25 score points |
| Base coin unit value | 1 coin |
| Horizontal movement multiplier | 0.8x |
| Vertical movement multiplier | 1.0x |
| Damage invulnerability window | 0.5 sec |
| Archer double-shot delay | 0.08 sec |
| Shooter random movement interval | 2 sec |

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
| Projectile max range | Full visible room until wall collision |
| Projectile hit area | Enemy mesh plus 15 pixels in all directions |
| Projectile wall behavior | Destroyed when hitting room walls |
| Shooter projectile speed | 0.5 character height/sec |

### MVP Enemy Defaults
| Enemy | Health | Movement | Attack |
|-------|--------|----------|--------|
| Grunt | 6 | Moves toward player at 1.2x base player speed | Contact damage only |
| Dasher | 5 | Stationary outside dash; 2 sec windup, 2 sec dash, 2 sec cooldown; stops on wall | Contact damage only |
| Shooter | 4 | Picks a random movement direction, moves slowly at 0.5x base player speed for 2 sec, then picks another random direction; repeats while alive | Can shoot anywhere in the active room; fires every 3 sec; projectile deals 1 heart |

[[#Quick Links|Back to Top]]

---

## Acceptance Criteria For BA Review
- The GDD defines Stackspire as portrait-only Android phone gameplay.
- The active reference dimension bounds are 1080 x 1920.
- The core loop can be tested with placeholder art.
- The win-forward action is always moving north after clearing a room.
- Death condition is explicit: player health reaches 0.
- Score and coin currencies have separate purposes.
- Permanent upgrades are small, understandable, and saved between runs.
- MVP scope fits a small Unity prototype without requiring procedural generation, bosses, or complex content pipelines.
- Controls, HUD, menus, safe areas, room framing, and art composition are written for phone use in portrait orientation.

## MVP System Acceptance Criteria
- On Android phones, the game runs in portrait orientation using 1080 x 1920 reference bounds.
- The movement stick is lower-left and is the only virtual joystick required for MVP combat.
- The lower-right HUD area does not require an aim/attack stick.
- The selected class attacks automatically at its cooldown when a valid enemy target exists.
- Aim direction is target-assisted using movement/facing bias, closest-target fallback, and the soft target-lock rules in [[#Single-Joystick Aim And Attack Rules]].
- Standing still preserves last facing direction and does not stop auto-attacks against valid targets.
- Warrior, Archer, and Mage each use the single-joystick target-assisted rules while preserving their class ranges, cooldowns, damage profiles, and passive special upgrades.
- At full stick tilt, horizontal movement uses 0.8x speed and vertical movement uses 1.0x speed; diagonal movement is normalized after those axis multipliers are applied.
- Enemy kill, room clear, current-run coins, room number, and health changes are visible in HUD values or device logs.
- Any killed enemy adds +20 score and +1 run coin.
- When the last enemy in a room dies, the north exit unlocks and +25 score is added.
- When the player enters the unlocked north exit, the next room starts, room number updates, and rooms climbed increases by 1; no score is awarded for climbing to the next room in MVP.
- If the player dies in Room 1 before entering the north exit, GameOver shows Rooms Climbed as 0.
- When player health reaches 0, the run ends, the GameOver screen shows final score, rooms climbed, current-run coins collected, what killed the player, and total banked coins after deposit.
- When Restart is selected from the Pause Overlay during an active run, current-run coins are discarded, the current score is not submitted to high score, and GameOver is not shown.
- After app restart, high score, total banked coins, and purchased upgrade levels remain saved.

## Blocked Requirement Clarifications
- **Object layer rule:** stakeholder confirmed this is a Unity technical layer request, not a design-facing GDD rule. Architect must define the exact Unity layers, sorting layers, collision layers, tags, or prefab grouping needed for MVP before Coder implementation.

[[#Quick Links|Back to Top]]

---

## Review Notes
### GameDesigner Portrait Rewrite - 2026-05-19
Status: ready for [[BA]] review.

#### Update Notes
- Rewrote the active GDD as a portrait-only Android phone design.
- Set the active reference dimension bounds to 1080 x 1920.
- Reframed controls, HUD, menus, room framing, camera composition, art composition, MVP scope, and system acceptance criteria for portrait phone play.
- Preserved approved gameplay mechanics: class combat, room flow, scoring, coins, permanent upgrades, enemy scaling, death flow, pause restart behavior, and save-data requirements.
- Removed obsolete orientation history from the active document so downstream agents can use this file as the current source of truth.

[[#Quick Links|Back to Top]]

---

> [[BA]]: add clarification questions below this line after review.

### BA Clarification Questions - Portrait Rewrite - 2026-05-19

Status: Answered by stakeholder and applied to GDD. Portrait rewrite approved by BA.

1. Room and camera framing: should the current `12 x 18 world units` room size remain the fixed portrait room size with the whole room visible at once and no camera scrolling, or should GameDesigner replace it with new portrait-specific world dimensions?
2. Bottom control zone gameplay rule: are enemies, projectiles, damage areas, and player movement allowed to pass visually behind the translucent joystick zones, or should the lower control zone be treated as a gameplay exclusion area where enemies do not spawn, aim, or path?
3. Restart flow: when the player taps `Restart` on GameOver or Pause Overlay, should the game restart immediately with the last selected class, or should it return to Class Select before starting the next run?
4. Pause `Main Menu` behavior: if the player taps `Main Menu` from the Pause Overlay during an active run, are current-run coins discarded and current score not submitted, matching Pause Restart behavior?
5. Coin banking timing: are current-run coins deposited immediately when GameOver opens, exactly once, before the GameOver stats render, or are they deposited only after the player taps Restart, Upgrades, or Main Menu?
6. Killed-by display: what exact GameOver labels should be used for death sources such as enemy contact, Dasher contact, Shooter projectile, and simultaneous damage on the same frame?
7. Portrait movement multiplier: what exact horizontal and vertical movement multipliers should be used in the portrait tower layout?

#### Answer Summary
- Room and camera framing: the full room must fit on the mobile portrait screen without camera scrolling. World-unit room dimensions should be adjusted to satisfy that requirement.
- Bottom control zone gameplay rule: enemies, projectiles, damage areas, and player movement are allowed to pass visually behind the translucent joystick zones.
- Restart flow: Restart returns to Class Select before the next run starts.
- Pause Main Menu behavior: tapping Main Menu from Pause discards all current-run coins and does not submit the current run score, matching Pause Restart discard behavior.
- Coin banking timing: current-run coins deposit immediately when GameOver opens, exactly once, before GameOver stats render.
- Killed-by display: GameOver shows the last collision or damage source the game resolves as the killing hit. If damage is simultaneous, the game may use whichever final collision/damage event its resolution order decides killed the player.
- Movement speed multipliers: horizontal movement uses 0.8x, vertical movement uses 1.0x, and diagonal movement is normalized after applying those axis multipliers.

### BA Approval - Portrait Rewrite - 2026-05-19

Status: Approved for downstream UI/UX, Architect, ArtDirector, Coder, and QA routing.

#### Approval Notes
- The portrait-only Android phone requirement is explicit.
- The active reference dimension bounds are 1080 x 1920.
- The full room must fit on the mobile portrait screen without camera scrolling, with world-unit room dimensions adjusted accordingly.
- Bottom joystick zones are translucent UI overlays; gameplay may pass visually behind them.
- Restart and Pause Main Menu abandon the active run as specified.
- GameOver coin deposit timing and killed-by source handling are testable.
- Movement axis multipliers are now exact and QA-verifiable.
- No remaining BA-blocking ambiguity is open in the portrait GDD rewrite.
