# Context package 034 — TASK-034 — Integration and end-to-end harness

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-034-integration-and-end-to-end-harness.md` |

## Documenti autorizzati

- `agentic/governance/TEST_STRATEGY.md` — sezioni: `Integration test`, `Contract test provider`, `End-to-end`.
- `agentic/operations/EXECUTION_PROTOCOL.md` — sezioni: `tutte le sezioni`.
- `agentic/operations/DEPLOYMENT.md` — sezioni: `solo ambiente locale`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- integration test projects, fake providers, compose test dependencies.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Nessun provider esterno reale.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
