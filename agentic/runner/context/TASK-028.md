# Context package 028 — TASK-028 — Safe process runner

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-028-safe-process-runner.md` |

## Documenti autorizzati

- `agentic/governance/SECURITY.md` — sezioni: `Process runner`, `Operazioni con approvazione`.
- `agentic/governance/TOOL_POLICY.md` — sezioni: `Sensibili`, `Vietati nell’MVP`, `Risultati dei tool`.
- `agentic/governance/THREAT_MODEL.md` — sezioni: `Minacce principali`, `Controlli`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- process runner, allow-list, timeout/cancellation tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Niente shell libera o comandi privilegiati.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
