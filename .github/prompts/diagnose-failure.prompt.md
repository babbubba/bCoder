---
name: diagnose-failure
description: Analizza un tentativo fallito senza ampliare il task.
agent: Planner
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Analizza il fallimento di `${input:taskPath}` usando diff, build, test e log disponibili. Determina se serve:

1. retry locale con strategia diversa;
2. correzione del task;
3. dipendenza mancante;
4. escalation di modello;
5. intervento umano.

Non implementare la correzione.
