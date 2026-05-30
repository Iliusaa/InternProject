# Stackspire MVP UI/UX Specification

Owner: [[UIUXDesigner]]
Status: Portrait mobile rewrite
Date: 2026-05-19

## References Read

- `GDD.md`
- `Agents/UIUXDesigner.md`
- `Agents/ArtDirector.md`
- `Core/Conventions.md`
- `Docs/Visual-Design.md`
- `Tasks/Open/UIUX-Rewrite-Spec-Portrait-Mobile-Stackspire.md`

## Scope

This document defines the implementation-ready UI/UX plan for the Stackspire MVP on portrait-only Android phones. It covers:

- Main Menu
- Class Select
- Game HUD
- Pause Overlay
- Upgrade Menu
- Game Over
- reusable components and Unity UI handoff rules

This spec stays inside the approved MVP. It does not add inventory, quests, ads, IAP, battle pass, online leaderboard, extra currencies, XP, gems, skins, daily rewards, boss UI, minimap, equipment, talents, rarity, loot systems, energy, or character skins.

## UX Goals

- A new player can start a run within 5 seconds.
- Class differences are understandable from compact cards without long reading.
- In-run HUD is readable while combat is moving inside a tall phone frame.
- Touch controls are comfortable for one-stick portrait phone play, with the right side of the screen kept free of a required second joystick.
- The player always understands health, Score, Room, Coins, pause state, and whether the north exit is locked.
- Permanent upgrade states are clear: affordable, unavailable, maxed, or bought.
- Game Over shows the run result and pushes the player toward Restart or Upgrades.
- All UI can be built with Unity Canvas, reusable prefabs, and placeholder art.

## UX Flow Map

Primary journey:

```text
Main Menu
  -> Start Run
  -> Class Select
  -> Game HUD
  -> Pause Overlay optional
  -> Game Over
  -> Restart -> Class Select -> Game HUD
  -> Upgrades -> Upgrade Menu -> Class Select -> Game HUD
  -> Main Menu
```

Edge cases:

```text
0 Coins
  -> Upgrade Menu shows Coins: 0
  -> Buy buttons disabled with "Need X"

Cannot afford upgrade
  -> Row remains visible
  -> Buy button disabled
  -> Cost text remains readable

Upgrade maxed
  -> Row shows "Maxed"
  -> Next effect replaced by "Max level"

New High Score
  -> Game Over shows "New High Score"
  -> Final Score receives short emphasis animation

Class Special locked
  -> Class Special row shows 500 Coins cost
  -> Buy disabled if Coins are below 500

Class Special bought
  -> Class Special row shows "Bought"
  -> Button disabled in bought/maxed style

Room 1 death before north exit
  -> Game Over shows Rooms Climbed: 0

Pause restart
  -> Current-run coins are discarded
  -> Current score is not submitted as High Score
  -> Game Over is skipped
```

## Global Layout Rules

### Reference Frame

- Design reference: 1080 x 1920, portrait phone.
- Unity Canvas: Screen Space - Overlay for MVP unless Architect chooses Camera canvas for integration reasons.
- Canvas Scaler: Scale With Screen Size.
- Reference Resolution: 1080 x 1920.
- Screen Match Mode: Match Width Or Height.
- Match: 0.5.
- Primary validation targets: 9:16, 9.5:20, 10:21, and tall phones with top/bottom safe areas.

### Portrait Screen Zones

Coordinates use a 1080 x 1920 reference frame with origin at top-left for documentation.

