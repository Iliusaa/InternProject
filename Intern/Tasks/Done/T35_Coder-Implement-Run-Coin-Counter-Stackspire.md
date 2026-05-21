# T35 - Implement Run Coin Counter

Task ID: T35
Source MVP card: MVP-013
Title: Implement current-run coin counter
Owner agent: [[Coder]]
Status: done

## Completion

Done on 2026-05-22.

- Created `InternUnity/Assets/Scripts/Run/RunCoinCounter.cs`.
- Updated `InternUnity/Assets/Scripts/Rooms/RoomManager.cs` to expose `EnemyDied`.
- Added `RunCoinCounter` to `InternUnity/Assets/Scenes/Game.unity`.
- Wired the scene `RunCoinCounter` to the scene `RoomManager`.
- Adds `+1` current-run coin per enemy death.
- Exposes `CurrentRunCoins`.
- Exposes `CoinsChanged` event.
- Added `ResetRunCoins()` for new run start.
- Added serialized `debugCurrentRunCoins` inspector display.

## Generated Asset Usage

- Checked `InternUnity/Assets/Generated/`, `Intern/Assets/Generated/MVP/world/pickups/`, and `Intern/Assets/Generated/MVP/ui/icons/`.
- Found generated coin/reward assets, including `world_coin_reward_visual_default.png` and `ui_icon_coin.png`.
- No generated asset was used because this task has no visible pickup or HUD surface, and MVP coins are awarded automatically on enemy death.

## Verification

- Validated `RunCoinCounter.cs` with Unity script validation: 0 errors, 0 warnings.
- Revalidated `RoomManager.cs` with Unity script validation: 0 errors, 0 warnings.
- Verified `Game.unity` has `RunCoinCounter` wired to `RoomManager`.
- Verified reset starts current-run coins at `0`.
- Verified first enemy death increments current-run coins to `1`.
- Verified second enemy death increments current-run coins to `2`.
- Verified `CoinsChanged` updates immediately on enemy death.
- Verified reset after kills returns current-run coins to `0`.
- Verified `debugCurrentRunCoins` mirrors current-run coin count for inspector display.
- Cleared and rechecked Unity console after implementation: 0 errors, 0 warnings.

## Dependencies
- T33.

## Required Inputs / Docs
- `GDD.md`
- `Core/Conventions.md`
- `Tasks/Open/T33_Coder-Implement-Room-Manager-Stackspire.md`
- `Tasks/Open/PM-Coder-Generated-Assets-Handoff-Stackspire.md`

## Generated Asset Requirement
- If this task surfaces any coin/reward visual or debug UI, check `InternUnity/Assets/Generated/` and `Intern/Assets/Generated/MVP/world/pickups/` plus `ui/icons/`.
- Prefer generated coin/reward assets only when they do not imply physical pickup behavior that is out of MVP.
- In the task report, state which generated asset was used, why none was needed, or why a placeholder remained necessary.

## Exact Deliverables
- Create `Assets/Scripts/Run/RunCoinCounter.cs`.
- Subscribe to enemy death events from RoomManager or spawned enemies.
- Add 1 current-run coin per enemy death.
- Expose coin changed event.
- Reset current-run coins on new run start.
- Add debug inspector display or log.

## Acceptance Criteria
- Each enemy death adds +1 current-run coin.
- Current-run coin count updates immediately on enemy death.
- Current-run coins can reset at run start.
- No pickup interaction is required.
