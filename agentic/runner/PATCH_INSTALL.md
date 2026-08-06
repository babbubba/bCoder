# Installazione del patch autonomous runner

Questo ZIP è un overlay: contiene percorsi relativi alla root del repository.

## Applicazione

1. Assicurati di avere un commit o un backup delle modifiche correnti.
2. Estrai lo ZIP nella root del repository consentendo la sostituzione dei file omonimi.
3. Controlla `git diff` prima di accettare le modifiche.
4. Non sovrascrivere manualmente gli stati dei task: il patch non sostituisce i file `agentic/tasks/TASK-*.md` né `agentic/tasks/INDEX.md`.
5. Ricarica VS Code con `Developer: Reload Window`.
6. Segui `agentic/runner/VSCODE_SETUP.md`.

## Perché i task non vengono sostituiti

Il repository potrebbe già contenere task completati, esiti e stati aggiornati. Il patch aggiunge context package separati sotto `agentic/runner/context/`, che prevalgono sulle vecchie istruzioni senza cancellare lo storico.
