# Context package 033 — TASK-033 — Administration and policy endpoints

| Campo | Valore |
|---|---|
| Budget operativo | **32K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-033-administration-and-policy-endpoints.md` |

## Documenti autorizzati

- `agentic/architecture/API_CONTRACT.md` — sezioni: `endpoint amministrativi pertinenti`.
- `agentic/governance/MODEL_ROUTING.md` — sezioni: `Regole free-first`, `Paid e frontier`.
- `agentic/governance/SECURITY.md` — sezioni: `Operazioni con approvazione`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- API admin endpoints e tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non ampliare a una UI amministrativa.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
