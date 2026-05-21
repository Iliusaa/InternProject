ArtDirector Handoff - Convert Probe 04 Into Reusable Asset-Generation Skill + One UI Panel Example
Target agent: [[ArtDirector]]
Source: [[PM]]
Date: 2026-05-20
Priority: High - Style systemization
Deadline: 1 ArtDirector session

⚡ RESUME TRACKER
LAST COMPLETED STEP: [ FILL IN BEFORE HITTING LIMIT ]
NEXT STEP TO EXECUTE: [ FILL IN BEFORE HITTING LIMIT ]

If you are resuming after a context limit: Check the tracker above. Skip all completed steps and continue from NEXT STEP TO EXECUTE. Do not redo prior work.


Execution Plan
Phase 0 — Read Required References (do this first, before any creation)
If resuming: always re-execute all of Phase 0 before continuing, regardless of what LAST COMPLETED STEP says. Reference files must be reloaded into context every session.
STEP 0.1 — Read GDD.md
STEP 0.2 — Read Docs/Visual-Design.md
STEP 0.3 — Read Docs/AssetSpecs/00_style_guide.md
STEP 0.4 — Read Docs/AssetSpecs/00_dimensions_and_naming.md
STEP 0.5 — Read Agents/ArtDirector.md
STEP 0.6 — Read Agents/ArtDirector-Memory.md
STEP 0.7 — View Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png
STEP 0.8 — Read Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.prompt.md

Phase 1 — Create Reusable Asset-Generation Skill Document
STEP 1.1 — Create file: Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md
STEP 1.2 — Write Section 1: Skill Name (stackspire-probe04-asset-generator)
STEP 1.3 — Write Section 2: Skill Purpose (characters, enemies, props, VFX, UI icons, UI panels)
STEP 1.4 — Write Section 3: Style Invariants (Shape Language, Line, Texture, Color, Readability, Background, IP Safety)
STEP 1.5 — Write Section 4: Reusable Prompt Formula (universal template)
STEP 1.6 — Write Section 5: Universal Negative Prompt
STEP 1.7 — Write Section 6: Role Adaptation Rules (Warrior, Archer, Mage, Enemy, Prop, UI)
STEP 1.8 — Save and verify file is complete

Phase 2 — Generate UI Panel Example
STEP 2.1 — Generate UI panel PNG using the required prompt + universal negative prompt
Save as: Assets/Generated/StyleProbes/warrior/probe04_ui_panel_example.png
STEP 2.2 — Create matching prompt file
Save as: Assets/Generated/StyleProbes/warrior/probe04_ui_panel_example.prompt.md
(Must contain the exact prompt used for generation)

Phase 3 — Completion
STEP 3.1 — Verify acceptance criteria (checklist below)
STEP 3.2 — Record what was generated in session log / ArtDirector-Memory
STEP 3.3 — Move this task to Tasks/Done/

Goal
Probe 04 (warrior_style_probe_04_mobile_grotesque.png) is now the approved visual direction.
ArtDirector must:

Convert Probe 04 into an actual reusable asset-generation skill for Stackspire.
Generate exactly one UI panel example in the same Probe 04 style.
Save the exact generation prompt used for the UI panel.

This is not a style note or draft seed.
This must be a reusable asset-generation skill that can immediately be used for future generation of:

Player sprites
Enemy sprites
Props
VFX
UI icons
UI panels

Primary Visual Anchor
Use this as the style anchor:
Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png
This is the canonical Stackspire visual direction moving forward.
Mandatory Flux Style Anchor
The reusable skill must include this exact core anchor:
Keep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, oversized head, anxious expression, and weapon-first silhouette.
For Warrior:
Warrior uses oversized sword and dark dried-crimson accents;
For other asset types, the second sentence must adapt per role while keeping the first sentence unchanged.
This line must be treated as the strongest stylistic control mechanism.
Visual-Design.md is supportive context, not the primary generation anchor.
Required Project References
Before creating the skill or generating the UI panel, review (see Phase 0 above):

GDD.md
Docs/Visual-Design.md
Docs/AssetSpecs/00_style_guide.md
Docs/AssetSpecs/00_dimensions_and_naming.md
Agents/ArtDirector.md
Agents/ArtDirector-Memory.md
Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png
Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.prompt.md

Darkest Dungeon Guardrail
Darkest Dungeon may be used only as broad inspiration for:

Gothic pressure
Oppressive contrast
Thick ink
Harsh shadow blocks
Grim dungeon mood

Do NOT copy:

Characters
UI panels
Frames
Icons
Symbols
Layouts
Portrait frames
Decorative filigree
Logos
Brushwork
Proportions
Armor designs

All outputs must be original Stackspire IP.

Part 1 - Create Reusable Asset-Generation Skill
Create:
Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md
This must function as a reusable skill specification for future asset generation.
It must contain:
1. Skill Name
stackspire-probe04-asset-generator
2. Skill Purpose
Explain that the skill generates Stackspire assets using the Probe 04 mobile-grotesque style system.
Clarify it supports:

