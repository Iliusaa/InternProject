# Architect Handoff - Stackspire MVP Implementation Cards

Target agent: [[Architect]]
Source: [[BA]]
Date: 2026-05-13

## Task
Create implementable MVP task cards from the approved `GDD.md`.

## Inputs
- `GDD.md`
- `Agents/Architect.md`
- `Knowledge/decisions.md`
- `Agents/Architect-Memory.md`
- `Core/Conventions.md`

## Required Output
- Create coder-ready task cards in `Tasks/Open/`.
- Keep each task card sized for one coding session.
- Include observable acceptance criteria for each card.
- Use placeholder art where possible unless a card specifically requires generated art.
- Preserve combat, enemy, reward, room scaling, upgrade, and movement values as tunable settings where practical.

## Approved MVP Notes
- BA approval is recorded in `GDD.md` under `BA Approval - 2026-05-13`.
- Android layout is landscape-only with left movement stick and right aim/attack stick.
- Attacks autofire while the aim stick is held and stop when released.
- Coin rewards are automatic on enemy death; touch pickup and coin magnet are out of MVP.
- Archer double shot uses a 0.08 sec delay between the first and second arrow.
- Mage special upgrade uses unlimited penetration until wall collision for MVP.
- Future class special changes, including Mage homing projectiles, are out of scope until a new task changes the requirement.

## Approval Gate
Do not hand off to Coder until each implementation card has exact triggers, stop conditions, boundaries, and QA-verifiable acceptance criteria.
