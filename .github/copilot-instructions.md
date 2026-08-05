# Repository instructions

Leggi sempre `agentic/AGENTS.md` e il task assegnato prima di modificare file.

Lavora su un solo task per sessione. Non implementare dipendenze future e non ampliare il perimetro.

Il progetto è un modular monolith .NET. Il dominio non dipende da infrastruttura, provider LLM, database o ASP.NET Core.

Propaga `CancellationToken`, usa nullable reference types, errori tipizzati, log strutturati e test per failure path.

Privacy, budget, approvazioni e permessi sono applicati da codice deterministico; non delegarli a prompt o decisioni libere del modello.

Non inserire segreti, token o dati cliente nel repository, nei log o nei prompt.

Prima di concludere esegui formatter, build e test pertinenti, mostra il diff e aggiorna la sezione “Esito esecuzione” del task.

Non eseguire push, merge, reset distruttivi, prune o comandi privilegiati.
