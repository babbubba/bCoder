# Piano di implementazione completo

## Strategia generale

Lo sviluppo è organizzato in otto fasi e task incrementali. Ogni task deve lasciare il repository compilabile e, salvo eccezioni motivate, con test verdi.

## Fase 0 — Bootstrap e standard

Obiettivo: repository riproducibile, solution vuota ma compilabile, convenzioni e controlli automatici.

Task: 001–004.

Uscita:

- repository Git inizializzato;
- solution .NET;
- build e test baseline;
- configurazione e secrets sicuri.

## Fase 1 — Dominio e infrastruttura di base

Obiettivo: modello di dominio stabile, persistenza iniziale, osservabilità e contratti API.

Task: 005–008.

Uscita:

- entità e invarianti testate;
- PostgreSQL con migrazioni;
- tracing/logging/metrics di base;
- error model uniforme.

## Fase 2 — Provider LLM

Obiettivo: usare DS4 e OpenRouter attraverso un contratto comune, mantenendo informazioni su capacità e costo.

Task: 009–014.

Uscita:

- provider DS4 verificato con tool calling;
- provider OpenRouter;
- catalogo modelli aggiornabile;
- capability e pricing normalizzati;
- usage accounting.

## Fase 3 — Routing e governance

Obiettivo: decisioni deterministiche local-first/free-first con privacy, budget, retry ed escalation.

Task: 015–019.

Uscita:

- selezione spiegabile;
- data-egress gate;
- approvazioni;
- retry limitati;
- escalation tracciata.

## Fase 4 — Agenti

Obiettivo: integrare Agent Framework e creare ruoli distinti.

Task: 020–025.

Uscita:

- planner strutturato;
- coder;
- reviewer indipendente;
- research agent;
- delega agent-as-tool.

## Fase 5 — Esecuzione sicura

Obiettivo: permettere modifiche reali in workspace isolate e verificarle.

Task: 026–030.

Uscita:

- worktree per task;
- filesystem e process tools controllati;
- build/test adapter;
- workflow con checkpoint.

## Fase 6 — Superfici di utilizzo

Obiettivo: API, streaming, CLI e gestione delle approvazioni.

Task: 031–033.

Uscita:

- API REST/SSE;
- CLI operativa;
- ripresa task e approvazioni.

## Fase 7 — Hardening e rilascio MVP

Obiettivo: validazione end-to-end, sicurezza, performance e deployment.

Task: 034–037.

Uscita:

- test di integrazione;
- scenari E2E locale ed escalation;
- threat mitigations verificate;
- pacchetto di deployment e runbook.

## Ordine di esecuzione

Seguire [tasks/INDEX.md](../tasks/INDEX.md). Non avviare task con dipendenze non concluse.

## Uso dei contesti

- Planner, dominio, router, workflow e sicurezza: **64K**.
- Client, persistence locale, API, CLI, test mirati: **32K**.
- Ogni review deve avvenire in una nuova sessione, normalmente 32K; usare 64K se il diff attraversa tre o più moduli.

## Milestone

### M1 — Provider funzionanti

Completamento task 001–014.

Demo: chiamata locale DS4 e chiamata OpenRouter simulata/controllata, con usage registrato.

### M2 — Routing governato

Completamento task 015–019.

Demo: richiesta classificata, tentativo locale, scelta free e approvazione paid bloccata.

### M3 — Agenti e worktree

Completamento task 020–030.

Demo: planner crea task, coder modifica una worktree, test runner valuta, reviewer produce esito.

### M4 — MVP utilizzabile

Completamento task 031–037.

Demo: avvio da CLI, streaming eventi, checkpoint, approvazione, diff finale e audit.

## Criteri di successo MVP

- almeno un task C# semplice completato localmente;
- almeno un fallimento locale recuperato con secondo tentativo;
- almeno una delega a modello gratuito simulata o reale;
- nessuna chiamata paid senza approvazione;
- ripresa dopo interruzione;
- worktree rimossa o archiviata in modo controllato;
- build e test allegati al report finale;
- costo e modello usato registrati.
