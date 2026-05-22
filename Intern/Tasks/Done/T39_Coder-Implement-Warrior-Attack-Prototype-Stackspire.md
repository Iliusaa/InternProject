# T39 - Implement Warrior Attack Prototype

Task ID: T39
Source MVP card: MVP-017
Title: Implement Warrior melee attack prototype
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Combat/WarriorAttack.cs`.
- Added `WarriorAttack` to the Player in `InternUnity/Assets/Scenes/Game.unity`.
- Wired `WarriorAttack` to the scene `PlayerInputReader`.
- Serialized defaults: damage `2`, cooldown `0.55`, arc angle `180`, melee range `1.35`.
- Uses held attack input from `PlayerInputReader` and repeats by cooldown.
- Uses the aim direction, falling back to the last non-zero aim direction.
- Detects enemies on the `Enemy` layer inside melee range, filters them by aim arc, and applies `DamagePayload`.
- Supports multiple enemies in the arc and only damages each enemy once per swing.
- Added temporary debug arc rays and a short slash sprite flash.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/vfx/`, `projectiles/`, `ui/icons/`, and `characters/`.
- Imported `Intern/Assets/Generated/MVP/vfx/vfx_warrior_slash_arc_default.png` into `InternUnity/Assets/Generated/MVP/vfx/vfx_warrior_slash_arc_default.png`.
- Assigned the imported slash sprite to the Player child `WarriorSlashDebug` for temporary attack feedback.

## Verification

- Validated `WarriorAttack.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified play-mode attack behavior with three test enemies:
  - Two enemies inside the right-facing 180-degree arc each took `2` damage.
  - One enemy behind the player took no damage.
  - Multiple enemies in the arc were damaged by the same swing.
- Checked Unity console after implementation: 0 errors, 0 warnings.

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
