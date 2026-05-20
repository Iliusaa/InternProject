---
type: AbstractFrame
---
# Pipeline

The ordered flow of work through the 8-agent team. [[PM]] owns this flow.

## Flow
```
Idea → [[GameDesigner]] → [[GDD]] → [[BA]] → validated GDD
     → [[Architect]] → task cards → [[UIUXDesigner]] + [[Coder]] + [[ArtDirector]]
     → [[QA]] → APK
```

## Trigger Table
| When this is ready | PM routes to |
|---|---|
| Game idea from human | [[GameDesigner]] |
| [[GDD]] written | [[BA]] |
| [[GDD]] validated | [[Architect]] |
| UI/UX spec needed | [[UIUXDesigner]] |
| Task card in `Tasks/` | [[UIUXDesigner]], [[Coder]], or [[ArtDirector]] |
| UI/UX spec ready | [[Architect]] for implementation cards or [[ArtDirector]] / [[Coder]] handoffs |
| Feature in Unity | [[QA]] |
| QA APPROVED | mark done in [[TASKS]] |
| QA BUG | [[Coder]] with bug report |

## Loop
QA bugs feed back to Coder without re-running BA or Architect.
Scope changes feed back to GameDesigner and restart from BA.
