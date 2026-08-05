---
name: run-next-task
description: Identifica il prossimo task Ready e prepara l'esecuzione.
agent: Planner
---

Leggi [tasks/INDEX.md](../../agentic/tasks/INDEX.md), identifica il primo task Ready con dipendenze Done e indica:

- file task;
- profilo 32K/64K da selezionare;
- rischi e prerequisiti;
- prompt `/implement-task` da usare.

Non modificare codice o stato.
