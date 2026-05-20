# warrior_style_probe_01_gothic_ink

## Output

- Sprite: `warrior_style_probe_01_gothic_ink.png`
- Raw generation source: `.tmp/style_probe_raw/warrior/warrior_style_probe_01_gothic_ink_raw_chroma.png`

## Exact Final Generation Prompt Used

Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette. Warrior uses oversized sword and dark dried-crimson accents; Create an original Stackspire Warrior class sprite as 2D dark fantasy mobile game art, fixed three-quarter top-down perspective, one full-body character only. The Warrior is a tiny vulnerable doll-like adventurer with an oversized head, anxious eyes, compact body, dark dried-crimson cape, battered leather-and-iron armor, and an oversized chipped sword held forward so the sword silhouette reads before costume detail. Explore a gothic ink baseline direction inspired only by broad dark-fantasy dungeon mood: heavy uneven black ink outlines, angular black shadow shapes, distressed hand-painted texture, candlelit bone highlights, grim oppressive contrast, scuffed dungeon grime, original design. Use Stackspire palette: ink void #0E0B10 #17131A #262129, dungeon stone #343038 #4B4447 #6D6461, Warrior dark crimson #6E151D #9E2527, torch gold #8F5A24 #C18432 #E0B75C, bone parchment #B8A487 #D6C6A1. Keep bright damage red #D64A32 out of the costume except for no more than a tiny dull nick if needed. Centered square source canvas, generous transparent padding intent, bottom-center feet pivot, readable at 128x128 and 64x64, strong grayscale silhouette, no background scene, no text, no numbers, no watermark, no copied game character, no copied armor design, no proprietary symbols. Create the sprite on a perfectly flat solid #00FF00 chroma-key background for background removal. The background must be one uniform color with no shadows, gradients, texture, reflections, floor plane, or lighting variation. Keep the subject fully separated from the background with crisp edges and generous padding. Do not use #00FF00 anywhere in the subject. No cast shadow, no contact shadow, no reflection. Avoid: photorealistic, 3D render, anime clean lineart, glossy heroic fantasy, thin vector outline, realistic proportions, adult realistic anatomy, bright clean armor, colorful cheerful palette, noisy background, full scene, multiple characters, slash VFX, readable text, numbers, watermark, logo, extra limbs, malformed hands, deformed face, low quality, blurry, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied Darkest Dungeon character, copied UI symbols, copied proprietary designs.

## Exact Negative Prompt Used

photorealistic, 3D render, anime clean lineart, glossy heroic fantasy, thin vector outline, realistic proportions, adult realistic anatomy, bright clean armor, colorful cheerful palette, noisy background, full scene, multiple characters, slash VFX, readable text, numbers, watermark, logo, extra limbs, malformed hands, deformed face, low quality, blurry, realistic gore, body horror, dismemberment, exposed organs, lingering gore piles, copied game characters, copied Darkest Dungeon character, copied UI symbols, copied proprietary designs.

## Generation Settings

- Tool: built-in `image_gen`
- Model, seed, sampler, CFG, and steps: not exposed by the built-in tool.
- Source handling: generated on chroma-key source, then converted to RGBA PNG locally.
- Transparency pass: PowerShell/.NET bitmap matte using green-dominance removal because the local Python launcher was unavailable.
- Final dimensions: 1254 x 1254 PNG/RGBA.

## Style Direction Note

Gothic ink baseline. This is the closest continuity direction to the existing MVP class sprites, emphasizing thick black contour, chipped stone sword mass, and grim hand-painted texture.

## Reuse Suitability

Best suited for player classes, enemies, and world props. It is reusable for UI icons with simplification, but it carries too much character-detail density for small icon and VFX systems without trimming.