| Screen | Zone | Bounds at 1080 x 1920 | Contents |
|--------|------|------------------------|----------|
| Main Menu | Top utility | x 32-1048, y 32-128 | Optional settings icon |
| Main Menu | Title | x 96-984, y 220-380 | Stackspire title |
| Main Menu | Primary actions | x 210-870, y 760-980 | Start Run, Upgrades |
| Main Menu | Footer info | x 96-984, y 1650-1810 | High Score, Coins |
| Class Select | Header | x 32-1048, y 32-140 | Back, title |
| Class Select | Card stack | x 96-984, y 220-1270 | Warrior, Archer, Mage cards |
| Class Select | Footer action | x 210-870, y 1500-1710 | Start Run |
| Upgrade Menu | Header | x 32-1048, y 32-150 | Back, title, banked Coins |
| Upgrade Menu | Upgrade list | x 56-1024, y 180-1690 | global upgrades and class specials |
| Upgrade Menu | Footer safe area | x 56-1024, y 1700-1856 | optional class filter/status |
| Game HUD | Top-left status | x 32-430, y 32-136 | Hearts and armor pip |
| Game HUD | Top-center status | x 300-780, y 32-154 | Score and Room |
| Game HUD | Top-right status | x 650-1048, y 32-136 | Coins and Pause |
| Game HUD | Combat lane | x 80-1000, y 170-1420 | player, enemies, projectiles, exits |
| Game HUD | Bottom controls | x 0-1080, y 1410-1870 | single movement stick lower-left; no aim stick |
| Pause Overlay | Dimmed gameplay | full screen | gameplay backdrop at 60% black overlay |
| Pause Overlay | Action panel | x 190-890, y 565-1195 | Resume, Restart, Main Menu |
| Game Over | Result header | x 96-984, y 180-360 | Game Over, New High Score |
| Game Over | Stat panel | x 150-930, y 455-950 | Final Score, Rooms Climbed, Coins, killed-by |
| Game Over | Action stack | x 210-870, y 1120-1570 | Restart, Upgrades, Main Menu |

### Safe Area

Use a `SafeAreaRoot` RectTransform under the Canvas.

- `SafeAreaRoot` stretches to the device safe area.
- All top HUD, menu headers, bottom buttons, and joystick touch zones live inside `SafeAreaRoot`.
- Minimum visual edge padding inside safe area: 32 reference px.
- Minimum interactive edge padding for icon buttons: 48 reference px.
- Bottom controls must not overlap Android gesture/navigation areas.
- If the bottom safe area is large, move joystick centers upward before scaling them down.
- Do not anchor critical controls directly to raw screen edges.

### Spacing System

- 8 px: tiny icon/text gap.
- 16 px: compact chip or row padding.
- 24 px: standard internal card padding.
- 32 px: screen edge padding inside safe area.
- 40 px: standard vertical gap between stacked menu buttons.
- 48 px: minimum touch target and minimum interactive separation.
- 64 px: major section gap.

### Touch Targets

- Minimum important tap target: 96 x 64 reference px.
- Minimum icon button target: 72 x 72 reference px.
- Primary button target: 660 x 96 reference px.
- Secondary button target: 620 x 84 reference px.
- Tertiary button target: 560 x 76 reference px.
- Minimum joystick base touch zone: 300 x 300 reference px.
- Recommended joystick active touch zone: 340 x 340 reference px.
- Minimum spacing between adjacent buttons: 24 reference px.

### Typography

Use a readable bold fantasy-friendly sans font for MVP. Avoid thin ornate fonts.

Suggested sizes at 1080 x 1920:

| Use | Size | Weight | Notes |
|-----|------|--------|-------|
| Game title | 86 | Extra bold | Main Menu only |
| Screen title | 46 | Bold | Menus |
| Primary button | 34 | Bold | Start Run, Restart |
| Secondary button | 30 | Bold | Upgrades, Main Menu |
| HUD Score | 34 | Bold | Top-center |
| HUD Room | 24 | Semi-bold | Below Score |
| HUD Coins | 28 | Bold | Top-right chip |
| Card title | 30 | Bold | Class name, upgrade name |
| Body | 22 | Medium | Short descriptions only |
| Small label | 18 | Semi-bold | Strength, weakness labels |
| Toast | 34 | Bold | Room Clear, Exit Locked |

Dynamic text must be Unity UI text, not baked into sprites.

### Color Direction

Keep the game world readable by making UI strong but not visually noisy.

