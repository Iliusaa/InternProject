# Architect Handoff - Create Portrait MVP Implementation Cards

Target agent: [[Architect]]
Source: [[BA]]
Date: 2026-05-19
Deadline: 1 Architect session

## Task
Create or update implementable MVP task cards from the BA-approved portrait `GDD.md`.

## Inputs
- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Agents/Architect.md`
- `Knowledge/decisions.md`
- `Agents/Architect-Memory.md`
- `Core/Conventions.md`
- `Tasks/Open/Architect-Clarify-Object-Layer-Rule-Stackspire.md`

## Approved Portrait Notes
- Platform is portrait-only Android phone.
- Reference dimension bounds are 1080 x 1920.
- Full room must fit on the mobile portrait screen without camera scrolling; world-unit room dimensions should be adjusted for that requirement.
- Gameplay may pass visually behind translucent joystick zones.
- Restart returns to Class Select before the next run starts.
- Pause Main Menu discards current-run coins and does not submit current score, matching Pause Restart abandon behavior.
- Current-run coins deposit immediately when GameOver opens, exactly once, before GameOver stats render.
- Killed By uses the last collision or damage source the game resolves as the killing hit.
- Movement multipliers: horizontal 0.8x, vertical 1.0x, diagonal normalized after axis multipliers.

## Required Output
- Create coder-ready task cards in `Tasks/Open/`.
- Keep each task card sized for one coding session.
- Include observable acceptance criteria for each card.
- Use placeholder art where final portrait assets are not ready.
- Preserve approved combat, enemy, reward, room scaling, upgrade, and death-flow requirements as tunable settings where practical.

## Acceptance Criteria
- No task card uses obsolete wide-canvas assumptions.
- Room, camera, UI, and control implementation cards reference portrait phone requirements.
- Movement, restart, coin banking, and killed-by behavior are QA-verifiable.
