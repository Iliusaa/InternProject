# stackspire-probe04-asset-generator

## Skill Name

`stackspire-probe04-asset-generator`

## Skill Purpose

Generate original Stackspire assets using the approved Probe 04 mobile-grotesque style system.

Primary visual anchor:

`Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`

This skill supports immediate future generation of:

- Characters
- Enemies
- Props
- VFX
- UI icons
- UI panels

Probe 04 is the strongest style control. `Docs/Visual-Design.md`, `GDD.md`, and `Docs/AssetSpecs/` remain supporting context for gameplay, dimensions, palette, and export rules.

## Mandatory Core Anchor

Use this first sentence unchanged for Stackspire character, enemy, prop, VFX, UI icon, and UI panel prompts unless a specific asset type has no head, expression, or weapon. When adapting non-character assets, preserve the Stackspire style wording and replace only the role-specific second sentence.

```text
Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette.
```

For Warrior, the second sentence is:

```text
Warrior uses oversized sword and dark dried-crimson accents;
```

For other roles, the second sentence must adapt the role-defining silhouette while keeping the first sentence unchanged.

## Style Invariants Based On Probe 04

### Shape Language

- Characters use oversized heads, anxious expressions, compact bodies, and exaggerated role-defining objects.
- Enemies use grotesque threat silhouettes with exaggerated heads, limbs, mouths, claws, masks, or torsos.
- Props use a single exaggerated object silhouette that reads before material detail.
- VFX use one clear burst, streak, ring, puff, flash, or impact shape with no scene framing.
- UI icons use one chunky readable symbol, not a miniature illustration.
- UI panels use thick uneven frame shapes with readable mass, not ornate decorative frames.
- Interior forms stay simplified; do not rely on tiny costume, crack, scratch, or ornament detail for readability.

### Line

- Use thick uneven black ink outlines.
- Contours must feel rough, hand-drawn, and slightly distressed.
- Avoid clean vector precision, thin strokes, smooth geometric perfection, and polished mascot outlines.

### Texture

- Use scuffed painterly texture, grime, chips, scratches, and worn dungeon surfaces.
- Texture density should remain low-to-medium so the asset reads at mobile size.
- Avoid micro-hatching, excessive surface noise, or detail clusters that collapse at 64x64.

### Color

- Use the approved Stackspire palette:
  - Ink / void: `#0E0B10`, `#17131A`, `#262129`
  - Dungeon stone: `#343038`, `#4B4447`, `#6D6461`
  - Warrior dark crimson: `#6E151D`, `#9E2527`
  - Damage red: `#D64A32`, damage feedback only
  - Torch / coin gold: `#8F5A24`, `#C18432`, `#E0B75C`
  - Bone / parchment: `#B8A487`, `#D6C6A1`
  - Sickly green: `#35533B`, `#587642`, `#8A9B55`
  - Occult blue-violet: `#26364F`, `#415C78`, `#7B6A9B`
- Accent color is secondary to silhouette. A grayscale preview must still identify the role.
- Bright damage red must not be used for class identity, costume trim, non-damage UI, or decoration.

### Readability

- Every asset must read at 128x128 and still be identifiable at 64x64.
- Prioritize strong grayscale silhouettes over palette, costume detail, or material rendering.
- Use generous transparent padding around sprites and icons.
- Do not add micro-detail, tiny text, dense ornaments, or small repeated symbols.

### Background

- Reusable sprites, enemies, props, VFX, UI icons, and UI panels export as PNG/RGBA with transparent background.
- Raw chroma-key generation sources may use `#00FF00`, but final art must remove it.
- UI panels must be isolated panel assets, not full scenes, full screens, or composed layouts.
- Full-screen backgrounds and overlays are outside this skill unless a future task explicitly requests them.

### IP Safety

