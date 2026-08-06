# Ripresa dopo interruzione

## Dopo chiusura o crash di VS Code

1. Riapri la stessa worktree.
2. Verifica che DS4 sia disponibile.
3. Seleziona `Project Runner` e Long 64K.
4. Seleziona Autopilot.
5. Esegui `/resume-project`.

## Riconciliazione

Il runner deve confrontare:

- `STATE.md`;
- branch corrente;
- `git status`;
- baseline e ultimo commit approvato;
- ultimo file sotto `runs/TASK-XXX/`;
- stato del task e dell’indice.

Se esiste una divergenza non deterministica, deve impostare `Blocked` e fermarsi. Non deve scartare o sovrascrivere modifiche per “ripulire” il repository.

## Ripresa manuale da un task bloccato

Dopo aver risolto la causa:

1. documentare la risoluzione nel report del task;
2. aggiornare `STATE.md` a `Ready` o alla fase corretta;
3. mantenere lo stesso baseline commit oppure registrarne esplicitamente uno nuovo;
4. eseguire `/resume-project`.
