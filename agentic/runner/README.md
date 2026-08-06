# Autonomous Project Runner

Questa cartella contiene checkpoint, context package e report per eseguire il backlog con una sola sessione principale e subagent isolati.

## Principio

- Sessione principale: `Project Runner`, modello **DeepSeek V4 Flash Q2 - Long 64K**.
- Implementazione: subagent `Task Implementer`.
- Review: nuovo subagent `Task Reviewer`.
- Stato persistente: `STATE.md`.
- Contesto per task: `context/TASK-XXX.md`.
- Report: `runs/TASK-XXX/`.

Il runner non crea nuove chat principali. I subagent forniscono isolamento del contesto e restituiscono solo un riepilogo alla sessione coordinatrice.

## Avvio rapido

1. Leggi [VSCODE_SETUP.md](VSCODE_SETUP.md).
2. Esegui il lavoro in una branch/worktree dedicata.
3. Seleziona `Project Runner` e il modello Long 64K.
4. Seleziona il livello di permessi **Autopilot** solo nella worktree isolata.
5. Esegui `/run-project`.

Per riprendere dopo un’interruzione usa `/resume-project`.

## Sicurezza

Autopilot approva automaticamente modifiche e comandi. Prima dell’avvio leggi [SAFETY.md](SAFETY.md). Il runner non deve mai effettuare push o merge.
