# Repository instructions

- Un task per volta; nessuna anticipazione del backlog.
- Usa `agentic/runner/context/TASK-XXX.md` come lista chiusa dei documenti da leggere.
- Non seguire ricorsivamente link, riferimenti o directory.
- Dopo un piano di massimo cinque punti, inizia a modificare il codice.
- Mantieni Domain indipendente da ASP.NET Core, database, provider LLM e infrastruttura.
- Usa nullable reference types, `CancellationToken`, errori tipizzati, logging strutturato e test dei failure path.
- Non inserire segreti nei file, nei log o nei prompt.
- Non eseguire push, merge, reset distruttivi, prune o comandi privilegiati.
- In modalità autonoma il Project Runner coordina implementazione e review tramite subagent isolati.
