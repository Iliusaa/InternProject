# UIUX Unity Implementation Handoff

Target agent: [[Architect]] then [[Coder]]
Source: [[UIUXDesigner]]
Date: 2026-05-19

## PM Current-State Audit - 2026-05-30

Status: legacy supporting handoff, not the current source of implementation truth.

This handoff is kept as UI/UX context, but it is no longer up to date as a direct implementation task. The project has already completed the MVP scene bootstrap, portrait Canvas root, safe-area root, virtual joystick implementation, player input reader, Game HUD prototype, class selection state, Warrior attack prototype, GameOver flow, save stub, vertical-slice QA checklist, generated background concepts, and generated/project asset audit through `T44`.

Current follow-up work is split into newer tasks:

- `T45_GameDesigner-Revise-Mobile-Controls-Single-Joystick-Stackspire.md` defines the new single-movement-joystick design.
- `T46_Coder-Implement-Single-Joystick-Mobile-Controls-Stackspire.md` implements that control change after T45 is complete.
- `T47_Coder-Apply-Generated-Backgrounds-To-Scenes-Stackspire.md` applies generated Class Select and gameplay room backgrounds.

Do not implement this handoff literally where it conflicts with T45, T46, T47, or completed T24-T44 work.

## Purpose

Turn `Docs/UIUX_MVP_SPEC.md` into Unity UI implementation cards for the Stackspire portrait mobile MVP.

## Inputs

- `Docs/UIUX_MVP_SPEC.md`
- `GDD.md`
- `Agents/Architect.md`
- `Agents/Coder.md`
- `Core/Conventions.md`

## Scope

Implement the MVP UI structure only:

- Main Menu
- Class Select
- Game HUD
- Pause Overlay
- Upgrade Menu
- Game Over
- reusable UI prefabs and placeholder art hooks

Note: this broad decomposition has largely been superseded by completed task files `T24` through `T43`. Use this section only to understand original UIUX intent.

## Required Implementation Notes

- Use Unity Canvas with a safe-area-aware root.
- Use `1080 x 1920` as the UI reference resolution.
- Use reusable prefabs for buttons, class cards, upgrade rows, HUD labels, hearts, currency chip, the movement joystick, pause overlay, result stat rows, and toast labels.
- Keep dynamic text as Unity UI text.
- Use generated art where available. `T44` produced portrait Class Select and gameplay room concepts, and `T47` owns applying those backgrounds to Unity scenes.
- Store scripts in `Assets/Scripts/`.
- Store prefabs in `Assets/Prefabs/`.
- Generated art should load from `Assets/Generated/`.
- Use serialized fields for colors, durations, prefab references, and layout tuning.
- Do not call `FindObjectOfType<T>()` in `Update()`.
- Stop animation coroutines in `OnDisable()`.
- Do not implement new gameplay systems.

## Portrait Layout Requirements

- UI respects Android phone safe areas, including top cutouts and bottom gesture/navigation areas.
- Main Menu uses a tall stacked action layout with Start Run as the dominant action.
- Class Select uses stacked portrait class cards for Warrior, Archer, and Mage.
- Upgrade Menu uses a vertical ScrollRect with fixed header and banked Coins chip.
- Game HUD anchors hearts top-left, Score and Room top-center, Coins and pause top-right, and a single movement stick lower-left. The previous bottom-right aim/attack joystick is obsolete and must not be required in new work.
- Aiming and attacking without a second joystick are defined by `T45` and implemented by `T46`; do not infer those rules from this legacy handoff.
- Pause Overlay uses a centered vertical action panel.
- Game Over uses a portrait result panel and stacked Restart, Upgrades, and Main Menu buttons.

## Acceptance Criteria

- UI uses portrait phone reference bounds: `1080 x 1920`.
- Main Menu can route to Class Select and Upgrades.
- Class Select presents Warrior, Archer, and Mage with clear selected state.
- Upgrade Menu shows Coins, levels, current effect, next effect, cost, Buy, insufficient Coins, bought, and maxed states.
- Game HUD keeps the central combat lane readable and puts the single movement joystick in a reachable lower-left thumb zone.
- Game HUD no longer requires a bottom-right aim/attack joystick after T45/T46.
- Class Select and Game scenes use generated background assets after T47.
- Game Over shows Final Score, Rooms Climbed, Coins Earned, Total Banked Coins, Killed By, High Score or New High Score, Restart, Upgrades, and Main Menu.
- Pause Restart discards current-run coins, does not submit the current score to High Score, and does not show Game Over.
- All important tap targets meet mobile-safe sizing.
- Placeholder art or generated art keeps the UI readable.
