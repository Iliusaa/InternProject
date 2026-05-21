# Architecture & Design Decisions

> Append to **Index** first (one line), then add full entry below.
> Codex reads the Index only — follow a specific DXX link only if that decision is relevant to the current task.

## Index
| ID | Title | Owner | Summary |
|----|-------|-------|---------|
| D00 | .md memory system | [[PM]] | Chose .md over JSON — append-safe, Obsidian-native |
| D01 | Rigidbody2D for movement | [[Architect]] | Never Transform.Translate — physics engine handles collisions |
| D02 | Stackspire MVP object layer plan | [[Architect]] | Unity layers are grouped by collision/query need, sorting layers handle 2D draw order, tags stay minimal, and no unique layer is assigned per object instance |

---

## D00 — Use .md-based memory system

**Decision**: All agent state in plain .md files — STATUS, TASKS, CONTEXT, per-agent Memory, Sessions logs.
**Rationale**: Codex reads .md natively. Append is safer than full-file JSON rewrite. No encoding issues. Obsidian renders it.
**Rejected**: MEMORY.json — full-file rewrites, no append, encoding failures with non-ASCII.
Related: [[STATUS]] · [[TASKS]] · [[CONTEXT]] · [[Memory]]

---

## D01 — Rigidbody2D for all movement

**Decision**: All moving GameObjects use `Rigidbody2D` forces/velocity. Never `Transform.Translate`.
**Rationale**: Transform bypasses the physics engine → missed collision events.
**Rejected**: Transform.Translate — visually works but breaks OnCollisionEnter2D.
Related: [[Conventions]] · [[Coder]]

---

## D02 — Stackspire MVP object layer plan

**Decision**: Stackspire does not assign a unique Unity Layer to every individual object. Unity Layers are reserved for collision/query categories; Sorting Layers handle 2D render order; tags are limited to high-value lookup/debug labels; prefab folder grouping handles asset organization.

**Unity Layers**:
- `Player`
- `Enemy`
- `PlayerProjectile`
- `EnemyProjectile`
- `RoomBounds`
- `Exit`
- `PickupOrReward`
- Keep built-in `UI` for Canvas/EventSystem raycasts.
- Keep `Default` for non-interactive scenery and placeholders that do not need collision filtering.

**Sorting Layers**:
- `Background`
- `RoomFloor`
- `RoomProps`
- `Characters`
- `Projectiles`
- `VFX`
- `Foreground`
- `UI`

**Collision Matrix Intent**:
- `Player` collides with `Enemy`, `EnemyProjectile`, `RoomBounds`, `Exit`, and optionally `PickupOrReward`; it does not collide with `PlayerProjectile`.
- `Enemy` collides with `Player`, `PlayerProjectile`, and `RoomBounds`; enemy-to-enemy collision is off for MVP unless Coder finds body pushing is needed for readability.
- `PlayerProjectile` collides with `Enemy` and `RoomBounds`; it does not collide with `Player`, `EnemyProjectile`, `Exit`, `PickupOrReward`, or UI.
- `EnemyProjectile` collides with `Player` and `RoomBounds`; it does not collide with `Enemy`, `PlayerProjectile`, `Exit`, `PickupOrReward`, or UI.
- `RoomBounds` collides with `Player`, `Enemy`, `PlayerProjectile`, and `EnemyProjectile`.
- `Exit` uses a trigger collider that only needs to react to `Player`.
- `PickupOrReward` is optional for MVP because coins are awarded automatically; if used for reward visuals, collisions should be trigger-only and player-facing.
- `UI` does not participate in 2D physics collisions.

**Tags**:
- Add `Player` only if scene/prefab wiring needs a stable target lookup.
- Add `MainCamera` only if Unity has not already created it.
- Do not add per-enemy, per-projectile, or per-room tags for MVP; use components, serialized references, and events instead.

**Prefab Groups**:
- Use folders under `Assets/Prefabs/`: `Player`, `Enemies`, `Projectiles`, `Rooms`, `UI`, `VFX`, and `Debug`.
- Prefab grouping is for project organization only and must not substitute for collision layers or sorting layers.

**Rationale**: Unity has a limited layer budget and layers should express physics/query behavior. Per-object layers would create unnecessary collision matrix complexity and make MVP prefabs harder to maintain.

**Rejected**: One unique Unity Layer per object instance. There is no concrete collision, rendering, or raycast reason for that in the Stackspire MVP.

**Implementation**: Coder should implement this through the new layer setup handoff before creating Player, Enemy, Projectile, RoomBounds, and Exit prefabs. Current `TagManager.asset` still has only built-in layers and `Default` sorting layer.

Related: [[Conventions]] · [[Coder]] · `Tasks/Open/T22_Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md`

---

> Add new decisions here. One line in Index + full entry below the last `---`.
