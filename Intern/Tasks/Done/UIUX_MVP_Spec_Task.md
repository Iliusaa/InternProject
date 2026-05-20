# UIUX MVP Spec Task

## Owner

UIUXDesigner

## Purpose

Create the first implementation-ready UI/UX specification for the Stackspire MVP.

The goal is to translate the existing GDD into a practical mobile-first UI/UX plan for Unity implementation.

## References

- `GDD.md`
- `Agents/UIUXDesigner.md`
- `Agents/ArtDirector.md`
- `Agents/Architect.md`
- `Core/Conventions.md`

## Scope

Design the MVP UI/UX for:

- Main Menu
- Class Select
- Game HUD
- Pause Overlay
- Upgrade Menu
- Game Over

## Requirements

The UI/UX spec must support Android landscape gameplay and must follow the MVP scope defined in the GDD.

The HUD must include:

- hearts top-left
- score top-center
- room number below score
- current run coins top-right
- pause button near a top corner
- left movement joystick bottom-left
- right aim/attack joystick bottom-right

The design must be readable during combat, safe-area aware, and practical for Unity Canvas implementation.

## Deliverables

Create:

1. UX flow map
2. Screen-by-screen wireframe descriptions
3. HUD layout specification
4. Virtual joystick specification
5. Upgrade Menu state specification
6. Game Over state specification
7. UI component library
8. Typography, color, icon, and spacing guidelines
9. Unity handoff notes
10. QA checklist

Recommended output file:

`Docs/UIUX_MVP_SPEC.md`

Optional supporting files:

- `Docs/UI_COMPONENT_LIBRARY.md`
- `Docs/HUD_LAYOUT_SPEC.md`
- `Tasks/Open/UIUX_Art_Asset_Request.md`
- `Tasks/Open/UIUX_Unity_Implementation.md`
- `Tasks/Open/UIUX_QA_Checklist.md`

## Constraints

Do not add new gameplay systems.

Do not add:

- inventory
- quests
- ads
- IAP
- battle pass
- online leaderboard
- extra currencies
- XP
- gems
- skins
- daily rewards
- boss UI
- minimap

Stay within the MVP.

## Acceptance Criteria

The output is accepted if:

- a new player can understand how to start a run quickly
- class differences are clear
- the HUD is readable and does not block combat
- touch controls are comfortable for Android landscape
- upgrade states are clear
- Game Over encourages Restart or Upgrades
- the design can be implemented in Unity using reusable prefabs
- the ArtDirector can derive asset requests from the spec
- the Coder can derive implementation tasks from the spec
- QA can test the UI using the provided checklist

