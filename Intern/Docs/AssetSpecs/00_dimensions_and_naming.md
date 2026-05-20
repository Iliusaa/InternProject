# Stackspire Dimensions And Naming

## Reference Canvas

- Reference frame: 1080x1920.
- Orientation: Android portrait phone only.
- Unity canvas: Screen Space - Overlay for MVP unless Architect changes it for integration.
- Canvas Scaler: Scale With Screen Size.
- Reference Resolution: 1080x1920.
- Screen Match Mode: Match Width Or Height.
- Match: 0.5.
- Primary validation targets: 9:16, 9.5:20, 10:21, and tall phones with top/bottom safe areas.

## Safe Area And Touch Targets

| Rule | Value |
|---|---:|
| Minimum visual edge padding inside safe area | 32 px |
| Minimum interactive edge padding for icon buttons | 48 px |
| Minimum important tap target | 96x64 px |
| Minimum icon button target | 72x72 px |
| Minimum joystick base touch zone | 300x300 px |
| Recommended joystick active touch zone | 340x340 px |
| Minimum spacing between adjacent buttons | 24 px |
| Tiny internal icon/text gap | 8 px |
| Compact padding | 16 px |
| Standard card/row padding | 24 px |
| Screen edge padding | 32 px |
| Major section gap | 64 px |

## Screen Zones At 1080x1920

| Screen | Zone | Bounds | Contents |
|---|---|---|---|
| Main Menu | Top utility | x 32-1048, y 32-128 | Optional settings icon |
| Main Menu | Title | x 96-984, y 220-380 | Stackspire title |
| Main Menu | Primary actions | x 210-870, y 760-980 | Start Run, Upgrades |
| Main Menu | Footer info | x 96-984, y 1650-1810 | High Score, Coins |
| Class Select | Header | x 32-1048, y 32-140 | Back, title |
| Class Select | Card stack | x 96-984, y 220-1270 | Warrior, Archer, Mage cards |
| Class Select | Footer action | x 210-870, y 1500-1710 | Start Run |
| Upgrade Menu | Header | x 32-1048, y 32-150 | Back, title, banked Coins |
| Upgrade Menu | Upgrade list | x 56-1024, y 180-1690 | Global upgrades and class specials |
| Upgrade Menu | Footer safe area | x 56-1024, y 1700-1856 | Optional class filter/status |
| Game HUD | Top-left status | x 32-430, y 32-136 | Hearts and armor pip |
| Game HUD | Top-center status | x 300-780, y 32-154 | Score and Room |
| Game HUD | Top-right status | x 650-1048, y 32-136 | Coins and Pause |
| Game HUD | Combat lane | x 80-1000, y 170-1420 | Player, enemies, projectiles, exits |
| Game HUD | Bottom controls | x 0-1080, y 1410-1870 | Movement and aim sticks |
| Pause Overlay | Dimmed gameplay | full screen | 60 percent black overlay |
| Pause Overlay | Action panel | x 190-890, y 565-1195 | Resume, Restart, Main Menu |
| Game Over | Result header | x 96-984, y 180-360 | Game Over, New High Score |
| Game Over | Stat panel | x 150-930, y 455-950 | Final Score, Rooms Climbed, Coins, killed-by |
| Game Over | Action stack | x 210-870, y 1120-1570 | Restart, Upgrades, Main Menu |

## Standard Sizes

| Asset | Size |
|---|---:|
| Full-screen backgrounds and overlays | 1080x1920 px |
| Primary button state cell | 660x96 px |
| Secondary button state cell | 620x84 px |
| Tertiary button state cell | 560x76 px |
| Icon button state cell | 72x72 px |
| Class card state cell | 888x300 px |
| Global upgrade row state cell | 968x132 px |
| Class special upgrade row state cell | 968x118 px |
| Result stat row state cell | 700x64 px |
| Currency chip state cell | 260x64 px |
| Score/Room plaque state cell | 480x104 px |
| Toast label frame state cell | 500x80 px |
| Heart container state cell | 398x104 px |
| Heart icon | 48x48 px |
| Heart gap | 8 px |
| Pause overlay panel | 700x630 px |
| Pause overlay buttons | 560x84 px |
| Pause overlay button gap | 28 px |
| Game Over stat panel | 780x495 px |
| Joystick base visual | 240x240 px |
| Joystick thumb | 96x96 px |
| Joystick active drag radius | 110 px |
| Upgrade row icon display | 56x56 px |
| Upgrade buy button | 180x72 px |
| Portrait room template target | 900x1250 px |

## Naming Rules

- Folder names use lowercase snake_case.
- File names use lowercase snake_case.
- Asset IDs match file names without extension.
- Layout-bound portrait assets use a `_portrait` suffix in the output PNG name.
- State sheets use a `_sheet` suffix after `_portrait` when the output bundles multiple states.
- Individual state cells use state names from each spec file.
- Do not embed gameplay values, scores, prices, labels, killed-by strings, or room numbers in filenames or bitmaps.

## Pivot Rules

| Asset Type | Pivot |
|---|---|
| Characters and standing enemies | bottom-center feet point |
| Projectiles | center, rotated toward travel direction in Unity |
| VFX bursts | center |
| Full-screen overlays/backgrounds | center/stretch |
| UI buttons, cards, panels, icons | center |
| Joystick base and thumb | center |
| Doors | center or bottom-center according to prefab composition |
| Standing props | bottom-center |
| Flat floor props and tiles | center |

## 9-Slice Rules

- Use 9-slice for scalable panels, cards, rows, and button backgrounds where practical.
- Preserve corners and bevels outside the stretch center.
- Recommended 9-slice border for 512x512 panel source: 48 px.
- Recommended 9-slice border for button sources: 36 px left/right and 24 px top/bottom.
- Do not use 9-slice on icons, characters, enemies, projectiles, VFX, or hand-drawn props.

## State Sheet Rules

- Bundle interactive states together when practical so outline weight, palette, and silhouette match.
- Keep every cell in a state sheet the same width and height.
- Use 16 px transparent padding between cells unless the asset file states otherwise.
- Use transparent PNG/RGBA for reusable UI elements.
- Unity text remains separate from art in all state sheets.