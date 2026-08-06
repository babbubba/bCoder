# Context package 036 — TASK-036 — Performance and concurrency validation

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-036-performance-and-concurrency-validation.md` |

## Documenti autorizzati

- `agentic/operations/OBSERVABILITY.md` — sezioni: `tutte le sezioni`.
- `agentic/governance/TEST_STRATEGY.md` — sezioni: `Integration test`, `End-to-end`.
- `agentic/guides/CONTEXT_GUIDE.md` — sezioni: `Budget operativo`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- workflow, queues, timeouts, benchmark harness.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non ottimizzare senza misure riproducibili.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