| Token | Suggested Color | Use |
|-------|-----------------|-----|
| Stone panel | `#343038` | Main panels and cards |
| Stone panel light | `#4B4447` | Raised card surface |
| Ink shadow | `#0E0B10` | Outlines and text shadows |
| Primary text | `#D6C6A1` | Main labels |
| Muted text | `#B8A487` | Secondary labels |
| Torch gold | `#E0B75C` | Primary CTA, Coins, highlights |
| Deep gold pressed | `#8F5A24` | Pressed CTA |
| Mage violet | `#7B6A9B` | Mage accent |
| Archer sickly green | `#8A9B55` | Archer accent |
| Warrior dark crimson | `#6E151D` | Warrior accent only |
| Disabled gray | `#6D6461` | Disabled buttons |
| Danger red | `#D64A32` | damage, danger, urgent feedback |

Do not rely on color alone. Pair each state with label, icon, border, shape, or motion. Bright red is reserved for damage, danger, and urgent feedback.

### Animation Rules

- Keep feedback short: 0.15 to 0.45 sec.
- Prefer scale, alpha, and small position offsets.
- Avoid long decorative animations during combat.
- Combat HUD feedback must never block the player, enemies, projectiles, or north exit.

## Screen Specs

## Main Menu

### Goal

Let the player start a run or open Upgrades immediately.

### Wireframe

```text
+------------------------------+
|                         [gear]|
|                              |
|          STACKSPIRE          |
|                              |
|                              |
|         [ Start Run ]        |
|         [  Upgrades ]        |
|                              |
|                              |
|       High Score 0000        |
|       Coins 000              |
+------------------------------+
```

### Layout

- Background: portrait tower room art or placeholder dark stone field.
- Title anchor: top center, y 250-360.
- CTA stack anchor: center, y 760-980.
- Start Run button: 660 x 96.
- Upgrades button: 620 x 84.
- High Score and banked Coins: bottom center inside safe area, y 1650-1810.
- Optional settings icon: top-right safe area, 72 x 72 target. Include only if settings exists; otherwise omit.

### High-Fidelity Direction

Use a tall three-quarter top-down dark tower mood with thick ink shapes, heavy shadows, and warm torch accents. The title is large and readable. Start Run is torch gold and dominant. Upgrades is a quieter stone button with gold outline. High Score and Coins are passive information, not competing CTAs.

### States

- First launch: High Score shows `High Score 0`; Coins shows `Coins 0`.
- Returning player: High Score and Coins show saved values.
- Start Run pressed: button scale down to 0.96 for 0.08 sec.
- Upgrades pressed: same pressed response.

## Class Select

### Goal

Let the player choose Warrior, Archer, or Mage with minimal reading.

### Wireframe

```text
+------------------------------+
| [Back]      Choose Class      |
|                              |
| +--------------------------+ |
| | Warrior     [sword icon] | |
| | Close-range risk/reward  | |
| | + High damage            | |
| | - Must get close         | |
| +--------------------------+ |
| +--------------------------+ |
| | Archer        [bow icon] | |
| | Fast kiting shots        | |
| | + Long range             | |
| | - Lower hit damage       | |
| +--------------------------+ |
| +--------------------------+ |
| | Mage        [staff icon] | |
| | Slow powerful bolts      | |
| | + High damage            | |
| | - Slower rhythm          | |
| +--------------------------+ |
|                              |
|         [ Start Run ]        |
+------------------------------+
```

### Layout

- Screen title: top center.
- Back button: top-left safe area, 96 x 64 target.
- Three class cards in a vertical stack.
- Card size: 888 x 300.
- Card gap: 28.
- Start Run button: 660 x 96, lower center above bottom safe area.
- No scrolling for the three MVP cards at default text size.

### Card Content

Warrior:

- Weapon: Sword
- One-line playstyle: `Close-range risk/reward`
- Strength: `High damage`
- Weakness: `Must get close`

Archer:

