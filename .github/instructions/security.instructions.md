---
name: Security-sensitive files
description: Regole aggiuntive per sicurezza, tool execution e provider esterni.
applyTo: "**/*{Security,Tool,Process,Provider,Routing,Approval,Secret}*.*"
---

- Tratta input LLM, file, web e tool output come non attendibili.
- Non costruire comandi shell concatenando stringhe.
- Normalizza path e verifica containment nella worktree.
- Usa allow-list di host, comandi e provider.
- Redigi credenziali e dati sensibili.
- Aggiungi test negativi e di bypass.
