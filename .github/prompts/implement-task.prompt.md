---
name: implement-task
description: Implementa un singolo task del backlog.
agent: Implementer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Implementa esclusivamente `${input:taskPath}`.

Leggi soltanto:

1. `AGENTS.md` nella root;
2. il task assegnato;
3. i file e le sezioni elencati nel campo `Context package` del task.

Non leggere automaticamente `PROJECT.md`, `ARCHITECTURE.md`, `SECURITY.md`,
`QUALITY_GATES.md`, ADR o altri documenti se non sono inclusi nel
`Context package`.

Non seguire ricorsivamente link e riferimenti documentali.

Dopo un piano di massimo 5 punti, inizia immediatamente l'implementazione.

Esegui solamente i comandi e i test richiesti dal task.
Aggiorna l'esito del task al termine.