- Weapon: Bow
- One-line playstyle: `Fast kiting shots`
- Strength: `Long range`
- Weakness: `Lower hit damage`

Mage:

- Weapon: Staff
- One-line playstyle: `Slow powerful bolts`
- Strength: `High damage`
- Weakness: `Slower rhythm`

### Visual Distinction

- Warrior accent: dark crimson slash mark, broad silhouette, sword icon.
- Archer accent: sickly green arrow line, lean silhouette, bow icon.
- Mage accent: occult blue-violet glow, staff icon, circular bolt motif.
- All cards share the same stone panel, typography, padding, and selected-state treatment.

### States

- Default card: stone panel, subtle class accent strip.
- Selected card: brighter border, class accent glow, check icon, slight scale up to 1.02.
- Pressed card: scale down to 0.98.
- Start Run disabled only if no class is selected. Recommendation: preselect Warrior so a player can Start Run in one action after opening Class Select.

## Upgrade Menu

### Goal

Show banked Coins and make permanent progression understandable.

### Wireframe

```text
+------------------------------+
| [Back]      Upgrades  Coins 0 |
|                              |
| Toughness  Lv 0/5       [Buy]|
| +1 max heart        Cost 25  |
| Power      Lv 0/5       [Buy]|
| +10% damage        Cost 30  |
| Agility    Lv 0/5       [Buy]|
| +5% speed          Cost 20  |
| Greed      Lv 0/5       [Buy]|
| +10% coins         Cost 35  |
| Class Special                |
| Warrior    Not bought [Buy] |
| Archer     Not bought [Buy] |
| Mage       Not bought [Buy] |
+------------------------------+
```

### Layout

- Back button: top-left safe area.
- Title: top center.
- Currency chip: top-right safe area.
- Upgrade list: x 56-1024, y 180-1690.
- Use one vertical ScrollRect inside safe area; keep currency chip fixed outside the scroll content.
- Global upgrade row: 968 x 132.
- Class special row: 968 x 118.
- Section header: `Class Special`, full-width, 40 px vertical padding.

### Required Rows

Global tracks:

- Toughness: +1 max heart, 5 levels, costs 25, 50, 100, 175, 275.
- Power: +10% attack damage, 5 levels, costs 30, 60, 120, 210, 330.
- Agility: +5% move speed, 5 levels, costs 20, 45, 90, 160, 250.
- Greed: +10% Coins earned, 5 levels, costs 35, 70, 140, 245, 385.

Class Special rows:

- Warrior: 1 armor hit at start of each room, 500 Coins.
- Archer: double shot, second arrow after 0.08 sec, 500 Coins.
- Mage: penetration until wall, 500 Coins.

### Row Content

Each row shows:

- Icon, 56 x 56.
- Upgrade name.
- Level text: `Lv 0/5`, `Lv 5/5`, or `Bought`.
- Current effect.
- Next effect or `Max level`.
- Cost with coin icon.
- Buy button, 180 x 72.

### States

Affordable:

- Buy button is torch gold.
- Cost text is normal.

Insufficient Coins:

- Buy button disabled.
- Button label: `Need X`.
- Cost text remains visible and uses muted text plus coin icon.

Maxed:

- Row badge: `Maxed`.
- Buy button replaced by disabled `Maxed`.
- Next effect text: `Max level`.

Class Special locked:

- State text: `Not bought`.
- Cost: `500`.

Class Special bought:

- State text: `Bought`.
- Button disabled as `Bought`.

0 Coins:

- Currency chip shows `Coins 0`.
- All unaffordable rows clearly show `Need X`.

## Game HUD

### Goal

Keep combat readable while exposing health, Score, Room, Coins, pause, and one movement joystick in a tall phone layout.

### Wireframe

```text
+------------------------------+
| hearts        Score 000 [||] |
|              Room 1  Coins 0 |
|                              |
|          north exit           |
|                              |
|        fixed combat room      |
|                              |
|         player/enemies        |
|                              |
|                              |
| (move stick)                 |
+------------------------------+
```

