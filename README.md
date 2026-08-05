# Italcom Agent Orchestrator

Repository per lo sviluppo dell'orchestratore agentico local-first basato su DeepSeek V4 Flash, DS4, Microsoft Agent Framework e provider esterni controllati.

Tutta la documentazione di progetto, il piano e il backlog agentico sono raccolti nella cartella [`agentic/`](agentic/README.md), così la root rimane libera per il codice applicativo.

## Avvio rapido

1. Leggi [`agentic/START_HERE.md`](agentic/START_HERE.md).
2. Inizializza Git con `scripts/init-repo.sh` oppure `scripts/init-repo.ps1`.
3. Apri il repository in VS Code.
4. Avvia il primo task:

```text
/implement-task taskPath=agentic/tasks/TASK-001-repository-bootstrap.md
```

## Struttura prevista del codice

```text
src/
tests/
agentic/
.github/
scripts/
```
