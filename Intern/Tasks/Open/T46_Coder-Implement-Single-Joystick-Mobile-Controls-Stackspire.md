# Coder Handoff - Implement Single-Joystick Mobile Controls

Target agent: [[Coder]]
Source: [[PM]]
Date: 2026-05-30
Priority: High - Input Scheme Implementation
Status: Ready for Coder; `T45` completed 2026-05-30

## Context

PM requested Stackspire move from the current dual-joystick mobile controls to a single movement joystick. `T45_GameDesigner-Revise-Mobile-Controls-Single-Joystick-Stackspire.md` owns the design update and must define how aiming and attacking work without a dedicated aim joystick.

This Coder task implements that updated design. GameDesigner completed T45 on 2026-05-30 and updated `GDD.md` plus `Docs/UIUX_MVP_SPEC.md`.

## Task

Implement the new single-joystick mobile control scheme according to the updated design.

Remove or disable the aim joystick, update `PlayerInputReader` and related gameplay systems, keep editor keyboard/mouse controls working, and ensure the game remains fully playable.

## Chosen Agent

[[Coder]]

## Routing Reason

This task changes Unity scene wiring, input scripts, player attack behavior, and possibly UI prefab references. Coder owns implementation after GameDesigner has locked the design rules.

## Dependencies

- `T45` must be complete before implementation starts.
- Updated `GDD.md` must define the one-joystick aiming and attacking behavior.
- Updated `Docs/UIUX_MVP_SPEC.md` must remove or supersede the second aim/attack joystick.

## Required References

Before editing code or scenes, read:

- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Tasks/Done/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`
- `Tasks/Done/T28_Coder-Create-Player-Input-Reader-Stackspire.md`
- `Tasks/Done/T29_Coder-Implement-Player-Movement-Stackspire.md`
- `Tasks/Done/T37_Coder-Implement-Game-HUD-Prototype-Stackspire.md`
- `Tasks/Done/T39_Coder-Implement-Warrior-Attack-Prototype-Stackspire.md`
- `InternUnity/Assets/Scripts/Input/`
- `InternUnity/Assets/Scripts/Player/`
- `InternUnity/Assets/Scripts/Combat/`
- `InternUnity/Assets/Scenes/Game.unity`
- `InternUnity/Assets/Prefabs/UI/`

## Implementation Scope

Coder must:

- Remove or disable the bottom-right aim joystick from the Game scene and any related UI prefab wiring.
- Keep the single movement joystick functional in the intended thumb zone.
- Update `PlayerInputReader` so gameplay systems receive movement and the new aim/attack signals defined by T45.
- Update Warrior attack behavior to use the new aim/attack rules.
- Preserve editor keyboard/mouse fallback controls for local testing.
- Remove obsolete serialized references safely, or keep compatibility fields only when needed for migration.
- Ensure gameplay remains playable from Main Menu -> Class Select -> Game -> combat -> room clear/death flow.
- Avoid changing unrelated economy, scoring, save, class-selection, or enemy systems unless required by the new controls.

## Expected Design Integration

Implementation must follow the exact T45 design. If T45 defines:

- auto-attack, implement the auto-attack cadence, target selection, and cooldown rules;
- movement-direction aiming, use movement or last movement direction as specified;
- tap/click attack, preserve editor equivalent input;
- nearest-target logic, implement or reuse target acquisition deterministically;
- class-specific behavior, wire current Warrior behavior now and leave clear extension points for Archer and Mage.

Do not invent missing design decisions. If T45 leaves core behavior ambiguous, return the task to PM/GameDesigner instead of guessing.

## Verification

Run or perform the best available local verification:

- Unity compile check, if available.
- Relevant EditMode/PlayMode tests, if present.
- Manual scene inspection via Unity MCP, if available.
- Confirm no missing serialized references caused by removing/disabling the aim joystick.
- Confirm editor keyboard/mouse controls still move and attack.
- Confirm mobile control layout has only one movement joystick.
- Confirm Warrior can still damage enemies and complete the first room.

## Acceptance Criteria

- Game scene no longer shows or requires a second aim joystick.
- Player movement works through the single movement joystick.
- Aiming and attacking work according to the updated T45 design.
- Editor keyboard/mouse fallback remains usable.
- Warrior combat remains playable against existing enemies.
- No new console errors are introduced.
- Any obsolete aim joystick assets/scripts are either safely unused or documented for later cleanup.
- Coder records completion in `Agents/Coder-Memory.md`, `Sessions/YYYY-MM-DD.md`, and moves this handoff to `Tasks/Done/` only after verification.
