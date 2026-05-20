# UIUX Unity Implementation Handoff

Target agent: [[Architect]] then [[Coder]]
Source: [[UIUXDesigner]]
Date: 2026-05-19

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

## Required Implementation Notes

- Use Unity Canvas with a safe-area-aware root.
- Use `1080 x 1920` as the UI reference resolution.
- Use reusable prefabs for buttons, class cards, upgrade rows, HUD labels, hearts, currency chip, virtual joysticks, pause overlay, result stat rows, and toast labels.
- Keep dynamic text as Unity UI text.
- Use placeholder art until ArtDirector assets are available.
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
- Game HUD anchors hearts top-left, Score and Room top-center, Coins and pause top-right, movement stick lower-left, and aim/attack stick lower-right.
- Pause Overlay uses a centered vertical action panel.
- Game Over uses a portrait result panel and stacked Restart, Upgrades, and Main Menu buttons.

## Acceptance Criteria

- UI uses portrait phone reference bounds: `1080 x 1920`.
- Main Menu can route to Class Select and Upgrades.
- Class Select presents Warrior, Archer, and Mage with clear selected state.
- Upgrade Menu shows Coins, levels, current effect, next effect, cost, Buy, insufficient Coins, bought, and maxed states.
- Game HUD keeps the central combat lane readable and puts both joysticks in reachable lower thumb zones.
- Game Over shows Final Score, Rooms Climbed, Coins Earned, Total Banked Coins, Killed By, High Score or New High Score, Restart, Upgrades, and Main Menu.
- Pause Restart discards current-run coins, does not submit the current score to High Score, and does not show Game Over.
- All important tap targets meet mobile-safe sizing.
- Placeholder art keeps the UI readable.
