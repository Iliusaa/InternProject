# T31 - Implement Enemy Base

Task ID: T31
Source MVP card: MVP-009
Title: Implement shared enemy health, damage, labels, and death events
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/Enemies/EnemyBase.cs`.
- Created `InternUnity/Assets/Prefabs/Enemies/EnemyBase.prefab`.
- Added `SpriteRenderer`, `Rigidbody2D`, `CapsuleCollider2D`, and `EnemyBase` to the prefab.
- Implemented damage receiving through `DamagePayload`.
- Added serialized `enemyTypeLabel`, `maxHealth`, and `disableOnDeath`.
- Exposed `EnemyTypeLabel`, `MaxHealth`, `CurrentHealth`, and `IsDead`.
- Added health changed event and one-shot death event.
- Deactivates the enemy on death by default.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and found no generated enemy sprite already imported there.
- Used `Intern/Assets/Generated/MVP/enemies/enemy_grunt.png` for the enemy base placeholder because it is the simplest readable MVP enemy silhouette.
- Imported it into Unity at `InternUnity/Assets/Generated/MVP/enemies/enemy_grunt.png` as a single sprite.

## Verification

- Validated `EnemyBase.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `EnemyBase.prefab` has `SpriteRenderer`, `Rigidbody2D`, `Collider2D`, and `EnemyBase`.
- Verified the prefab uses the `Enemy` layer and `Characters` sorting layer.
- Verified enemy damage reduces health.
- Verified death happens at 0 health and deactivates the enemy.
- Verified death event fires exactly once.
- Verified repeated damage after death is ignored.
- Verified enemy type label is available to listeners.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.

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