### HUD Anchors

Use `SafeAreaRoot` and a separate `GameplayHudRoot`.

Top-left:

- Heart container.
- Anchor: top-left.
- Position: x 32, y -32 inside safe area.
- Heart icon size: 48 x 48.
- Heart gap: 8.
- Supports up to 10 hearts in two rows of 5 so Toughness can fit without colliding with Score.

Top-center:

- Score label.
- Anchor: top-center.
- Position: y -30.
- Text: `Score 0000`.
- Room number below Score.
- Room text position: 42 px below Score.
- Text: `Room 1`.

Top-right:

- Pause button.
- Anchor: top-right.
- Position: x -32, y -32.
- Target: 72 x 72.
- Current-run Coins chip sits below or left of pause depending on safe area width.
- Coins chip target size: 260 x 64.
- Text: `Coins 000`.

Bottom-left:

- Movement joystick.
- Anchor: bottom-left.
- Center: x 235, y 245 inside safe area.
- Active touch zone: 340 x 340.
- Visual base: 240 x 240.
- Thumb: 96 x 96.

Bottom-right:

- No aim/attack joystick in MVP.
- Keep this area visually clear for gameplay readability, future context actions, or device ergonomics.
- Do not add a second virtual stick under another name.

### Combat Readability Rules

- Keep the vertical center lane clear from persistent UI.
- Keep the top HUD inside y 32-154 and the bottom controls inside y 1410-1870.
- The room entrance, player spawn, and nearby enemy paths must sit above the movement joystick visual base.
- The movement joystick uses 35% to 45% opacity when idle.
- The movement joystick increases to 60% opacity while touched.
- HUD labels use shadow or 2 px dark outline.
- Score feedback floats near the defeated enemy but fades quickly and does not block the north exit.

### HUD Feedback

Enemy kill:

- Score increments immediately.
- Small `+20` floats upward from enemy position for 0.45 sec.
- Coins chip pulses once if Coins increased.

Room clear:

- Center-top toast: `Room Clear`.
- North exit gets unlocked visual glow in world art.
- Score increments by +25 immediately.
- Toast duration: 0.9 sec.

Room advance:

- When entering unlocked north exit, Room updates after the next room starts.
- Score does not change from entering the north exit or advancing to the next room in MVP.

Player damage:

- One heart changes from full to empty.
- Brief red screen edge flash, max 0.18 sec.
- Optional small player hit flash can be world sprite, not UI.

Locked north exit:

- Door remains closed or barred.
- Short toast near top-center or door: `Exit Locked`.
- Do not add a minimap or quest tracker.

### Heart States

- Full: red filled heart.
- Empty: dark broken heart outline.
- Armor from Warrior Class Special: small silver shield pip overlay before hearts, only if the special is active.

## Single Movement Joystick Spec

### Shared Rules

- The lower-left movement stick controls movement.
- Normal attacks are automatic and follow the target-assisted rules in `GDD.md`.
- There is no right aim stick and no required attack button in MVP.
- Vertical movement speed difference is not shown as UI text.
- The movement joystick must not block the player, enemies, projectiles, south entrance, or north exit.

### Movement Stick

- Label text is not needed.
- Base: translucent stone ring.
- Thumb: lighter stone cap.
- Active drag radius: 110 reference px.
- Dead zone can be implemented by Coder, but no visual dead zone label is needed.

### Attack Feedback

- No persistent attack control is shown.
- If Coder needs a feedback affordance, use lightweight world feedback: class attack VFX, projectile direction, slash arc, or brief target-facing animation.
- Do not add a permanent cooldown button, attack button, or target reticle unless GameDesigner creates a separate follow-up design.
- If an optional auto-attack status indicator is later needed, it must be non-interactive, compact, and outside the central combat lane.

### Accessibility

- Do not make joystick visuals smaller than 240 x 240 at reference size.
- Touch zones should be larger than visuals.
- Keep the movement stick reachable by the left thumb without crossing the screen center.
- Keep the lower-right side free from mandatory input so right-handed and one-thumb play remains less cluttered than the previous dual-stick layout.

