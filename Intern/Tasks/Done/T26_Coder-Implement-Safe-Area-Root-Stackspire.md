# T26 - Implement Safe Area Root

Task ID: T26
Source MVP card: MVP-004
Title: Implement reusable safe-area support for portrait UI
Owner agent: [[Coder]]
Status: done

## Completion
Done on 2026-05-21.

- Created `InternUnity/Assets/Scripts/UI/SafeAreaRoot.cs`.
- `SafeAreaRoot` caches its `RectTransform`, applies `Screen.safeArea` as normalized anchors on enable, and reapplies when screen size or safe area changes.
- Added `SafeAreaRoot` under `Assets/Prefabs/UI/PortraitCanvasRoot.prefab`.
- Added `SafeAreaRoot` under the Canvas in `MainMenu`, `ClassSelect`, `Game`, and `GameOver`.
- Moved existing placeholder Canvas children under each scene `SafeAreaRoot`.
- Verified the script with Unity validation and confirmed no console errors.

## Dependencies
- T25.

## Required Inputs / Docs
- `Docs/UIUX_MVP_SPEC.md`
- `Tasks/Open/T25_Coder-Create-Portrait-Canvas-Root-Stackspire.md`
- `Core/Conventions.md`

## Exact Deliverables
- Create `Assets/Scripts/UI/SafeAreaRoot.cs`.
- Adjust attached `RectTransform` anchors to match `Screen.safeArea` on enable and when resolution/safe area changes.
- Add `SafeAreaRoot` under the portrait Canvas.
- Move placeholder screen content under `SafeAreaRoot`.

## Acceptance Criteria
- `SafeAreaRoot` stretches to `Screen.safeArea`.
- UI children remain visible within safe area.
- Behavior works when Game view aspect changes.
- No screen-specific UI logic is embedded in `SafeAreaRoot`.
