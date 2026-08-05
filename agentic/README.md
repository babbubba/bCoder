# Area agentica del progetto

Questa cartella contiene tutta la documentazione operativa destinata agli agenti e agli sviluppatori. Il codice applicativo deve restare fuori da `agentic/`, principalmente sotto `src/` e `tests/`.

## Navigazione

- [START_HERE.md](START_HERE.md): sequenza iniziale e primo task.
- [PROJECT.md](PROJECT.md): obiettivi, perimetro e requisiti.
- [AGENTS.md](AGENTS.md): regole operative complete.
- [planning/MASTER_PLAN.md](planning/MASTER_PLAN.md): piano dettagliato.
- [tasks/INDEX.md](tasks/INDEX.md): backlog eseguibile con scelta 32K/64K.
- [architecture/ARCHITECTURE.md](architecture/ARCHITECTURE.md): architettura target.
- [governance/](governance/): sicurezza, privacy, routing, qualità e test.
- [operations/](operations/): esecuzione, osservabilità e deployment.
- [guides/](guides/): contesto e riferimenti.

---

Questo pacchetto prepara un repository vuoto per sviluppare un orchestratore agentico locale-first.

L'obiettivo è usare **DeepSeek V4 Flash su DS4/DGX Spark** come manager principale, delegando sotto-task solo quando necessario a:

1. DeepSeek locale;
2. modelli OpenRouter gratuiti compatibili;
3. modelli economici a pagamento;
4. modelli frontier, esclusivamente con approvazione.

La selezione finale del modello è sempre vincolata da codice deterministico: privacy, capacità, budget, storico dei tentativi e policy aziendali prevalgono sulle preferenze espresse dall'LLM.

## Da dove partire

1. Leggi [START_HERE.md](START_HERE.md).
2. Leggi [MASTER_PLAN.md](planning/MASTER_PLAN.md).
3. Inizializza Git usando `scripts/init-repo.sh` oppure `scripts/init-repo.ps1`.
4. Apri la cartella in VS Code.
5. Seleziona il profilo DeepSeek indicato nel task: **Fast 32K** oppure **Long 64K**.
6. Avvia il task tramite `/implement-task` o selezionando l'agente `Implementer`.

## Documenti principali

- [PROJECT.md](PROJECT.md): requisiti e perimetro.
- [ARCHITECTURE.md](architecture/ARCHITECTURE.md): architettura target.
- [MASTER_PLAN.md](planning/MASTER_PLAN.md): piano completo di implementazione.
- [AGENTS.md](AGENTS.md): regole obbligatorie per gli agenti.
- [MODEL_ROUTING.md](governance/MODEL_ROUTING.md): strategia local/free/paid/frontier.
- [SECURITY.md](governance/SECURITY.md): sicurezza e protezione dei dati.
- [QUALITY_GATES.md](governance/QUALITY_GATES.md): condizioni per considerare concluso un task.
- [tasks/INDEX.md](tasks/INDEX.md): backlog ordinato e contesto consigliato.

## Principio operativo

Non chiedere mai al modello di “implementare tutto”. Ogni sessione deve lavorare su un solo file `agentic/tasks/TASK-xxx-*.md`, rispettarne i criteri di accettazione e concludersi con build, test, diff e aggiornamento dello stato.
