# T29 - Implement Player Movement

Task ID: T29
Source MVP card: MVP-007
Title: Implement player movement using Rigidbody2D
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/Player/PlayerMovement.cs`.
- Created `InternUnity/Assets/Prefabs/Player/Player.prefab`.
- Added `Rigidbody2D`, `CapsuleCollider2D`, `SpriteRenderer`, and `PlayerMovement` to the prefab.
- Applied movement in `FixedUpdate()` through `Rigidbody2D.linearVelocity`.
- Serialized `baseMoveSpeed`, `horizontalMultiplier`, and `verticalMultiplier`.
- Set horizontal multiplier to `0.8` and vertical multiplier to `1.0`.
- Scaled movement by axis multipliers and clamps diagonal movement after multiplier application.
- Added a `Player` prefab instance to `InternUnity/Assets/Scenes/Game.unity`.
- Wired the scene `PlayerMovement` instance to the existing `PlayerInputReader`.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/` and found no generated player sprite already imported there.
- Used `Intern/Assets/Generated/MVP/characters/player_warrior.png` as the player placeholder sprite.
- Imported it into Unity at `InternUnity/Assets/Generated/MVP/characters/player_warrior.png` as a single sprite.

## Verification

- Validated `PlayerMovement.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Player.prefab` has `Rigidbody2D`, `Collider2D`, `SpriteRenderer`, and `PlayerMovement`.
- Verified `Game.unity` scene `Player` instance is wired to `PlayerInputReader`.
- Verified movement values with `baseMoveSpeed = 5`:
  - Full horizontal speed is `4`.
  - Full vertical speed is `5`.
  - Full diagonal speed is below vertical max after multipliers.
  - Partial horizontal input speed is `2`, slower than full tilt.
- Checked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T22.
- T28.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Knowledge/decisions.md` decision `D01` and `D02`
- `Tasks/Open/T28_Coder-Create-Player-Input-Reader-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- Before creating the Player placeholder sprite, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/characters/` for a suitable generated player asset.
- Prefer a matching generated player sprite if it preserves readability, collider setup, and portrait gameplay scale.
- In the task report, state which generated asset was used or why a placeholder remained necessary.

## Exact Deliverables
- Create placeholder Player prefab with `Rigidbody2D`, `Collider2D`, and placeholder sprite.
- Create `Assets/Scripts/Player/PlayerMovement.cs`.
- Apply movement in physics update through `Rigidbody2D`.
- Serialize base move speed.
- Apply horizontal multiplier `0.8`, vertical multiplier `1.0`, and normalize diagonal after multipliers.

## Acceptance Criteria
- Player moves from input.
- Partial analog tilt moves slower than full tilt.
- Full horizontal movement is slower than full vertical movement.
- Diagonal movement does not exceed intended speed.
- Movement uses `Rigidbody2D`, not transform-only movement.
