# T29 - Implement Player Movement

Task ID: T29
Source MVP card: MVP-007
Title: Implement player movement using Rigidbody2D
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T22.
- T28.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Knowledge/decisions.md` decision `D01` and `D02`
- `Tasks/Open/T28_Coder-Create-Player-Input-Reader-Stackspire.md`

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

