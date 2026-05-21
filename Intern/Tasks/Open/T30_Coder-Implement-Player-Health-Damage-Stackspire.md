# T30 - Implement Player Health and Damage

Task ID: T30
Source MVP card: MVP-008
Title: Implement player HP, invulnerability, death, and killed-by source
Owner agent: [[Coder]]
Status: pending

## Dependencies
- T29.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T29_Coder-Implement-Player-Movement-Stackspire.md`

## Exact Deliverables
- Create `Assets/Scripts/Combat/DamagePayload.cs`.
- Create `Assets/Scripts/Player/PlayerHealth.cs`.
- Add serialized max hearts defaulting to 5.
- Implement `TakeDamage(DamagePayload payload)`, 0.5 second invulnerability, health changed event, death event, and killed-by source storage.

## Acceptance Criteria
- Player starts with 5 hearts by default.
- Damage removes hearts.
- Invulnerability prevents rapid repeated damage.
- Death event fires once at 0 health.
- Death event includes killed-by source.