- Use Darkest Dungeon only as broad mood inspiration for gothic pressure, oppressive contrast, thick ink, harsh shadow blocks, and grim dungeon tone.
- Do not copy external characters, UI panels, frames, icons, symbols, layouts, portrait frames, decorative filigree, logos, brushwork, proportions, armor designs, monsters, or proprietary motifs.
- All outputs must be original Stackspire IP.

## Reusable Prompt Formula

```text
Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, [shape rule], [emotion rule], and [silhouette priority].

Create an original Stackspire [asset_category] for [gameplay_role], fixed [perspective], [single asset only], [background rule].

Subject: [subject].
Silhouette priority: [what must read at 64x64].
Shape language: [chunky / grotesque / compact / exaggerated].
Texture: scuffed painterly, chipped edges, rough ink.
Palette: approved Stackspire colors.
Readability: strong grayscale silhouette, readable at 128x128 and 64x64.
Restrictions: no copied IP, no watermark, no logo, no unnecessary text.
Output: PNG/RGBA, [size], [transparent or isolated panel].
```

## Universal Negative Prompt

```text
photorealistic, 3D render, realistic anatomy, tall heroic proportions, clean cute mascot, bright cheerful cartoon, thin outline, vector-flat precision, glossy fantasy armor, ornate filigree, elegant royal frame, cluttered background, full scene, unreadable silhouette, readable text unless requested, watermark, logo, extra limbs, malformed anatomy, blurry, low quality, realistic gore, body horror, dismemberment, copied Darkest Dungeon character, copied external game character, copied UI frame, copied icon, copied symbol, proprietary design
```

## Role Adaptation Rules

### Warrior

- Use oversized sword.
- Use dried-crimson accents.
- Make the weapon-first silhouette read before costume detail.
- Use the exact second sentence: `Warrior uses oversized sword and dark dried-crimson accents;`

### Archer

- Use oversized bow.
- Use nervous posture.
- Use muted green and dark leather/brown accents.
- Silhouette priority is the bow curve, quiver, and hunched aiming pose.

### Mage

- Use oversized staff.
- Use anxious occult silhouette.
- Use muted violet-blue shadow accents.
- Silhouette priority is staff head, robe mass, and small anxious face.

### Enemy

- Use grotesque threat silhouette.
- Exaggerate one limb, head, claw, mouth, shell, mask, or torso.
- Use sickly dungeon accent colors.
- Enemy must differ from players in grayscale shape and posture.

### Prop

- Use exaggerated object silhouette.
- Use chipped grimy material.
- Use transparent background.
- Avoid multiple objects unless the prop is a single joined object by design.

### VFX

- Use one clear effect shape: burst, streak, slash, puff, flash, glow, ring, or impact.
- Use brighter values than backgrounds but avoid visual clutter.
- Damage VFX may use `#D64A32`; non-damage VFX should use torch gold, bone, sickly green, or occult blue-violet as appropriate.
- Keep transparent background and no lingering gore piles.

### UI Icon

- Use one chunky simplified symbol.
- Use thick black outline and scuffed painterly texture.
- Use high-contrast shape and limited palette.
- No readable text, numerals, logos, or copied symbols.

### UI Panel

- Use thick uneven black frame.
- Use chunky simplified shape.
- Use scuffed stone, parchment, cloth, or metal texture.
- Use minimal or no text; Unity should render dynamic labels separately.
- Use original Stackspire design with no copied frame, ornate filigree, royal ornament, external layout, or proprietary motif.

## Generation Checklist

- The first sentence preserves the mandatory core anchor or an explicitly documented non-character adaptation.
- The second sentence states the asset role's silhouette rule.
- The prompt names Stackspire and the target asset category.
- The prompt states one asset only.
- The prompt states transparent background or isolated UI panel.
- Palette uses approved Stackspire colors.
- Bright damage red is reserved for damage feedback only.
- The result reads at 128x128 and 64x64.
- The result contains no readable text unless the specific task requests baked text.
- The result contains no copied external IP.
