# Context package 020 — TASK-020 — Microsoft Agent Framework integration

| Campo | Valore |
|---|---|
| Budget operativo | **64K** |
| Modello in modalità autonoma | Eredita **Long 64K** dal Project Runner |
| Task | `agentic/tasks/TASK-020-microsoft-agent-framework-integration.md` |

## Documenti autorizzati

- `agentic/architecture/ARCHITECTURE.md` — sezioni: `AgentRuntime`, `Flusso principale`, `Principi`.
- `agentic/guides/REFERENCES.md` — sezioni: `solo Microsoft Agent Framework`.

Leggere solo le sezioni indicate, usando ricerca per heading quando possibile.

## Aree di codice autorizzate

- provider abstraction, package references, runtime integration tests.

Il subagent può aprire ulteriori file applicativi solo quando un riferimento di compilazione o un test dimostra che sono direttamente necessari.

## Esclusioni

- Non esplorare l’intero web; usare versioni package risolte dal progetto.
- Non leggere `agentic/planning/ALL-IN-ONE-PLAN.md`.
- Non leggere l’intero backlog o task successivi.
- Non seguire ricorsivamente link Markdown.
- Non aprire intere directory “per completezza”.

## Regola di partenza

Dopo task, package e massimo quattro letture iniziali, l’implementer deve iniziare a modificare il codice oppure restituire `BLOCKED` con il dato mancante.

## Review

Il reviewer usa lo stesso package, ma legge principalmente diff, file modificati e output di validazione. Non riceve il reasoning dell’implementer.
