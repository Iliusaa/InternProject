# BA Coder Kickoff Clarifications - Stackspire MVP

Target agent: [[Coder]]
Source: [[BA]]
Date: 2026-05-21
Status: Approved for implementation by [[BA]] on 2026-05-21.

## Purpose
Document the remaining BA questions, stakeholder answers, implementation constraints, and BA approval before Coder begins the Stackspire MVP Unity implementation.

## Approval
BA approves Coder kickoff for the Stackspire MVP.

Coder should begin by reading the referenced design/task documents, importing the approved generated assets into Unity, and implementing the first playable vertical slice:

`Start Run -> Select Class -> Clear Rooms -> Die or Complete Run -> View GameOver -> Restart, Upgrade, or Menu`

## Questions and Answers

### 1. Scope
Question: What exact feature/change is the coder implementing?

Answer: Coder needs to add all available assets to the Unity project and start creating scenes and meaningful gameplay from those assets. Build the Stackspire MVP: portrait Android roguelite loop, combat, scoring, coins, upgrades, and gameover.

### 2. User Flow
Question: What should the user be able to do from start to finish?

Answer: MVP user flow must allow the user to use the systems described in the GDD:

`Start Run -> Select Class -> Clear Rooms -> Die -> View GameOver -> Restart, Upgrade, or Menu`

The run-completion path is also required:

`Start Run -> Select Class -> Clear Two Rooms -> Exit through North Gate -> View GameOver/Run Result -> Restart, Upgrade, or Menu`

### 3. Acceptance Criteria
Question: What conditions prove the work is complete?

Answer: Acceptance criteria are described in each Coder task. Global MVP criteria:

- Portrait reference target is 1080 x 1920.
- Controls and HUD work.
- Enemies affect score and coins.
- Exit unlocks after room clear.
- Saves persist.

### 4. Design and UI
Question: Is there an approved mockup, existing screen, or style pattern to follow?

Answer: Yes. UI/UX requirements are described in `Intern/Docs/UIUX_MVP_SPEC.md`. Style is described in the ArtDesigner skill and mandatory style anchor. Probe 04 is approved as the canonical Stackspire visual direction:

- `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`
- `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`

### 5. Data and API
Question: What data is needed, where does it come from, and are API contracts already defined?

Answer: There is no external API. Required local save data:

- High score
- Banked coins
- Upgrade levels

Coder must use UnityMCP to connect to Unity.

### 6. Edge Cases
Question: What should happen for empty states, errors, invalid input, loading, and permissions?

Answer: Death, pause restart, coin banking, killed-by, and room-clear timing are defined in the project documentation and tasks. Coder should follow the GDD and task acceptance criteria.

### 7. Out of Scope
Question: What should the coder explicitly avoid changing or adding?

Answer: The following are out of scope for MVP:

- Procedural layouts
- Bosses
- Drops
- Consumables
- Extra classes
- Multiplayer
- Leaderboards
- Ads
- IAP
- Analytics
- Debug save-clear tooling unless Architect or QA approves it first

### 8. Testing Expectation
Question: Are unit, integration, UI, or manual test cases required?

Answer: QA checklist comes after GameOver flow. Acceptance criteria are QA-verifiable. Coder should implement against the task acceptance criteria and leave the vertical slice ready for QA checklist creation.

### 9. Priority
Question: Is there a must-have vs nice-to-have split?

Answer: MVP systems are must-have. Audio is listed as MVP. Advanced content is out of scope.

### 10. Release Constraints
Question: Are there deadline, platform/browser support, or deployment considerations?

Answer: Android portrait-only. Target 60 FPS. Reference resolution is 1080 x 1920.

### 11. Source Documentation Location
Question: Where are the GDD, UIUX_MVP_SPEC, task acceptance criteria, and ArtDesigner style anchor located in the repo?

Answer:

- `Intern/GDD.md`
- `Intern/Docs/UIUX_MVP_SPEC.md`
- `Intern/Tasks/*`
- `Intern/Docs/Visual-Design.md`
- Style anchor: `Assets/Generated/StyleProbes/warrior/warrior_style_probe_04_mobile_grotesque.png`
- Probe 04 asset-generation skill: `Assets/Generated/StyleProbes/warrior/stackspire_probe04_asset_generation_skill.md`

### 12. Asset Source
Question: Are all approved assets already inside the Unity project, or does coder need to import from a specific folder/package?

Answer: Not all assets are in Unity. Generated and approved assets are under `Intern/Assets/Generated`. Unity currently lacks them, so Coder must import them into Unity.

### 13. Class Selection
Question: Which MVP classes are allowed?

Answer: Warrior, Archer, and Mage only.

### 14. Room Count and Run Length
Question: For MVP, how many rooms should a run contain before looping, escalating, or ending?

Answer: MVP is exactly two working rooms. For MVP, these two rooms need every enemy type in the game, with one of each MVP enemy type. Save room enemy mixes for later game expansion. After the two rooms are completed by exiting through the north gate, the run ends.

### 15. Upgrade List
Question: Which upgrades are in MVP, including max levels, costs, and effects?

Answer:

- Toughness: 5 levels
- Power: 5 levels
- Agility: 5 levels
- Greed: 5 levels
- Class specials: 1 level, 500 coins

### 16. Combat Baseline
Question: What are the required player attack, enemy behavior, health/damage, and death rules for first playable?

Answer:

- Warrior uses slash.
- Archer shoots arrow.
- Mage casts bolt.
- Grunt chases.
- Dasher lunges.
- Shooter fires.
- Player health reaching 0 ends the run.

### 17. Save Reset and Developer Tooling
Question: Should there be a debug way to clear local save data during QA?

Answer: Not specified. Ask Architect or QA before adding debug save-clear tooling.

### 18. Unity Scene Structure
Question: Is there an expected scene naming/setup convention, or should coder create it?

Answer: Coder should create the scene structure. Current GDD expects:

- `MainMenu`
- `ClassSelect`
- `UpgradeMenu`
- `Game`
- `GameOver`

Unity currently only has `SampleScene`.

## Implementation Direction
Coder should treat these as kickoff decisions:

- Read all task acceptance criteria before implementation.
- Import approved/generated assets from `Intern/Assets/Generated` into Unity.
- Use Probe 04 as the canonical visual direction.
- Create the expected scenes in Unity.
- Build the MVP around exactly two playable rooms.
- Ensure each MVP enemy type appears at least once across the two-room MVP.
- End the run after the second room is completed and the north gate exit is used.
- Preserve enemy room-mix data for later content expansion.
- Do not add out-of-scope systems.

## BA Decision
Status: Ready for Coder implementation.

No BA blocker remains for Coder kickoff. The only ongoing dependency is for Coder to verify exact details from the GDD, UI/UX spec, visual design doc, and task acceptance criteria before implementing each task.
