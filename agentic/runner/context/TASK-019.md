# Context package 019 — TASK-019 — Retry, evaluation and escalation

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-019-retry-evaluation-and-escalation.md` |

## Documenti autorizzati

- `agentic/governance/MODEL_ROUTING.md` — sezioni: `Retry`, `Paid e frontier`.
- `agentic/governance/QUALITY_GATES.md` — sezioni: `Ordine di valutazione`, `Esiti`.
- `agentic/architecture/DOMAIN_MODEL.md` — sezioni: `TaskAttempt`, `RoutingDecision`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- retry/escalation services e tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non leggere agent framework.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
