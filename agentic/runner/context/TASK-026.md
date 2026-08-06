# Context package 026 — TASK-026 — Git repository and worktree manager

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-026-git-repository-and-worktree-manager.md` |

## Documenti autorizzati

- `agentic/architecture/adr/ADR-004-git-worktree-isolation.md` — sezioni: `intero file`.
- `agentic/governance/SECURITY.md` — sezioni: `Filesystem`.
- `agentic/architecture/DOMAIN_MODEL.md` — sezioni: `Artifact`, `WorkflowCheckpoint`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- git adapter, worktree manager, tests con temp repo.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Nessun push/merge/reset distruttivo.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