## Pause Overlay

### Goal

Pause the run and provide clear Resume, Restart, and Main Menu actions.

### Wireframe

```text
+------------------------------+
|      dim gameplay background  |
|                              |
|        +----------------+    |
|        |     Paused     |    |
|        |   [Resume]     |    |
|        |   [Restart]    |    |
|        |   [Main Menu]  |    |
|        +----------------+    |
+------------------------------+
```

### Layout

- Dim overlay: full screen, 60% black.
- Panel: centered, 700 x 630 max, stone panel.
- Title: `Paused`.
- Buttons: vertical stack, each 560 x 84, 28 gap.
- Resume is primary.
- Restart is secondary.
- Main Menu is tertiary.

### States

- Resume returns to Game HUD.
- Restart ends current run, discards current-run coins, does not submit score to High Score, and skips Game Over.
- Main Menu returns to Main Menu. If save behavior is unclear, route to Architect before implementation.
- Do not add a confirmation modal for MVP unless QA reports accidental tap risk.

## Game Over

### Goal

Show run result, bank Coins, show what killed the player, and encourage Restart or Upgrades.

### Wireframe

```text
+------------------------------+
|          Game Over            |
|       [New High Score]        |
|                              |
|  Final Score          0000   |
|  Rooms Climbed        00     |
|  Coins Earned         00     |
|  Total Banked Coins   000    |
|  Killed By            Grunt  |
|                              |
|         [ Restart ]          |
|         [ Upgrades ]         |
|         [ Main Menu ]        |
+------------------------------+
```

### Layout

- Background: dimmed final room or static stone background.
- Title: top center, y 180-260.
- New High Score badge: under title, only when true.
- Stat panel: 780 x 495, centered around y 455-950.
- Button stack: lower center, y 1120-1570.
- Restart button: 660 x 96, primary.
- Upgrades button: 620 x 84, secondary.
- Main Menu: 560 x 76, tertiary.

### Result States

Normal:

- Title `Game Over`.
- High Score label is passive.

New High Score:

- Badge `New High Score`.
- Final Score row briefly scales to 1.05 then returns.

Low Score with Coins:

- Coins Earned row remains visible.
- Upgrades button remains visible.
- Do not shame the player or hide progression.

0 Coins Earned:

- Show `Coins Earned 0`.
- Upgrades remains available because the player may have banked Coins.

Room 1 death:

- If the player dies before entering the first north exit, show `Rooms Climbed 0`.

Killed-by:

- Show `Killed By` plus the source that reduced health to 0.
- Acceptable labels include `Grunt`, `Dasher`, `Shooter`, `Shooter Projectile`, `Contact Damage`, or a future source provided by the gameplay system.

## Component Library

Build these as reusable Unity prefabs where practical.

| Component | Purpose | Reference Size | Prefab Suggestion |
|-----------|---------|----------------|-------------------|
| Primary button | Main action | 660 x 96 | `UI/ButtonPrimary.prefab` |
| Secondary button | Alternate action | 620 x 84 | `UI/ButtonSecondary.prefab` |
| Tertiary button | Low-emphasis action | 560 x 76 | `UI/ButtonTertiary.prefab` |
| Icon button | Pause/settings/back | 72 x 72 target | `UI/ButtonIcon.prefab` |
| Class card | Class selection | 888 x 300 | `UI/ClassCard.prefab` |
| Upgrade row | Upgrade list item | 968 x 132 | `UI/UpgradeRow.prefab` |
| Currency chip | Coins display | 260 x 64 | `UI/CurrencyChip.prefab` |
| Score label | HUD Score | 480 x 44 | `UI/ScoreLabel.prefab` |
| Room number label | HUD Room | 280 x 32 | `UI/RoomLabel.prefab` |
| Heart container | Health display | max 398 x 104 | `UI/HeartContainer.prefab` |
| Heart icon | Full/empty/armor states | 48 x 48 | `UI/HeartIcon.prefab` |
| Virtual joystick base | Movement stick visual | 240 x 240 | `UI/VirtualJoystickBase.prefab` |
| Virtual joystick thumb | Stick thumb | 96 x 96 | child of joystick prefab |
| Pause overlay panel | Pause menu | 700 x 630 | `UI/PauseOverlay.prefab` |
| Result stat row | Game Over stats | 700 x 64 | `UI/ResultStatRow.prefab` |
| Toast label | Short feedback | 500 x 80 | `UI/ToastLabel.prefab` |
| Door indicator style | Locked/unlocked state | world sprite or UI marker | depends on room implementation |

