# Policy degli strumenti

## Classi

### Read-only

Esecuzione automatica consentita nella worktree:

- leggere file;
- elencare directory;
- cercare testo;
- leggere stato e diff Git;
- leggere output di build/test.

### Mutating a basso rischio

Consentiti nel task corrente con audit:

- creare/modificare file nella worktree;
- eseguire formatter;
- restore/build/test;
- creare branch e worktree dedicate.

### Sensibili

Richiedono approvazione:

- cancellazioni ampie;
- installazioni globali;
- rete verso host non allow-listed;
- accesso a secrets;
- container privilegiati;
- scrittura fuori dalla worktree.

### Vietati nell'MVP

- push automatico;
- merge automatico su branch protetti;
- comandi con privilegi root;
- gestione infrastruttura di produzione;
- database production writes.

## Risultati dei tool

- troncare output troppo grandi;
- salvare artefatti completi su file e passare al modello un riepilogo;
- non reinviare segreti;
- distinguere stdout, stderr, exit code e timeout;
- allegare hash e percorso degli artefatti.
