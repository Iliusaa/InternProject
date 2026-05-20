# GameDesigner Handoff - Rewrite GDD For Portrait Mobile

Target agent: [[GameDesigner]]
Source: [[PM]]
Date: 2026-05-19
Deadline: 1 GameDesigner session

## Task
Rewrite the whole `GDD.md` so Stackspire is defined as a portrait mobile phone game. The game is no longer landscape mode.

## Inputs
- `Agents/GameDesigner.md`
- `STATUS.md`
- `Agents/GameDesigner-Memory.md`
- `GDD.md`
- `Templates/GDD-Template.md` only if the current document structure is too inconsistent to preserve

## Required Updates
- Set the game orientation to portrait-only mobile phone.
- Set the reference dimension bounds to 1080 x 1920.
- Delete every remaining statement that says or implies the game is landscape mode.
- Replace all landscape-specific control, HUD, screen, camera-framing, and layout language with portrait-appropriate mobile phone requirements.
- Preserve approved gameplay mechanics unless they directly depend on landscape presentation.
- Keep the dark fantasy, three-quarter top-down art direction unless a portrait framing requirement needs clearer wording.
- Add a short change note at the end of `GDD.md` dated 2026-05-19 describing the portrait rewrite.

## Constraints
- Do not add new gameplay systems.
- Do not change combat, scoring, economy, room progression, or class mechanics unless required to remove landscape-only assumptions.
- Do not leave historical landscape requirements in the active GDD text.
- If a past approval/history section conflicts with portrait-only direction, rewrite or mark it as superseded so it cannot be mistaken for the current requirement.

## Acceptance Criteria
- `GDD.md` defines Stackspire as portrait-only mobile phone gameplay.
- `GDD.md` uses 1080 x 1920 as the active reference dimension bounds.
- Searching `GDD.md` for `landscape` returns no active landscape-mode requirement.
- Controls, HUD, menus, safe areas, and gameplay camera framing make sense for portrait mobile.
- The document is ready for [[BA]] validation before downstream implementation or art tasks resume.