### Component States

Primary button:

- Default: torch gold fill, dark text, raised shadow.
- Pressed: darker gold, 0.96 scale.
- Disabled: gray fill, muted text.

Secondary button:

- Default: stone fill, gold outline, primary text.
- Pressed: lighter stone, 0.96 scale.
- Disabled: gray fill, muted text.

Icon button:

- Default: stone circle or compact square, 72 x 72 target.
- Pressed: scale 0.92.
- Disabled: 45% opacity.

Class card:

- Default: stone panel, class accent strip.
- Selected: bright border, check icon, slight scale.
- Pressed: scale 0.98.

Upgrade row:

- Default: stone row, readable cost.
- Affordable: gold Buy button.
- Insufficient Coins: disabled Buy button with `Need X`.
- Maxed: silver `Maxed` badge and disabled button.
- Bought: class special shows `Bought`.

Currency chip:

- Default: coin icon plus value.
- Updated: quick scale pulse and warm flash.

Heart icon:

- Full: filled red.
- Empty: dark outline.
- Damage warning: last lost heart flashes red once.

Toast label:

- Room clear: gold text with stone shadow.
- Damage warning: red edge flash plus optional red toast only if needed.
- Locked exit: small `Exit Locked` text near top-center or door.

Door locked/unlocked:

- Locked: barred or red lock mark, closed silhouette.
- Unlocked: warm gold glow, open path shape.
- Must be readable without relying on color.

## UI State Sheet

| State | Screen | Required Feedback |
|-------|--------|-------------------|
| Default | All | Stable layout, readable text |
| Pressed | Buttons/cards | Brief scale and color change |
| Selected | Class Select | Border, check icon, accent glow |
| Disabled | Buttons | Muted color, label explains reason when useful |
| Insufficient Coins | Upgrade Menu | `Need X`, disabled button, visible cost |
| Maxed | Upgrade Menu | `Maxed`, no cost pressure |
| Bought | Class Special | `Bought`, disabled button |
| New High Score | Game Over | Badge and Final Score emphasis |
| Room clear | Game HUD | `Room Clear`, door unlock, Score update |
| Damage warning | Game HUD | Heart loss and red edge flash |
| Killed-by | Game Over | readable death-source stat row |

## Unity Implementation Notes

- Use placeholder art where final art is unavailable.
- Keep dynamic text in Unity UI text objects.
- Do not embed Score, Coins, Room, High Score, level, cost, killed-by labels, or button labels into sprites.
- Export icons and sprites as PNG with transparency.
- Keep buttons, panels, class cards, upgrade rows, HUD labels, and joystick visuals modular for prefab reuse.
- Prefer clean prefab composition over one-off scene-only objects.
- Put scripts in `Assets/Scripts/`.
- Put prefabs in `Assets/Prefabs/`.
- Put generated art in `Assets/Generated/`.
- Use `SafeAreaRoot` to drive all screen-edge UI.
- Use `CanvasGroup` for overlay fade and disabled states.
- Use serialized fields for tunable durations, colors, sizes, and references.
- Do not use `FindObjectOfType<T>()` in `Update()`.
- Stop UI animation coroutines in `OnDisable()`.
- HUD should subscribe to score, coin, health, room, pause, and run-end events rather than polling every frame.
- Joystick input may be implemented as UI components, but movement itself must respect the existing `Rigidbody2D` rule from `Core/Conventions.md`.

