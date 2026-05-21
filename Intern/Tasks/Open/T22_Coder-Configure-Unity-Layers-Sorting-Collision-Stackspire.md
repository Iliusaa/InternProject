# T22 - Configure Unity Layers, Sorting Layers, and Collision Matrix

Task ID: T22
Source MVP card: Global setup dependency from `MVP_First_Task_Cards.md`
Title: Configure Unity layers, sorting layers, and collision matrix
Owner agent: [[Coder]]
Status: pending
Source: [[Architect]]
Date: 2026-05-21
Priority: P0

## Dependencies
- T23.
- Architect decision `D02`.

## Required Inputs / Docs
- `Knowledge/decisions.md` decision `D02`
- `Core/Conventions.md`
- `Backlog/MVP_Architecture_Backlog.md` item `ARCH-BL-003`
- `Tasks/Open/MVP_First_Task_Cards.md`

## Exact Deliverables
- Configure the Unity technical object grouping required by Stackspire MVP before gameplay prefabs are built.
- Add required Unity Layers.
- Add required Sorting Layers.
- Configure the Physics2D collision matrix.
- Keep tags minimal.
- Create or reserve prefab folder groups under `InternUnity/Assets/Prefabs/`.

## Required Unity Layers
- `Player`
- `Enemy`
- `PlayerProjectile`
- `EnemyProjectile`
- `RoomBounds`
- `Exit`
- `PickupOrReward`
- Keep built-in `UI`.
- Keep `Default` for non-interactive scenery/placeholders.

## Required Sorting Layers
- `Background`
- `RoomFloor`
- `RoomProps`
- `Characters`
- `Projectiles`
- `VFX`
- `Foreground`
- `UI`

## Collision Matrix Rule
- `Player`: collides with `Enemy`, `EnemyProjectile`, `RoomBounds`, `Exit`, optional `PickupOrReward`.
- `Enemy`: collides with `Player`, `PlayerProjectile`, `RoomBounds`; enemy-to-enemy collision off for MVP unless readability testing requires it.
- `PlayerProjectile`: collides with `Enemy`, `RoomBounds`.
- `EnemyProjectile`: collides with `Player`, `RoomBounds`.
- `RoomBounds`: collides with `Player`, `Enemy`, `PlayerProjectile`, `EnemyProjectile`.
- `Exit`: trigger-only, reacts to `Player`.
- `PickupOrReward`: optional trigger-only player-facing layer; physical coin pickup is out of MVP.
- `UI`: no 2D physics collisions.

## Tags
- Add `Player` only if needed for stable scene wiring.
- Do not create per-enemy, per-projectile, or per-room tags for MVP.

## Prefab Folder Groups
Create or reserve these folders under `InternUnity/Assets/Prefabs/` when the baseline folder setup runs:
- `Player`
- `Enemies`
- `Projectiles`
- `Rooms`
- `UI`
- `VFX`
- `Debug`

## Acceptance Criteria
- Unity project contains the required Unity Layers.
- Unity project contains the required Sorting Layers in the listed conceptual order.
- Physics2D collision matrix matches the rule above.
- No unique Unity Layer is created for individual object instances.
- Coder documents any Unity limitation or layer-name conflict found during setup.

## Out Of Scope
- Gameplay components.
- Prefab implementation beyond folders/placeholders needed to verify setup.
- Final art import settings.
