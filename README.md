# Delegation Dilemma

A small playable prototype built for Gosu Academy's Round 2 Contract Unity Game Developer take-home — Option B (playable mini-game demo) of the corporate-training-game brief. One core mechanic, one leadership skill, no padding.

## The pitch

You're a manager with 90 seconds, 5 tasks, and 3 team members. Each member has a skill strength, a skill weakness, and a hard capacity of 4 effort units. Click a task, click a member, they're assigned — reassign as often as you like until you end the day. Do it well and you're a **Strong Delegator**; dump everything on your favorite person and you're an **Overloaded Manager**.

Full mechanic → leadership-skill writeup: [`docs/MECHANIC_NOTE.md`](docs/MECHANIC_NOTE.md).

## How to play

1. **Start panel** — optionally uncheck "color guide" for a harder round (no skill-match color hints), then Start Day.
2. **Round panel** — click a task, then click a member to assign it. Reassign anytime before the timer runs out or you hit End Day. Each member's card shows live capacity load; going over capacity costs a quality penalty (burnout), not a hard block.
3. **End panel** — score %, delegator tier, and feedback naming what actually happened in that run. Return to Start to try again.

## Why it's built this way

The 5 tasks and 3 members aren't arbitrary — the numbers are tuned so that "give every task to its best skill-match person" is structurally impossible (two skill lanes have more task effort than any one member's capacity can absorb). The achievable score ceiling (86.3%) and floor were brute-force-validated against every possible assignment, not hand-waved. Details in `Notes.md` (internal planning log, not part of the submission but useful context if you're curious how the numbers were chosen).

## Running it

- **Playable build**: see the submission email / release for a Windows standalone build, or open in Unity **6000.3.15f1** and press Play on `Assets/Scene/GameScene.unity`.
- **From source**: clone, open with Unity Hub (6000.3.15f1), open `Assets/Scene/GameScene.unity`, press Play.

## Tech notes

- Data-driven: tasks, members, colors, and score-tier text all live in ScriptableObject config assets (`Assets/Data/`) — adding more content needs no code changes.
- Split into `LeadershipGame.Core` (data/logic) and `LeadershipGame.UI` (presentation) assemblies.
- Real scoring formula, not a placeholder — see `ScoreCalculator.cs`.

## AI tools note

This project was built with heavy AI assistance (Claude Code + Unity-MCP), per the brief's own evaluation criteria. Full breakdown of what was AI-driven vs. human-driven, including concrete catches and mistakes on both sides: [`docs/AI_TOOLS_NOTE.md`](docs/AI_TOOLS_NOTE.md).
