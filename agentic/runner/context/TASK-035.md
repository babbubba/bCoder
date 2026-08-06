# Context package 035 — TASK-035 — Security hardening and threat tests

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-035-security-hardening-and-threat-tests.md` |

## Documenti autorizzati

- `agentic/governance/THREAT_MODEL.md` — sezioni: `tutte le sezioni`.
- `agentic/governance/SECURITY.md` — sezioni: `tutte le sezioni`.
- `agentic/governance/PRIVACY.md` — sezioni: `tutte le sezioni`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- security-sensitive code e threat tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non cambiare policy per far passare test.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
