# Coder Handoff - Update Unity Gitignore

Target agent: [[Coder]]
Source: [[PM]]
Date: 2026-05-20
Deadline session: next [[Coder]] session

## Task

Add or verify proper Unity `.gitignore` rules at the root of the Stackspire repository so Unity-generated local folders are not committed when the project is used across multiple PCs.

## Inputs

- `Agents/Coder.md`
- `Core/Conventions.md`
- Stackspire repository root: `C:\Users\user\Intern\Intern`
- Existing root `.gitignore`, if present

## Scope

- Locate the root `.gitignore` for the whole Stackspire repository.
- If no root `.gitignore` exists, create one at the repository root.
- Add missing Unity, IDE, crash/debug, and OS ignore rules listed below.
- Preserve existing ignore rules unless they directly conflict with Unity source tracking requirements.
- Do not edit Unity gameplay files, scenes, prefabs, assets, generated art, or scripts.
- Do not implement gameplay, UI, art, scene, prefab, asset, package, or Project Settings changes.

## Required Gitignore Rules

Ensure the root `.gitignore` includes these entries:

```gitignore
# Unity generated folders
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/
[Mm]emoryCaptures/

# Unity crash/debug files
sysinfo.txt
*.stackdump

# Visual Studio / Rider / IDE files
.vs/
.idea/
*.csproj
*.sln
*.suo
*.user
*.userprefs
*.pidb
*.booproj
*.svd
*.pdb
*.mdb
*.opendb
*.VC.db

# OS files
.DS_Store
Thumbs.db
Desktop.ini
```

## Unity Source Tracking Rules

The `.gitignore` must not ignore these project source files or folders:

- `Assets/`
- `*.meta`
- `ProjectSettings/`
- `Packages/manifest.json`
- `Packages/packages-lock.json`

If the existing `.gitignore` has rules that would ignore these required source files, adjust only the conflicting ignore lines and document the adjustment in the Coder report.

## Verification

- Confirm `Library/` is ignored by the root `.gitignore`.
- Confirm `.meta` files remain trackable.
- Confirm `ProjectSettings/` remains trackable.
- Confirm `Packages/manifest.json` remains trackable.
- Confirm no Unity gameplay files, scenes, prefabs, assets, generated art, or scripts were changed.

Use Git commands such as `git check-ignore` and `git status --short` where useful, but do not stage or commit changes.

## Required Output

- Append a `## Coder Report` section to this task card with:
  - root `.gitignore` path found or created
  - ignore rules added, verified, or left unchanged
  - any conflicting rules removed or corrected
  - verification commands/results
  - confirmation that no gameplay, scene, prefab, asset, generated art, package, Project Settings, or script files were modified
- If complete, move this card to `Tasks/Done/`.
- If blocked, leave this card in `Tasks/Open/` and add a PM blocker handoff in `Tasks/Open/`.

## Acceptance Criteria

- A root `.gitignore` exists at the Stackspire repository root.
- The root `.gitignore` includes ignore rules for `Library/` and the other Unity-generated/local file patterns listed in this card.
- Unity source files, `.meta` files, `ProjectSettings/`, `Packages/manifest.json`, and `Packages/packages-lock.json` remain trackable.
- No gameplay, scene, prefab, asset, generated art, package manifest, Project Settings, or C# script content is changed.

## Coder Report

- Root `.gitignore` path found or created: created `C:\Users\user\Intern\Intern\.gitignore`.
- Ignore rules added: all required Unity generated folders, Unity crash/debug files, Visual Studio/Rider/IDE files, and OS files from this task card.
- Conflicting source-tracking rules: none found because no root `.gitignore` existed before this task.
- Verification commands/results:
  - `git rev-parse --show-toplevel` returned `C:/Users/user/Intern/Intern`.
  - `git check-ignore -v Library/test.tmp` matched `.gitignore:2:[Ll]ibrary/`.
  - `git check-ignore -v Assets/test.asset.meta` returned exit code `1`, meaning no ignore match.
  - `git check-ignore -v ProjectSettings/ProjectSettings.asset` returned exit code `1`, meaning no ignore match.
  - `git check-ignore -v Packages/manifest.json` returned exit code `1`, meaning no ignore match.
  - `git check-ignore -v Packages/packages-lock.json` returned exit code `1`, meaning no ignore match.
  - `git status --short` shows this task added `.gitignore`; existing unrelated modified files were already present before this task and were not changed.
- Confirmation: no gameplay, scene, prefab, asset, generated art, package, Project Settings, or C# script files were modified by this task.
- QA handoff: not created per direct user instruction.
