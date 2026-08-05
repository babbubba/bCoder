---
name: review-task
description: Revisiona l'implementazione di un task in una nuova sessione.
agent: Reviewer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Revisiona `${input:taskPath}`.

Leggi il task, il diff corrente, gli output di build/test e le policy collegate. Non fidarti del riepilogo dell'implementer. Restituisci esito e finding ordinati per severità.
