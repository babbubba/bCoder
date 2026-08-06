---
name: run-project
description: Avvia l’esecuzione autonoma dell’intero backlog tramite Project Runner e subagent isolati.
agent: Project Runner
tools: ['agent', 'read', 'search', 'edit', 'execute']
---

Avvia l’esecuzione autonoma del progetto.

Usa `agentic/runner/STATE.md` come checkpoint e `agentic/tasks/INDEX.md` come backlog. Implementa, valida, revisiona e committa localmente un task alla volta usando esclusivamente i subagent Task Implementer e Task Reviewer.

Continua fino a quando tutti i task sono `Done` oppure si verifica una condizione di stop sicuro. Non attendere conferme tra un task e il successivo. Non eseguire push, merge o operazioni distruttive.
