---
name: diagnose-failure
description: Diagnostica un fallimento del task senza espandere il contesto.
agent: Task Reviewer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Diagnostica il fallimento di `${input:taskPath}` usando soltanto:

- il task;
- `agentic/runner/context/TASK-XXX.md`;
- l’ultimo diff;
- l’output di errore pertinente;
- i file direttamente coinvolti.

Non leggere il piano generale o altri task. Restituisci causa probabile, evidenze, correzione minima e verifica da rieseguire.
