# TASK-008 — API contracts and error model

| Campo | Valore |
|---|---|
| Fase | 1 |
| Stato iniziale | Planned |
| Contesto consigliato | **32K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Fast 32K** |
| Dipendenze | [005](TASK-005-domain-model-and-invariants.md) |
| Rischio | Basso/Medio |

## Obiettivo

Definire DTO, Problem Details, codici errore ed eventi SSE senza implementare tutti gli endpoint.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Fast 32K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [ ] Contratti versionabili
- [ ] Domain non esposto direttamente
- [ ] Errori retryable/non-retryable

## Verifiche e test

- [ ] Serialization tests
- [ ] Contract snapshots

## Quality gate

- [ ] formatter eseguito;
- [ ] build riuscita;
- [ ] test pertinenti riusciti;
- [ ] diff limitato al task;
- [ ] nessun segreto o dato sensibile;
- [ ] documentazione/ADR aggiornati se necessario;
- [ ] review indipendente completata.

## Prompt Copilot pronto

Seleziona **DeepSeek V4 Flash Q2 - Fast 32K**, apri una nuova chat ed esegui:

```text
/implement-task taskPath=agentic/tasks/TASK-008-api-contracts-and-error-model.md
```

In alternativa:

```text
Implementa esclusivamente TASK-008 leggendo agentic/AGENTS.md e agentic/tasks/TASK-008-api-contracts-and-error-model.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-008-api-contracts-and-error-model.md
```

## Esito esecuzione

> Compilare al termine.

- Data:
- Implementer/model:
- Commit o diff:
- File modificati:
- Comandi eseguiti:
- Build:
- Test:
- Review:
- Rischi residui:
- Stato finale:
