# Repository instructions

- Un task per volta; nessuna anticipazione del backlog.
- Usa `agentic/runner/context/TASK-XXX.md` come lista chiusa dei documenti da leggere.
- Non seguire ricorsivamente link, riferimenti o directory.
- Dopo un piano di massimo cinque punti, inizia a modificare il codice.
- Mantieni Domain indipendente da ASP.NET Core, database, provider LLM e infrastruttura.
- Usa nullable reference types, `CancellationToken`, errori tipizzati, logging strutturato e test dei failure path.
- Il progetto targetta .NET 10; non inventare API, proprietà MSBuild o sintassi C# 14: verifica nel progetto, nell'SDK installato o mediante compilazione minima.
- Applica un metodo evidence-first: riproduci, classifica il livello del problema, raccogli evidenze e solo dopo modifica il codice.
- Non dedurre i `ProjectReference` da `Assembly.GetReferencedAssemblies()`: distingui grafo MSBuild, riferimento del compilatore, `AssemblyRef` emessa, file di output e caricamento runtime.
- Per PowerShell identifica la shell corrente ed evita comandi annidati con doppi livelli di interpolazione.
- Non inserire segreti nei file, nei log o nei prompt.
- Non eseguire push, merge, reset distruttivi, prune o comandi privilegiati.
- In modalità autonoma il Project Runner coordina implementazione, diagnosi e review tramite subagent isolati.
