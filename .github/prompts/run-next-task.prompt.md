---
name: run-next-task
description: Identifica il prossimo task eseguibile senza modificare codice o stato.
agent: Planner
---

Leggi soltanto le righe pertinenti di `agentic/tasks/INDEX.md` e `agentic/runner/STATE.md`.

Identifica il primo task non `Done` con dipendenze `Done`. Restituisci:

- percorso del task;
- context package `agentic/runner/context/TASK-XXX.md`;
- budget operativo 32K/64K;
- prerequisiti bloccanti;
- comando `/implement-task`.

Non leggere il piano generale, non aprire altri task e non modificare codice o stato.
