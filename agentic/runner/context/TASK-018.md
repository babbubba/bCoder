# Context package 018 — TASK-018 — Budget and human approval gate

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-018-budget-and-human-approval-gate.md` |

## Documenti autorizzati

- `agentic/governance/MODEL_ROUTING.md` — sezioni: `Paid e frontier`.
- `agentic/architecture/DOMAIN_MODEL.md` — sezioni: `ApprovalRequest`.
- `agentic/governance/SECURITY.md` — sezioni: `Operazioni con approvazione`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- budget/approval services, persistence, tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non integrare UI o provider paid reali.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
