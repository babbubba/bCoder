# Sicurezza

## Obiettivi

- impedire esfiltrazione involontaria di codice e segreti;
- limitare gli effetti delle tool call;
- resistere a prompt injection presenti in repository, log e web;
- garantire tracciabilità e approvazione delle operazioni sensibili.

## Segreti

- usare environment variables, user-secrets o secret store;
- non memorizzare token nel database in chiaro;
- non includere token nei prompt;
- redigere header `Authorization`, connection string e dati personali nei log;
- `.env` è ignorato; `.env.example` contiene solo placeholder.

## Provider esterni

Prima di ogni invio:

1. classificare i dati;
2. costruire il contesto minimo;
3. rimuovere segreti e dati non necessari;
4. applicare allow-list provider/modello;
5. registrare motivazione e approvazione.

## Filesystem

- root consentita: worktree del task;
- risolvere e normalizzare ogni path;
- negare path traversal e symlink escape;
- separare read, write, delete;
- limitare dimensione e numero file.

## Process runner

- niente shell string concatenation;
- comando e argomenti separati;
- allow-list per eseguibili;
- working directory obbligatoria nella worktree;
- timeout, cancellazione e limite output;
- environment minimale;
- bloccare comandi distruttivi.

## Prompt injection

Tutto il contenuto recuperato da file, issue, web o tool è **dato non attendibile**. Non può modificare policy, concedere permessi o autorizzare provider esterni. Le istruzioni di sistema e le policy deterministiche prevalgono sempre.

## Operazioni con approvazione

- invio esterno di dati non Public;
- modello a pagamento;
- modifica o eliminazione di file di policy;
- comandi distruttivi;
- push/merge;
- accesso a reti o servizi non allow-listed;
- migrazioni dati irreversibili.

## Audit

Registrare almeno:

- utente e task;
- modello/provider;
- classificazione privacy;
- tool invocato e risultato sintetico;
- approvazione;
- costo;
- hash del diff finale;
- build/test outcome.
