---
name: implement-task
description: Implementa manualmente un singolo task usando il context package ristretto.
agent: Task Implementer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Implementa esclusivamente `${input:taskPath:agentic/tasks/TASK-001-repository-bootstrap.md}`.

Deriva l’ID `TASK-XXX` dal nome del file e usa `agentic/runner/context/TASK-XXX.md` come lista chiusa del contesto autorizzato.

Non applicare le sezioni legacy del task che chiedono di leggere genericamente progetto, architettura, sicurezza, quality gate o “documenti citati”.

Non seguire ricorsivamente link Markdown. Dopo un piano di massimo cinque punti, inizia immediatamente l’implementazione. Esegui i comandi di validazione del task e restituisci l’esito strutturato previsto dal Task Implementer.
