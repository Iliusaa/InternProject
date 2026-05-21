---
type: InstanceFrame
owner: "[[Architect]]"
---
# Architect-Memory

> Write rule: append to **Recent**. Move oldest to **Archive** when Recent exceeds 3 entries.

## Recent
- 2026-05-15: Added the [[UIUXDesigner]] agent to the markdown agent architecture and created the first UI/UX MVP spec task handoff.
- 2026-05-19: Moved completed portrait rewrite task cards T12, T13, and T14 from `Tasks/Open/` to `Tasks/Done/` and updated `TASKS.md` references.
- 2026-05-21: Resolved Stackspire object-layer rule as technical Unity setup: grouped layers by collision/query need, sorting layers by 2D draw order, minimal tags, no per-object Unity layers; created Coder handoff for project settings.

## Archive
*(none)*

## Component Map
*(append here permanently — never archive)*

## Prefab Registry
| Prefab | Path | Owner Script |
|--------|------|-------------|
| *(none)* | | |

## Lessons
*(project-validated knowledge — overrides the professional KB in `Agents/X.md` when there is a conflict. Never archive. Append with session number.)*
- 2026-05-21: For Stackspire MVP, Unity Layers must represent collision/query categories, not individual object identity. Use components/events for gameplay identity and Sorting Layers for draw order.
