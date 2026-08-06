---
name: review-task
description: Revisiona manualmente un task con contesto isolato e ristretto.
agent: Task Reviewer
argument-hint: taskPath=agentic/tasks/TASK-xxx-name.md
---

Revisiona `${input:taskPath}`.

Deriva `TASK-XXX`, leggi `agentic/runner/context/TASK-XXX.md`, il diff dalla baseline e i file modificati. Non leggere il ragionamento dell’implementer e non seguire link ricorsivi.

Riesegui build/test pertinenti e restituisci esclusivamente l’esito strutturato previsto dal Task Reviewer.
