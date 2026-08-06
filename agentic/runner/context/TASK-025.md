# Context package 025 — TASK-025 — Agent-as-tool delegation

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-025-agent-as-tool-delegation.md` |

## Documenti autorizzati

- `agentic/architecture/adr/ADR-003-agent-as-tool.md` — sezioni: `intero file`.
- `agentic/architecture/ARCHITECTURE.md` — sezioni: `AgentRuntime`, `Flusso principale`.
- `agentic/governance/TOOL_POLICY.md` — sezioni: `Classi`, `Risultati dei tool`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- planner/coder/reviewer/research agent code e orchestration tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non leggere worktree o API.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
