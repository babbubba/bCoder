---
name: implement-task
description: Implementa un singolo task del backlog.
agent: Implementer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Implementa esclusivamente `${input:taskPath:agentic/tasks/TASK-001-repository-bootstrap.md}`.

Leggi prima [AGENTS.md](../../agentic/AGENTS.md), [PROJECT.md](../../agentic/PROJECT.md), [ARCHITECTURE.md](../../agentic/architecture/ARCHITECTURE.md), [SECURITY.md](../../agentic/governance/SECURITY.md) e il task.

Verifica che il modello selezionato corrisponda al contesto consigliato nel task. Se non corrisponde, fermati e segnalalo.

Segui il metodo obbligatorio, esegui build/test e aggiorna l'esito nel task.
