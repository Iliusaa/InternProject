# T30 - Implement Player Health and Damage

Task ID: T30
Source MVP card: MVP-008
Title: Implement player HP, invulnerability, death, and killed-by source
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/Combat/DamagePayload.cs`.
- Created `InternUnity/Assets/Scripts/Player/PlayerHealth.cs`.
- Added `PlayerHealth` to `InternUnity/Assets/Prefabs/Player/Player.prefab`.
- Added `PlayerHealth` to the existing `Player` scene instance in `InternUnity/Assets/Scenes/Game.unity`.
- Serialized `maxHearts` defaulting to `5`.
- Serialized `invulnerabilitySeconds` defaulting to `0.5`.
- Implemented `TakeDamage(DamagePayload payload)`.
- Added health changed event with current and max hearts.
- Added death event carrying the killing `DamagePayload`.
- Stored the killing payload through `KilledBy`.

## Verification

- Validated `DamagePayload.cs` with Unity script validation: 0 errors, 0 warnings.
- Validated `PlayerHealth.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified default health starts at 5 hearts.
- Verified damage removes hearts and fires the health changed event.
- Verified the 0.5 second invulnerability gate blocks rapid repeated damage.
- Verified lethal damage fires death once at 0 health.
- Verified death event and `KilledBy` include the killed-by source label and source object.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.

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
