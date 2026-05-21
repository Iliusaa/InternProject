# T31 - Implement Enemy Base

Task ID: T31
Source MVP card: MVP-009
Title: Implement shared enemy health, damage, labels, and death events
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T22.
- T30.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Knowledge/decisions.md` decision `D02`
- `Tasks/Open/T30_Coder-Implement-Player-Health-Damage-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating the enemy base placeholder sprite, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/enemies/`.
- Prefer a matching generated enemy sprite if it preserves readability, sorting, collider setup, and prefab clarity.
- In the task report, state which generated asset was used or why a placeholder remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Enemies/EnemyBase.cs`.
- Use `DamagePayload` for damage receiving.
- Add serialized enemy type label and max health.
- Fire death event exactly once.
- Disable or destroy enemy on death.
- Create placeholder enemy base prefab.

## Acceptance Criteria
- Enemy can receive damage.
- Enemy dies when health reaches 0.
- Death event fires exactly once.
- Enemy type label is available to listeners.
- Placeholder prefab exists.
