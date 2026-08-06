# Context package 037 — TASK-037 — Packaging, deployment and MVP runbook

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-037-packaging-deployment-and-mvp-runbook.md` |

## Documenti autorizzati

- `agentic/operations/DEPLOYMENT.md` — sezioni: `tutte le sezioni`.
- `agentic/governance/QUALITY_GATES.md` — sezioni: `Quality gate di rilascio MVP`.
- `agentic/governance/SECURITY.md` — sezioni: `Segreti`, `Audit`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- Dockerfiles, compose, config templates, runbook e smoke tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Nessun deploy reale o credenziale di produzione.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
