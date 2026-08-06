---
name: resume-project
description: Riprende un’esecuzione autonoma interrotta riconciliando checkpoint e repository.
agent: Project Runner
tools: ['agent', 'read', 'search', 'edit', 'execute']
---

Riprendi il progetto da `agentic/runner/STATE.md`.

Prima riconcilia stato, branch, baseline commit, diff e ultimo report del task corrente. Se sono coerenti, continua dal primo passaggio incompleto. Se non sono coerenti, registra `Blocked`, descrivi esattamente la divergenza e fermati senza alterare il codice.
