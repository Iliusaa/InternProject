# UIUXDesigner Handoff - Update May 17 Clarifications

Target agent: [[UIUXDesigner]]
Source: [[BA]]
Date: 2026-05-17
Deadline: 1 UIUXDesigner session

## Task
Update the UI/UX specification and downstream UI/UX handoffs so they match the May 17 stakeholder clarifications now recorded in `GDD.md`.

## Inputs
- `GDD.md` - see `Stakeholder Clarifications - 2026-05-17`
- `Docs/UIUX_MVP_SPEC.md`
- `Tasks/Open/UIUX_Unity_Implementation.md`
- `Tasks/Open/UIUX_QA_Checklist.md`
- `Agents/UIUXDesigner.md`
- `Core/Conventions.md`

## Required Updates
- GameOver must show what killed the player.
- GameOver must show current-run coins collected and total banked coins after deposit.
- Rooms Climbed must show 0 if the player dies in Room 1 before entering the north exit.
- Pause Overlay Restart must be enabled and must clearly represent an abandon/restart action that discards the current run.
- UI/UX QA cases must verify killed-by display, Rooms Climbed 0 boundary behavior, and Pause Restart discard behavior.

## Constraints
- Do not add new screens.
- Do not add a confirmation modal unless the spec explicitly keeps it optional for later QA feedback.
- Do not change gameplay balance.
- Keep all values and labels dynamic Unity UI text, not baked into sprites.

## Acceptance Criteria
- `Docs/UIUX_MVP_SPEC.md` no longer conflicts with `GDD.md` on GameOver or Pause Restart behavior.
- UI implementation and QA handoffs include the new observable requirements.
- No out-of-scope UI systems are introduced.
