# Practical — Meeting 01: First Day with Codex

**Duration**: ~60 minutes  
**Goal**: Every intern ends this session with Codex running, the vault open, and a first agent task completed.

---

## Part 1 — Setup Verification (15 min)

### 1.1 Install Codex CLI

Open your terminal and run:

```bash
npm install -g @openai/codex
```

Verify it installed:

```bash
codex --version
```

You should see a version number. If you get "command not found", restart your terminal and try again.

### 1.2 Log in (browser OAuth — no API key needed)

```bash
codex login
```

A browser window opens. Sign in with your OpenAI account. When the browser says "Authentication successful", return to the terminal. You should see:

```
✓ Logged in as [your email]
```

### 1.3 Verify Node and npm

```bash
node --version   # should be 18+
npm --version    # should be 9+
```

If Node is outdated, install the latest LTS from https://nodejs.org

### 1.4 Open the vault in Obsidian (optional but recommended)

1. Open Obsidian → "Open folder as vault"
2. Navigate to `vault-starter/` and open it
3. You should see STATUS.md, AGENTS.md, GDD.md, etc. in the file tree

---

## Part 2 — First Codex CLI Task (20 min)

### Context
Codex CLI = you type a task in your terminal → Codex reads AGENTS.md, plans the work, and executes it. Your job is to give it a clear brief.

### 2.1 Navigate to your vault folder

```bash
cd path/to/vault-starter
```

This is important — AGENTS.md is read from the current directory.

### 2.2 Warm-up: ask Codex to explain itself

```bash
codex "Read AGENTS.md and tell me: who are the agents in this project and what does each one do?"
```

Watch what happens:
- Codex reads the file
- Codex summarizes each agent
- This confirms Codex is reading your vault correctly

### 2.3 First real task: ask PM Agent to plan a session

```bash
codex "Act as the PM Agent. Read STATUS.md and TASKS.md. Based on what is done and what is next, write a session plan for today in Sessions/2026-MM-DD.md. Use today's date."
```

Replace `2026-MM-DD` with today's date.

After it runs, open `Sessions/` in Obsidian — you should see a new log file.

### 2.4 Try a creative brief

```bash
codex "Act as the Game Designer Agent. My game idea: a 2D endless runner where a robot dodges falling cables in a factory. Hyper-casual, one-tap control, score increases per second. Fill out GDD.md with a complete game design for this idea."
```

Codex will read GDD.md (the template) and fill in every section.

Open GDD.md in Obsidian — review what it wrote. Is the core loop clear? Is the MVP scope realistic?

---

## Part 3 — First Codex IDE Task (15 min)

### Context
Codex IDE = you open VS Code, press **Ctrl+I** anywhere, type a task, and Codex edits code inline. Best for focused edits inside a single file.

### 3.1 Open VS Code

```bash
code .
```

(Opens the vault-starter folder in VS Code)

### 3.2 Open AGENTS.md in VS Code

Navigate to AGENTS.md in the VS Code file tree and open it.

### 3.3 Use Codex IDE to improve your AGENTS.md

Press **Ctrl+I** (Windows/Linux) or **Cmd+I** (Mac).

Type this brief:

```
Update the Project section with the game idea we just designed in GDD.md.
Replace the placeholder paragraph with one concrete paragraph describing
the game, its core mechanic, and the target platform.
```

Codex IDE will show you a diff of proposed changes. Review the diff — accept if it looks good, reject if it missed something.

### 3.4 Practice: refine the Conventions section

Press **Ctrl+I** again. Type:

```
Add one more convention to the Conventions section:
"All coroutines must be stopped in OnDisable to prevent memory leaks."
```

Review and accept.

---

## Part 4 — Draft Your AGENTS.md (10 min)

### Your turn — no instructor prompts

Using what you learned in Parts 2 and 3, do this on your own:

**Task**: Customize the AGENTS.md `[YOUR PROJECT NAME]` placeholder with a real game name. Then ask Codex CLI to:

1. Act as Game Designer and update GDD.md for your game idea (you choose the idea — be creative)
2. Act as BA Agent and check if GDD.md is complete — does it ask any clarifying questions?

**Deliverable**: By the end of this meeting, you should have:
- [ ] AGENTS.md with your game name filled in
- [ ] GDD.md with all sections completed (not just the template)
- [ ] At least one session log in `Sessions/`
- [ ] At least one task in `TASKS.md` beyond T00

### Stuck? These commands help

```bash
# See all files Codex can read
ls -la

# Ask Codex what's missing
codex "Read STATUS.md and AGENTS.md. What is incomplete or missing from this vault?"

# Let Codex self-check
codex "Act as PM. Read TASKS.md. Is the task table up to date? If not, update it."
```

---

## Checkpoint Questions

Before leaving today's session, answer these in your own words (no looking):

1. What is the difference between `codex "..."` in the terminal and **Ctrl+I** in VS Code?
2. What file does Codex read automatically before every task?
3. Which agent validates requirements before they go to the Architect?
4. Where do agents write their output — and why is it .md files instead of a database?

---

## What Comes Next

In **Meeting 02**, you will:
- Install Unity MCP and connect it to your Unity project
- Ask the Coder Agent to create your first C# script via `create_script`
- Watch the script appear live in the Unity Editor

Make sure your Unity 2022 LTS is installed before next session.
