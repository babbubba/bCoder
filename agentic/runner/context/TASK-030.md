# Context package 030 — TASK-030 — Checkpointed orchestration workflow

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-030-checkpointed-orchestration-workflow.md` |

## Documenti autorizzati

- `agentic/operations/EXECUTION_PROTOCOL.md` — sezioni: `tutte le sezioni`.
- `agentic/architecture/DOMAIN_MODEL.md` — sezioni: `WorkflowCheckpoint`, `TaskAttempt`, `Artifact`.
- `agentic/architecture/ARCHITECTURE.md` — sezioni: `Flusso principale`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- routing, agents, worktree, adapters e workflow tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non implementare API/CLI future.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
