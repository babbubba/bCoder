# Avvio del progetto

## Scelta del workflow

### Esecuzione autonoma unattended

1. Leggi `agentic/runner/PATCH_INSTALL.md` e `agentic/runner/SAFETY.md`.
2. Lavora in una branch/worktree dedicata e pulita.
3. Configura VS Code seguendo `agentic/runner/VSCODE_SETUP.md`.
4. Seleziona `Project Runner` e DeepSeek Long 64K.
5. Seleziona Autopilot.
6. Esegui `/run-project`.
7. Dopo una chiusura o un crash, esegui `/resume-project`.

### Esecuzione manuale di un task

1. Esegui `/run-next-task`.
2. Seleziona il modello indicato oppure Long 64K.
3. Esegui `/implement-task taskPath=...`.
4. Esegui `/review-task taskPath=...` in una sessione separata.

## Regola di contesto

Il file `agentic/runner/context/TASK-XXX.md` è la fonte autorevole del contesto. Le vecchie indicazioni generiche contenute nei task non devono causare letture ricorsive.

## Definition of Done minima

- implementazione nel perimetro;
- formatter, build e test previsti;
- review indipendente approvata;
- task e indice aggiornati;
- commit locale;
- report sotto `agentic/runner/runs/TASK-XXX/`.
