# T23 - Audit Unity Baseline

Task ID: T23
Source MVP card: MVP-001
Title: Audit the current Unity project and establish a clean runnable baseline
Owner agent: [[Coder]]
Status: pending

## Dependencies
- None.

## Required Inputs / Docs
- `InternUnity/`
- `InternUnity/Packages/manifest.json`
- `InternUnity/ProjectSettings/`
- `InternUnity/Assets/Scenes/SampleScene.unity`
- `Core/Conventions.md`

## Exact Deliverables
- Verify current packages, input backend, URP 2D assets, existing scenes, and console state.
- Create missing baseline folders if needed: `Assets/Scripts`, `Assets/Prefabs`, `Assets/ScriptableObjects`, `Assets/Generated`, `Assets/UI`, `Assets/Audio`, `Assets/Tests`.
- Document current Unity package/input/render pipeline state and blocking setup gaps.
- Confirm the current scene enters Play Mode without setup-related console errors.

## Acceptance Criteria
- `InternUnity/` has the required MVP folder structure.
- The project enters Play Mode without setup-related console errors.
- Current Unity package, input, and render pipeline state is documented.
- No gameplay behavior is introduced.

