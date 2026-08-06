# Istruzioni agentiche del repository

Queste regole sono sempre attive e devono restare brevi.

1. Lavora su un solo task alla volta.
2. Non leggere ricorsivamente link Markdown, intere directory, tutti gli ADR o il piano consolidato.
3. Per ogni `TASK-XXX`, il contesto autorizzato è definito da `agentic/runner/context/TASK-XXX.md`.
4. Il context package prevale sulle sezioni legacy “Prima di iniziare” e “Prompt Copilot pronto” presenti nei task.
5. In modalità autonoma usa una sessione principale Long 64K; i subagent ereditano il modello e rispettano il budget 32K/64K indicato nel context package.
6. Non eseguire `git push`, merge, rebase, reset distruttivi, prune, comandi privilegiati o operazioni fuori dalla worktree.
7. Nessun codice, segreto o dato interno deve essere inviato a provider esterni senza una policy già implementata e un’approvazione esplicita.
8. Un task è completato solo dopo build, test pertinenti e review indipendente.
9. Se mancano credenziali, requisiti o decisioni non deducibili, registra `Blocked` e fermati; non inventare.

Workflow autonomo: `agentic/runner/README.md`.
Regole estese, da leggere solo quando richieste dal context package: `agentic/AGENTS.md`.
