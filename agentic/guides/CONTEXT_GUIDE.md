# Guida alla scelta del contesto

## Fast 32K

Usare per:

- singolo adapter/client;
- uno o due progetti della solution;
- unit test;
- API endpoint;
- persistence circoscritta;
- documentazione;
- bug con stack trace chiaro.

Vantaggi: prefill minore, iterazioni più rapide, compattazione prima che la conversazione diventi rumorosa.

## Long 64K

Usare per:

- dominio e architettura;
- routing e privacy;
- workflow con più componenti;
- Agent Framework;
- worktree/process security;
- review trasversale;
- scenari end-to-end.

## Regole

- il contesto indicato nel task è il default;
- passare a 64K solo se il task richiede davvero più moduli;
- non usare 64K come predefinito per implementazioni semplici;
- nuova chat per ogni task e review;
- allegare solo file pertinenti;
- salvare output lunghi su file invece di incollarli integralmente.
