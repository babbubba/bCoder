# Area agentica del progetto

Questa cartella contiene piano, architettura, governance, task e stato operativo degli agenti. Il codice applicativo resta sotto `src/` e `tests/`.

## Esecuzione autonoma

- [runner/README.md](runner/README.md): panoramica.
- [runner/VSCODE_SETUP.md](runner/VSCODE_SETUP.md): configurazione.
- [runner/SAFETY.md](runner/SAFETY.md): limiti di Autopilot.
- [runner/STATE.md](runner/STATE.md): checkpoint persistente.
- [runner/context/](runner/context/): contesto autorizzato per ogni task.

## Documentazione

- [START_HERE.md](START_HERE.md): avvio.
- [PROJECT.md](PROJECT.md): obiettivi e perimetro.
- [planning/MASTER_PLAN.md](planning/MASTER_PLAN.md): piano.
- [tasks/INDEX.md](tasks/INDEX.md): backlog.
- [architecture/ARCHITECTURE.md](architecture/ARCHITECTURE.md): architettura.
- [governance/](governance/): sicurezza, privacy, routing, qualità e test.
- [operations/](operations/): esecuzione, osservabilità e deployment.

## Regola fondamentale

Durante implementazione e review non leggere il piano consolidato o l’intera documentazione. Usare sempre il context package del task corrente.
