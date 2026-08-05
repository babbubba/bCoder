# Regole obbligatorie per tutti gli agenti

## Gerarchia delle fonti

Prima di lavorare, leggi nell'ordine:

1. questo file;
2. il task assegnato;
3. [PROJECT.md](PROJECT.md);
4. [ARCHITECTURE.md](architecture/ARCHITECTURE.md);
5. [SECURITY.md](governance/SECURITY.md);
6. [QUALITY_GATES.md](governance/QUALITY_GATES.md);
7. gli ADR citati dal task.

Il task prevale sulle indicazioni generiche solo se non viola sicurezza, privacy o decisioni architetturali approvate.

## Un task per sessione

- Lavora su un solo task.
- Non anticipare task successivi.
- Non effettuare refactoring estranei.
- Se emerge una dipendenza mancante, documentala e fermati.

## Metodo obbligatorio

1. verifica dipendenze e stato del repository;
2. riassumi il piano operativo in massimo 10 punti;
3. identifica i file da creare o modificare;
4. implementa in incrementi piccoli;
5. esegui formatter, build e test pertinenti;
6. correggi al massimo due volte senza cambiare perimetro;
7. mostra il diff finale;
8. aggiorna l'esito nel task;
9. segnala rischi residui e decisioni mancanti.

## Divieti

Non eseguire senza approvazione esplicita:

- `git push`, merge, rebase distruttivi o reset hard;
- eliminazione massiva di file;
- comandi Docker di prune;
- accesso a credenziali non necessarie;
- invio di codice a provider esterni;
- modifiche a policy di sicurezza;
- installazione globale di pacchetti;
- operazioni su ambienti non locali.

## Qualità

- codice compilabile;
- nullable reference types abilitati;
- async end-to-end dove appropriato;
- `CancellationToken` propagato;
- errori tipizzati e log strutturati;
- niente catch generici silenziosi;
- niente segreti o dati sensibili nei log;
- test per comportamento e failure path;
- commenti solo quando spiegano una decisione non ovvia.

## Gestione del contesto

- usa 32K per task circoscritti;
- usa 64K per task trasversali o architetturali;
- apri una nuova chat per review e sicurezza;
- non trascinare output di terminale non pertinente;
- usa riferimenti ai file invece di incollarne copie complete.