Characters
Enemies
Props
VFX
UI icons
UI panels

3. Style Invariants Based On Probe 04
Document these reusable rules:
Shape Language

Oversized head for characters
Compact body
Exaggerated role-defining object
Chunky readable silhouette
Simplified interior forms

Line

Thick uneven black ink outline
Rough, hand-drawn contour
No clean vector precision

Texture

Scuffed painterly texture
Grime, chips, scratches
Low-to-medium interior detail

Color

Approved Stackspire palette
Accent color secondary to silhouette
No bright damage red except damage feedback

Readability

Must read at 128x128 and 64x64
Strong grayscale silhouette
No micro-detail

Background

Sprites use transparent background
UI panels use isolated panel, not full scene

IP Safety

No copied external characters
No copied UI frames
No copied icons
No proprietary symbols
No recognizable frame designs

4. Reusable Prompt Formula
Include this universal prompt template:
textKeep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, [shape rule], [emotion rule], and [silhouette priority].

Create an original Stackspire [asset_category] for [gameplay_role], fixed [perspective], [single asset only], [background rule].

Subject: [subject].
Silhouette priority: [what must read at 64x64].
Shape language: [chunky / grotesque / compact / exaggerated].
Texture: scuffed painterly, chipped edges, rough ink.
Palette: approved Stackspire colors.
Readability: strong grayscale silhouette, readable at 128x128 and 64x64.
Restrictions: no copied IP, no watermark, no logo, no unnecessary text.
Output: PNG/RGBA, [size], [transparent or isolated panel].
5. Universal Negative Prompt
Include:
textphotorealistic, 3D render, realistic anatomy, tall heroic proportions, clean cute mascot, bright cheerful cartoon, thin outline, vector-flat precision, glossy fantasy armor, ornate filigree, elegant royal frame, cluttered background, full scene, unreadable silhouette, readable text unless requested, watermark, logo, extra limbs, malformed anatomy, blurry, low quality, realistic gore, body horror, dismemberment, copied Darkest Dungeon character, copied external game character, copied UI frame, copied icon, copied symbol, proprietary design
6. Role Adaptation Rules
Include adaptation rules:

Warrior:

oversized sword
dried-crimson accents
weapon-first silhouette


Archer:

oversized bow
nervous posture
muted green/brown accents


Mage:

oversized staff
anxious occult silhouette
muted violet-blue shadow accents


Enemy:

grotesque threat silhouette
exaggerated limb or head
sickly dungeon accent colors


Prop:

exaggerated object silhouette
chipped grimy material
transparent background


UI:

thick uneven black frame
chunky simplified shape
scuffed stone/parchment/metal texture
minimal or no text
original Stackspire design




Part 2 - Generate One UI Panel Example
Generate exactly one UI panel using Probe 04 style.
Create:
Assets/Generated/StyleProbes/warrior/probe04_ui_panel_example.png
Create matching prompt file:
Assets/Generated/StyleProbes/warrior/probe04_ui_panel_example.prompt.md
UI Panel Requirements

Thick uneven black ink frame
Chunky grotesque silhouette
Scuffed painterly stone + parchment
Dried-crimson cloth accent
Muted torch-gold scratches
No ornate filigree
No copied frame design
No readable text
No full scene
512x512 source canvas
Transparent background outside panel
Readable at mobile size

Required UI Panel Prompt
Use this base prompt:
textKeep the same Stackspire grotesque dark fantasy cartoon style, thick black ink outlines, scuffed painterly texture, chunky readable silhouette, dark funny-sad dungeon mood, and mobile-first readability.

Create one original Stackspire mobile UI panel, transparent background outside the panel, no full scene. The panel is a compact grotesque character-card frame for a future character selection or reward screen. It has a thick uneven black ink stone frame, chunky simplified shape, scuffed painterly parchment center, small empty circular portrait slot near the top, three crude abstract stat-glyph slots near the bottom, chipped corners, dried-crimson cloth tag accent, and muted torch-gold edge scratches. Use dark stone colors #0E0B10 #17131A #262129 #343038 #4B4447 #6D6461, bone parchment #B8A487 #D6C6A1, dried crimson #6E151D #9E2527, and muted torch gold #8F5A24 #C18432 #E0B75C. Make it original Stackspire UI, not copied from any external game. Strong grayscale readability, thick uneven silhouette, low-to-medium detail, no readable text, no watermark, no logo.
Use the universal negative prompt defined in the skill.
Completion Rules

Do not overwrite MVP assets.
Do not generate extra sprites beyond probe04_ui_panel_example.png.
Do not create QA, Coder, MVP integration, or packaged marketplace handoffs unless PM explicitly requests them later.
When finished, record what was generated and move this task to Tasks/Done/.

Acceptance Criteria

Probe 04 becomes the official reusable asset-generation skill.
Skill document is created and complete.
Exactly one UI panel PNG is generated.
Exactly one UI panel prompt file is created.
UI panel matches Probe 04 style.
No copied external UI designs.
No extra sprites generated.
No MVP assets overwritten.
No QA handoff or approval.

