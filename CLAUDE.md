# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this project is

Unity prototype for a corporate training game about leadership skills — Round 2 take-home submission for a Contract Unity Game Developer role at Gosu Academy. Full brief context, deadline, and submission requirements live in `D:\GosuAcademy\CLAUDE.md` and `D:\GosuAcademy\Notes.md` (this repo's parent directory, which is *not* itself a git repo — this `LeadershipGameDemo` folder is its own repo).

Scope is deliberately small: one playable mechanic demonstrating one leadership skill (delegation, communication under pressure, conflict resolution, or strategic thinking). Polish is explicitly not evaluated — do not over-build.

## Environment

- Unity **6000.3.15f1**, editor at `C:\Users\lenovo\Unity\6000.3.15f1\Editor\Unity.exe`
- Open the project via Unity Hub or by launching the editor directly against this folder
- No CLI build/test/lint pipeline exists in this repo — verification happens by opening the project in the Unity Editor (or via the MCP tools below) and running it, not via terminal commands

## Unity-MCP

`com.ivanmurzak.unity.mcp` 0.90.0 is installed (OpenUPM, scoped registry `package.openupm.com`). It exposes an MCP server (`ai-game-developer`, configured in `.mcp.json` against `http://localhost:25819`) that lets an MCP-connected agent drive the running Unity Editor directly — create/modify GameObjects and components, edit prefabs and scenes, run C# via Roslyn (`script-execute`), read/write assets, run tests, capture screenshots, etc. Prefer these tools over hand-editing `.unity`/`.prefab` YAML directly when the Editor is running and reachable, since they keep the Editor's in-memory state and serialized files consistent.

Requires the Unity Editor to be open with this project loaded and the MCP bridge listening — if the `ai-game-developer` tools fail to connect, the Editor likely isn't running.

Its own skill docs live under `.claude/skills/` (auto-generated, one `SKILL.md` per tool) — not project-specific instructions, just tool reference.

## Package management caveat

Headless/batchmode Unity runs on this machine have been flaky (a batchmode `-executeMethod` package-install script crashed previously). Prefer editing `Packages/manifest.json` directly over scripting Package Manager calls in batchmode.

## Project structure

- `Assets/Scene/Start.unity` — main/default scene
- `Assets/Plugins/` — third-party runtime DLLs (currently the Unity-MCP NuGet dependencies)
- No gameplay scripts exist yet as of this writing; mechanic and code architecture are still to be designed
