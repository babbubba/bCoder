# Workflow autonomo

## Stati

`Idle → Implementing → Validating → Reviewing → Done`

Esiti alternativi:

- `ChangesRequested` torna a `Implementing` con tentativo incrementato;
- `Blocked` arresta il runner;
- dopo tre tentativi falliti il task diventa `Blocked`.

## Ciclo

1. Selezione del primo task con dipendenze `Done`.
2. Registrazione baseline e checkpoint.
3. Esecuzione del Task Implementer in contesto isolato.
4. Build e test deterministici.
5. Esecuzione del Task Reviewer in nuovo contesto isolato.
6. Correzione dei finding major, massimo tre tentativi.
7. Aggiornamento task e indice.
8. Commit locale.
9. Passaggio automatico al task successivo.

## Contesto

La matrice nei task originali è informativa. In modalità autonoma:

- il modello resta Long 64K per tutta la sessione;
- un package 32K limita letture e file, ma non cambia modello;
- un package 64K autorizza un contesto più ampio, sempre entro i documenti elencati;
- nessun link viene seguito automaticamente.

## Persistenza

Ogni tentativo deve produrre file sotto `runs/TASK-XXX/`. Questo consente di riprendere il lavoro senza affidarsi alla conversazione compattata.
