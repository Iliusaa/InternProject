# UIUX QA Checklist Handoff

Target agent: [[QA]]
Source: [[UIUXDesigner]]
Date: 2026-05-19

## PM Current-State Audit - 2026-05-30

Status: legacy QA handoff, needs current-state interpretation before execution.

This checklist still contains useful UI/UX coverage, but it is not fully current. It still references the old dual-joystick layout. The current project direction is a single movement joystick:

- `T45_GameDesigner-Revise-Mobile-Controls-Single-Joystick-Stackspire.md` must update the design.
- `T46_Coder-Implement-Single-Joystick-Mobile-Controls-Stackspire.md` must implement the new input scheme.
- `T47_Coder-Apply-Generated-Backgrounds-To-Scenes-Stackspire.md` must apply generated Class Select and gameplay room backgrounds.

QA should not fail the current project for missing a bottom-right aim joystick after T45/T46. QA should instead verify the single-joystick behavior defined by the updated GDD/UIUX spec.

## Purpose

Test the Stackspire MVP UI against `Docs/UIUX_MVP_SPEC.md` after Unity implementation.

## Inputs

- `Docs/UIUX_MVP_SPEC.md`
- `GDD.md`
- `Agents/QA.md`

## Required Test Areas

- Main Menu start readability
- Class Select clarity
- Game HUD readability
- Pause Overlay flow
- Upgrade Menu states
- Game Over results
- Android portrait phone safe areas
- touch target comfort
- placeholder/generated art readability
- generated Class Select and gameplay room background placement after T47
- single movement joystick behavior after T45/T46

## Test Cases

1. Given Main Menu is shown, when the player looks at the screen, then Start Run is the dominant action and High Score is visible.
2. Given Main Menu is shown, when Start Run is tapped, then Class Select opens.
3. Given Class Select is shown, when Warrior, Archer, or Mage is selected, then the selected card state is visually clear.
4. Given Class Select is shown, when Start Run is tapped after selecting a class, then the Game HUD opens.
5. Given Game HUD is shown on a portrait Android phone, then hearts are top-left, Score is top-center, Room is below Score, Coins and pause are top-right, and the single movement stick is lower-left.
6. Given Game HUD is shown, then the central combat lane is not blocked by persistent UI or joystick visuals, and no bottom-right aim joystick is required after T45/T46.
7. Given an enemy is killed, when Score and Coins change, then the HUD visibly updates.
8. Given the player takes damage, when health changes, then one heart is lost and damage feedback appears.
9. Given all enemies in a room are defeated, when the room clears, then Room Clear or north exit unlock feedback appears.
10. Given the north exit is locked, when the player attempts to move north, then the locked state is readable.
11. Given Pause is tapped mid-run, then Pause Overlay appears with Resume, Restart, and Main Menu.
12. Given Pause Overlay is shown, when Restart is tapped, then current-run coins are discarded, current score is not submitted to High Score, and Game Over is not shown.
13. Given Upgrade Menu is shown with 0 Coins, then unaffordable rows explain the missing amount.
14. Given the player can afford an upgrade, then that row has an enabled Buy button.
15. Given an upgrade is maxed, then the row shows Maxed and the Buy action is disabled.
16. Given a Class Special is bought, then the row shows Bought and the Buy action is disabled.
17. Given Game Over is shown, then Final Score, Rooms Climbed, Coins Earned, Total Banked Coins, Killed By, High Score or New High Score, Restart, Upgrades, and Main Menu are visible.
18. Given the player dies in Room 1 before entering the first north exit, then Rooms Climbed shows 0.
19. Given the run earns coins, then Game Over shows current-run Coins Earned and Total Banked Coins after deposit.
20. Given the app runs on 9:16, 9.5:20, 10:21, and phones with top/bottom safe areas, then no critical UI overlaps, clips, or leaves the safe area.
21. Given Class Select is shown after T47, then the selected generated class-selection background fills the portrait screen and stays behind all UI.
22. Given Game is shown after T47, then the selected generated gameplay room background fills the portrait screen and stays behind gameplay objects and HUD.
23. Given T45/T46 are complete, then aiming and attacking work according to the updated single-joystick design while editor keyboard/mouse fallback remains usable.

## Acceptance Criteria

- All required MVP screens are reachable.
- All critical HUD values are readable during combat.
- All important tap targets meet mobile-safe sizing.
- Disabled, insufficient Coins, bought, and maxed upgrade states are understandable without relying only on color.
- Game Over includes killed-by display, Rooms Climbed boundary behavior, current-run coins, and banked coins after deposit.
- Pause Restart discard behavior is visible and testable.
- The UI remains usable with placeholder or generated art.
- The Class Select and Game backgrounds are correctly scaled and layered after T47.
- The Game HUD follows the single-movement-joystick design after T45/T46, with no required aim joystick.
- No out-of-scope UI appears.
