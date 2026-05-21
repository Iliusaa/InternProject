# Architect Handoff - Clarify Object Layer Rule

Target agent: [[Architect]]
Source: [[BA]]
Date: 2026-05-17
Deadline: 1 Architect session

## Task
Define the concrete Unity technical layer/sorting/collision plan behind the stakeholder request that "each object has a different layer."

## Routing Reason
The stakeholder confirmed this is a Unity technical layer request, not a design-facing GDD rule. Architect owns Unity component structure, conventions, and implementation-card routing.

## Inputs
- `GDD.md` - see `Blocked Requirement Clarifications` and `Stakeholder Clarifications - 2026-05-17`
- `Core/Conventions.md`
- `Knowledge/decisions.md`
- `Agents/Architect.md`
- `Agents/Architect-Memory.md`

## Required Output
- Decide which Unity Layers, Sorting Layers, collision matrix entries, tags, or prefab groups Stackspire needs for MVP objects.
- Document the rule in `Knowledge/decisions.md` or a relevant Architect handoff, not as a gameplay-facing GDD rule.
- If a stakeholder clarification is still needed for the technical plan, route a specific question back to [[BA]].
- Create or update implementation task cards only if the layer decision changes Unity setup work.

## Acceptance Criteria
- The decision states whether Unity layers, sorting layers, collision layers, tags, or prefab grouping are affected.
- The decision avoids assigning a unique Unity layer to every individual object unless there is a concrete collision/rendering reason.
- Downstream Coder cards can implement the rule without guessing.
- The technical implementation blocker is resolved or converted into explicit Coder setup tasks.

## Completion - 2026-05-21

Status: Complete.

Decision recorded in `Knowledge/decisions.md` as `D02 - Stackspire MVP object layer plan`.

Outcome:
- Unity Layers are grouped by collision/query need: `Player`, `Enemy`, `PlayerProjectile`, `EnemyProjectile`, `RoomBounds`, `Exit`, `PickupOrReward`, plus built-in `UI` and `Default`.
- Sorting Layers are grouped by 2D draw order: `Background`, `RoomFloor`, `RoomProps`, `Characters`, `Projectiles`, `VFX`, `Foreground`, `UI`.
- Collision matrix intent is documented for player, enemies, projectiles, room bounds, exit trigger, optional rewards, and UI.
- Tags stay minimal; only `Player` is allowed if scene wiring needs it. No per-enemy, per-projectile, or per-room tags.
- Prefab organization uses folders under `Assets/Prefabs/` instead of object-specific Unity Layers.
- Unique Unity Layers per object instance are rejected for MVP.

Coder follow-up:
- Created `Tasks/Open/Coder-Configure-Unity-Layers-Sorting-Collision-Stackspire.md`.
- Coder should run it after MVP-001 baseline setup and before Player, Enemy, Projectile, RoomBounds, and Exit prefab cards.

BA follow-up: none needed.
