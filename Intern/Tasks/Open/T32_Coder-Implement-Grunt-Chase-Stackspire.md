# T32 - Implement Grunt Chase

Task ID: T32
Source MVP card: MVP-010
Title: Implement basic Grunt chase and contact damage
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T31.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T31_Coder-Implement-Enemy-Base-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Enemies/GruntChase.cs`.
- Move Grunt toward player using `Rigidbody2D`.
- Add serialized move speed.
- Apply `PlayerHealth.TakeDamage` on contact with source label `Grunt`.
- Create Grunt prefab using `EnemyBase` plus `GruntChase`.

## Acceptance Criteria
- Grunt moves toward player.
- Grunt damages player on contact.
- Damage source label is `Grunt`.
- Grunt can die through EnemyBase damage.
- No Dasher or Shooter behavior is included.

