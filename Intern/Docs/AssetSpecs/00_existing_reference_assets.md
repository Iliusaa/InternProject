# Existing Reference Assets

## Status

The old wide generated HUD concepts and wide generated screen assets are obsolete after the portrait-only pivot. They were removed from `Assets/Generated/` and must not be treated as active production references for new generation.

## Usable References

| Reference | Current Use | Guardrails |
|---|---|---|
| `Docs/Visual-Design.md` | Required style reference for all new generation. | Use the described Stackspire traits directly; do not copy external games or old accidental symbols. |
| `Docs/UIUX_MVP_SPEC.md` | Required layout and component sizing reference. | Use 1080x1920 portrait phone bounds and the safe-area zones defined there. |
| `Assets/Generated/MVP/characters/`, `enemies/`, `projectiles/`, `ui/icons/`, compact `vfx/`, `world/doors/`, `world/props/` | Reusable non-layout sprite references if ArtDirector needs continuity. | Do not infer screen, HUD, or panel dimensions from old generated assets. |
| `Assets/Generated/Characters/player_*_chroma.png` | High-resolution raw character style references. | Chroma key green is a raw generation background only and is forbidden in final UI/gameplay visuals. |

## Do Not Use As Production References

- Deleted wide HUD concept PNGs under `Assets/Generated/UI/`.
- Deleted wide screen backgrounds under `Assets/Generated/MVP/screens/`.
- Deleted wide HUD, joystick, button, row, overlay, and damage flash sheets from the old MVP package.
- Deleted source atlases for old screens and old UI/control sheets.

## Portrait Rule

Any new screen background, overlay, damage edge flash, or room backdrop generated from this package must be composed for 1080x1920 portrait phone presentation unless its individual asset spec explicitly says it is a small reusable sprite.