## Static Art vs Unity UI

Static or sprite art:

- Portrait tower menu/background art.
- Button panel sprites.
- Class silhouettes.
- Class weapon icons.
- Heart icons.
- Coin icon.
- Joystick base and thumb art.
- Door locked/unlocked indicators.

Unity UI elements:

- All text labels and numbers.
- Button hit targets and state changes.
- Upgrade row layout.
- Class card selection state.
- Pause overlay.
- Toast labels.
- HUD Score, Room, Coins, and heart state container.
- Killed-by result text.

## Asset Naming

Suggested generated asset names:

- `ui_panel_stone_portrait.png`
- `ui_button_primary_gold_portrait.png`
- `ui_button_secondary_stone_portrait.png`
- `ui_button_tertiary_stone_portrait.png`
- `ui_icon_coin.png`
- `ui_icon_heart_full.png`
- `ui_icon_heart_empty.png`
- `ui_icon_pause.png`
- `ui_icon_back.png`
- `ui_icon_warrior_sword.png`
- `ui_icon_archer_bow.png`
- `ui_icon_mage_staff.png`
- `ui_joystick_movement_base.png`
- `ui_joystick_thumb.png`
- `ui_door_locked.png`
- `ui_door_unlocked.png`
- `screen_main_menu_background_portrait.png`
- `screen_class_select_background_portrait.png`
- `screen_upgrade_menu_background_portrait.png`
- `screen_game_hud_room_background_portrait.png`
- `screen_game_over_background_portrait.png`

## QA Checklist

Flow:

- Given a fresh launch, when Main Menu appears, then Start Run is the dominant action.
- Given Main Menu, when Start Run is tapped, then Class Select opens.
- Given Class Select, when a class is selected and Start Run is tapped, then Game HUD opens.
- Given Game HUD, when Pause is tapped, then Pause Overlay opens.
- Given Pause Overlay, when Resume is tapped, then the run resumes.
- Given Pause Overlay, when Restart is tapped, then current-run coins are discarded and Game Over is not shown.
- Given Game Over, when Restart is tapped, then the restart flow begins.
- Given Game Over, when Upgrades is tapped, then Upgrade Menu opens.

HUD:

- Given Game HUD on a portrait Android phone, hearts are top-left.
- Given Game HUD, Score is top-center and Room is below Score.
- Given Game HUD, current-run Coins and pause are top-right without overlap.
- Given Game HUD, the single movement stick is lower-left and no aim/attack stick is required.
- Given an enemy kill, Score and Coins update visibly.
- Given room clear, `Room Clear` or door unlock feedback appears.
- Given player damage, a heart is lost and red damage feedback appears.
- Given the north exit is locked, trying to exit communicates the locked state.

Screen scaling:

- Verify 9:16 phone.
- Verify 9.5:20 phone.
- Verify 10:21 phone.
- Verify devices with top and bottom safe areas.
- Verify no tappable element is clipped by safe area, notches, rounded corners, or gesture navigation.

Upgrade states:

- Given 0 Coins, all unaffordable Buy buttons explain the missing amount.
- Given enough Coins for an upgrade, Buy is enabled.
- Given an upgrade reaches level 5, row shows Maxed.
- Given a Class Special is bought, row shows Bought.

Game Over:

- Given a run ends, Final Score, Rooms Climbed, Coins Earned, Total Banked Coins, Killed By, Restart, Upgrades, and Main Menu are visible.
- Given the player dies in Room 1 before entering the first north exit, Rooms Climbed shows 0.
- Given the run earns coins, Total Banked Coins reflects deposit after the Game Over flow.

Accessibility:

- Verify every important button target is at least 48dp equivalent.
- Verify adjacent touch targets have clear spacing.
- Verify disabled states do not rely on color alone.
- Verify HUD text remains readable during motion and combat.
