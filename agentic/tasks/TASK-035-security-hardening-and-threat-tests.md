# TASK-035 — Security hardening and threat tests

| Campo | Valore |
|---|---|
| Fase | 7 |
| Stato iniziale | Planned |
| Contesto consigliato | **64K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Long 64K** |
| Dipendenze | [017](TASK-017-privacy-and-data-egress-gate.md), [027](TASK-027-safe-filesystem-tools.md), [028](TASK-028-safe-process-runner.md), [034](TASK-034-integration-and-end-to-end-harness.md) |
| Rischio | Medio/Alto |

## Obiettivo

Eseguire threat review e aggiungere test di bypass.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Long 64K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [ ] Prompt injection mitigata
- [ ] Path/command/SSRF tests
- [ ] Secret scan
- [ ] Approval bypass test

## Verifiche e test

- [ ] Security suite verde
- [ ] Manual checklist

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
/implement-task taskPath=agentic/tasks/TASK-035-security-hardening-and-threat-tests.md
```

In alternativa:

```text
Implementa esclusivamente TASK-035 leggendo agentic/AGENTS.md e agentic/tasks/TASK-035-security-hardening-and-threat-tests.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-035-security-hardening-and-threat-tests.md
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
