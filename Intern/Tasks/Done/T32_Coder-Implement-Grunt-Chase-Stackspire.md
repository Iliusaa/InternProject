# T32 - Implement Grunt Chase

Task ID: T32
Source MVP card: MVP-010
Title: Implement basic Grunt chase and contact damage
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Enemies/GruntChase.cs`.
- Created `InternUnity/Assets/Prefabs/Enemies/Grunt.prefab`.
- Built the Grunt prefab with `EnemyBase` plus `GruntChase`.
- Moves the Grunt toward its target through `Rigidbody2D.linearVelocity`.
- Added serialized `moveSpeed`, defaulting to `6`.
- Added serialized `contactDamageHearts`, defaulting to `1`.
- Applies `PlayerHealth.TakeDamage` on collision contact.
- Uses `DamagePayload` source label `Grunt`.
- Keeps enemy death handling in `EnemyBase`; no Dasher or Shooter behavior was added.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and found `InternUnity/Assets/Generated/MVP/enemies/enemy_grunt.png` already imported from T31.
- Used `enemy_grunt.png` for `Grunt.prefab` because it matches the requested Grunt visual and preserves readable collider/prefab setup.

## Verification

- Validated `GruntChase.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Grunt.prefab` has `SpriteRenderer`, `Rigidbody2D`, `Collider2D`, `EnemyBase`, and `GruntChase`.
- Verified Grunt prefab uses enemy type label `Grunt`, max health `6`, move speed `6`, contact damage `1`, and damage source label `Grunt`.
- Verified Grunt velocity points toward an assigned player target.
- Verified contact damage removes 1 player heart through `PlayerHealth.TakeDamage`.
- Verified Grunt can die through `EnemyBase` damage.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T31.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T31_Coder-Implement-Enemy-Base-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating or finalizing the Grunt prefab visual, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/enemies/` for a suitable Grunt asset.
- Prefer `enemy_grunt` style assets when they preserve combat readability, collider setup, and portrait scene scale.
- In the task report, state which generated asset was used or why a placeholder remained necessary.

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
