# AI Tools Note

*(Summary below stays short and final-draft quality — write it last, once the log has real entries. The Development Log is the append-as-you-go record; do not prune it for length, only for accuracy.)*

## Tools used
- **Claude Code (Sonnet 5)** — primary dev partner for this build: design discussion, C# scripting, git/GitHub setup
- **Unity-MCP** (`com.ivanmurzak.unity.mcp`) — MCP server bridging Claude Code directly into the running Unity Editor for live GameObject/component/prefab/scene edits, not just file generation

## How used
Claude Code has handled essentially all AI-assisted work so far: design/scope planning including three staged Fable-advisor sanity checks that caught concrete gaps before code existed, documentation and a visual design-spec artifact with a follow-up interaction-clarity patch, GitHub/git repo setup, and — most recently — building and using a reusable git commit-splitting/tagging workflow (`/split-commit`). Unity-MCP is installed and configured but still unexercised for live Editor/scene work; the one direct scaffold-code attempt was rolled back after a scope correction, the only case of Claude Code acting ahead of an explicit go-ahead.

## What stayed human-driven
- Mechanic choice (delegation task-assignment over communication-crisis / conflict-resolution alternatives)
- Scope cuts and scoring-formula tuning
- Final playtest judgment and bug triage
- Submission decision

## Honest reflection
AI genuinely sped up the design phase — a Fable review caught real gaps (an undefined burnout floor, a score ceiling that hand-checking showed was uncomfortably close to unreachable) that would have caused rework once code was written. It also overstepped once, writing scaffold code before being asked to start implementation; the user's correction was necessary, and having to actively catch and roll that back is itself a fair data point on where human oversight stayed load-bearing rather than passive.

---

## Development Log
*(Chronological, append one line per AI-assisted session — group by coherent task, not per micro-action. When logging MCP-driven Editor work, name what it caught or verified, not just "used MCP" — criterion 3 is scored on effective/thoughtful use, which reads through concrete catches. Kept here as evidence/detail; the summary above is what a reader skims.)*

- **2026-09-08** — Design lock session: used Claude Code to compare 3 mechanic candidates (delegation / communication-crisis / conflict-resolution), locked scope+data model+scoring formula for delegation task-assignment (see `D:\GosuAcademy\Notes.md`)
- **2026-09-08** — Repo setup: Claude Code ran `gh repo create` for private GitHub remote, wrote project `CLAUDE.md`, committed Unity-MCP package setup
- **2026-09-08** — Design-lock review + tooling: consulted Fable (via `/fable-advisor`) to sanity-check the locked design before Day 1 coding — it caught 4 undefined edge cases (burnout tier floor, max-score formula, feedback-bullet template, missing concrete task numbers) and a scheduling gap (`docs/MECHANIC_NOTE.md` unscheduled), all fixed in `Notes.md`. Second Fable consult designed this note's own maintenance workflow: kept inline append as the standing per-session habit (now codified in `CLAUDE.md`), and built a separate manually-triggered `update-ai-tools-note` skill for periodic catch-up/dedup/summary-refresh instead of a per-action logging skill.
- **2026-09-08** — Internal GDD + wireframes: Claude Code wrote `D:\GosuAcademy\GDD_internal.md` (internal-only reference, never submitted, per hard rule) reorganizing the locked design with ASCII wireframes for the Start/Round/End UI panels, requested for easier reading while building.
- **2026-09-08** — Visual design spec: Claude Code built and published a rendered HTML design-spec artifact (real screen mockups instead of ASCII) covering the same locked design + wireframes, for visual review — internal reference only.
- **2026-09-08** — Time-budget check: consulted Fable again to sanity-check the locked design against actual elapsed time (0 code written, ~4hrs into Day 1) — verdict: scope already right-sized, real issue was process (too much planning, no code yet). Recommended two scope trims (drop hover-preview color feedback, lock PC-only build); user approved the hover-preview cut, kept the build-target decision open for Day 3-4. Both reflected in `Notes.md`.
- **2026-09-08** — Scaffolding attempt + correction: Claude Code wrote `TaskData.cs`, `TeamMemberData.cs`, `GameManager.cs` (data classes + round/timer/assignment logic per the locked design) without being asked to start implementation. User corrected ("i never ask to start dev"); Claude Code removed all three files and their `.meta`, confirmed clean via `git status`.
- **2026-09-08** — Interaction-clarity patch: user found the published wireframe didn't show how the click-to-assign flow actually works. Consulted Fable, which recommended a minimal patch over a rebuild; added a 4-frame interaction-sequence strip (Unassigned → Task clicked → Committed → Reassignable) to the existing artifact reusing its own styling, republished to the same link.
- **2026-09-08** — Final go/no-go gate: user asked for a third design sanity pass; Fable confirmed no new gaps and proactively checked `ProjectSettings.asset` (`activeInputHandler`) to rule out an Input System conflict before Day 1 coding. Separately, user caught that every planning timestamp so far had assumed "today" was 09-07 when it was actually 09-08 — fixed the schedule (4 days, one lost, compressed) across `Notes.md`, `GDD_internal.md`, the wireframe artifact, and this file's log dates.
- **2026-09-08** — Git commit workflow tooling: user asked to split pending working-tree changes (scene rename, new `Scripts/` folder, new `docs/`, `CLAUDE.md` and `ProjectSettings.asset` edits) into separate commits tagged `[Add]`/`[Mod]`/`[Ref]`/`[Del]` by change type; Claude Code grouped the changes into logical units and committed each separately, then built a reusable `.claude/commands/split-commit.md` slash command (model: haiku, effort: low, since the task is mechanical) to standardize the convention for future use. After the first pass (6 commits, treating the scene rename as delete+add), the user asked for renames to use `[Ref]` instead; Claude Code safely `git reset --mixed`'d the unpushed commits (verified `ahead 6` / not yet pushed before resetting) and re-committed as 5 commits, this time with the rename correctly detected and tagged.
