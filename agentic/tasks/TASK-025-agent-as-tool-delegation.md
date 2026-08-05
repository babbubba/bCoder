# TASK-025 — Agent-as-tool delegation

| Campo | Valore |
|---|---|
| Fase | 4 |
| Stato iniziale | Planned |
| Contesto consigliato | **64K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Long 64K** |
| Dipendenze | [021](TASK-021-planner-agent.md), [022](TASK-022-coding-agent.md), [023](TASK-023-reviewer-agent.md), [024](TASK-024-research-agent.md) |
| Rischio | Medio/Alto |

## Obiettivo

Esporre coder/reviewer/research come strumenti del manager mantenendo il controllo.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Long 64K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [ ] Contesto minimo per sub-agent
- [ ] No secret propagation
- [ ] Trace parent-child

## Verifiche e test

- [ ] Delegation integration tests
- [ ] Tool result truncation

## Quality gate

- [ ] formatter eseguito;
- [ ] build riuscita;
- [ ] test pertinenti riusciti;
- [ ] diff limitato al task;
- [ ] nessun segreto o dato sensibile;
- [ ] documentazione/ADR aggiornati se necessario;
- [ ] review indipendente completata.

## Prompt Copilot pronto

Seleziona **DeepSeek V4 Flash Q2 - Long 64K**, apri una nuova chat ed esegui:

```text
/implement-task taskPath=agentic/tasks/TASK-025-agent-as-tool-delegation.md
```

In alternativa:

```text
Implementa esclusivamente TASK-025 leggendo agentic/AGENTS.md e agentic/tasks/TASK-025-agent-as-tool-delegation.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-025-agent-as-tool-delegation.md
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
