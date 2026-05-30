# GameDesigner Handoff - Revise Mobile Controls To Single Joystick

Target agent: [[GameDesigner]]
Source: [[PM]]
Date: 2026-05-30
Priority: High - Core Input Design Change
Deadline: 1 GameDesigner session

## Context

Stackspire's current mobile control direction and implementation references a dual-joystick setup: one joystick for movement and a second joystick for aiming or attacking. The product direction is changing to a simpler single movement joystick.

GameDesigner must update the design so Stackspire no longer requires a dedicated aim joystick while preserving the intended mobile gameplay feel: readable, fast, casual roguelite combat in portrait orientation.

## Task

Update the Stackspire mobile control design from a dual-joystick system to a single movement joystick.

Define how aiming and attacking work without a dedicated aim joystick, document the new player control scheme, and ensure the new scheme fits the intended gameplay experience.

## Chosen Agent

[[GameDesigner]]

## Routing Reason

This is a gameplay design and requirements decision. GameDesigner owns the GDD-level player experience, input rules, attack behavior, class feel, and design constraints. Coder should not implement this change until GameDesigner has clarified the new rules.

## Required References

Before editing, read:

- `GDD.md`
- `Docs/UIUX_MVP_SPEC.md`
- `Docs/Visual-Design.md`
- `Tasks/Done/T27_Coder-Implement-Virtual-Joystick-Stackspire.md`
- `Tasks/Done/T28_Coder-Create-Player-Input-Reader-Stackspire.md`
- `Tasks/Done/T39_Coder-Implement-Warrior-Attack-Prototype-Stackspire.md`
- `Agents/GameDesigner.md`
- `Agents/GameDesigner-Memory.md`

## Required Design Decisions

GameDesigner must define:

- Whether attacks are automatic, tap-triggered, cooldown-triggered, nearest-target driven, movement-direction driven, class-specific, or a hybrid.
- How the player aims attacks with only movement input.
- What happens while the player is standing still.
- How Warrior melee attacks choose direction and target.
- How Archer and Mage ranged attacks should aim when those classes are implemented.
- Whether attack behavior differs between normal attacks and future class special abilities.
- How target priority works when multiple enemies are present.
- How the control scheme avoids frustrating cases, such as attacking the wrong enemy, kiting endlessly, or requiring high precision on mobile.
- How the new scheme supports portrait phone ergonomics and leaves the right side of the screen free from the second joystick.

## Required Documentation Updates

Update `GDD.md` with:

- The new one-joystick control scheme.
- Exact aiming and attacking rules.
- Class-specific notes for Warrior, Archer, and Mage.
- Player-facing intent: what the player is expected to do moment-to-moment.
- Acceptance criteria for the revised controls.

Update `Docs/UIUX_MVP_SPEC.md` if it still references the second aim/attack joystick:

- Remove or supersede the bottom-right aim joystick requirement.
- Define the remaining movement joystick placement.
- Define any replacement attack affordance if one is required, such as tap-to-attack, auto-attack indicator, cooldown button, or no button.

If implementation cards are needed, create a separate follow-up task for [[Architect]] or [[Coder]] after the design is updated. Do not implement code in this task.

## Design Constraints

- MVP remains portrait mobile.
- MVP should use one movement joystick only.
- Do not add a second virtual stick under another name.
- Avoid controls that require precise touch aiming under combat pressure.
- Keep the combat loop understandable without tutorial-heavy UI.
- Preserve Stackspire's class identities: Warrior close-range, Archer ranged physical, Mage ranged occult.
- Keep UI/HUD clutter lower than the old dual-stick layout.
- Do not change unrelated economy, scoring, room, save, or class-selection rules unless the control design directly requires it.

## Acceptance Criteria

- `GDD.md` clearly states that Stackspire uses a single movement joystick.
- `GDD.md` defines aiming and attacking behavior without a dedicated aim joystick.
- Warrior, Archer, and Mage have clear aiming/attack behavior under the new scheme.
- Standing-still behavior and multiple-enemy target priority are documented.
- `Docs/UIUX_MVP_SPEC.md` no longer requires a bottom-right aim/attack joystick, or explicitly marks it obsolete.
- Any downstream implementation work is captured as a follow-up task rather than mixed into this design task.
