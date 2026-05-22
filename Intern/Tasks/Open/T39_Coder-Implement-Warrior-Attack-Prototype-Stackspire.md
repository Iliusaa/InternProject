# T39 - Implement Warrior Attack Prototype

Task ID: T39
Source MVP card: MVP-017
Title: Implement Warrior melee attack prototype
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T28.
- T31.
- T38.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T28_Coder-Create-Player-Input-Reader-Stackspire.md`
- `Tasks/Open/T31_Coder-Implement-Enemy-Base-Stackspire.md`
- `Tasks/Done/T38_Coder-Implement-Class-Selection-State-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating Warrior attack placeholder visuals or debug hit indicators, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/vfx/`, `projectiles/`, `ui/icons/`, and `characters/`.
- Prefer generated Warrior slash/VFX assets when they preserve attack-arc readability and do not obscure enemies or collision feedback.
- In the task report, state which generated asset was used or why a placeholder/debug visualization remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Combat/WarriorAttack.cs`.
- Reference `PlayerInputReader`.
- Serialize damage `2`, cooldown `0.55`, arc angle `180`, and short melee range.
- While attack is held, perform attacks by cooldown.
- Detect enemies inside the aim-direction arc.
- Apply `DamagePayload` to hit enemies.
- Add temporary debug visualization or hit logs.

## Acceptance Criteria
- Holding aim stick attacks repeatedly.
- Releasing aim stick stops new attacks.
- Attack uses the aim direction.
- Enemies inside the short 180-degree arc take damage.
- Enemies outside the arc do not take damage.
- Multiple enemies in the arc can be hit.
