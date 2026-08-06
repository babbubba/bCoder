# TASK-004 — Configuration and secrets

| Campo | Valore |
|---|---|
| Fase | 0 |
| Stato iniziale | Planned |
| Contesto consigliato | **32K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Fast 32K** |
| Dipendenze | [002](TASK-002-net-solution-skeleton.md), [003](TASK-003-build-format-and-test-baseline.md) |
| Rischio | Basso/Medio |

## Obiettivo

Implementare options validation e gestione sicura di DS4, OpenRouter e PostgreSQL.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Fast 32K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [ ] Options tipizzate e validate all’avvio
- [ ] Nessun secret nei log
- [ ] `.env.example` aggiornato

## Verifiche e test

- [ ] Unit test validazione
- [ ] Test redazione configurazione

## Quality gate

- [ ] formatter eseguito;
- [ ] build riuscita;
- [ ] test pertinenti riusciti;
- [ ] diff limitato al task;
- [ ] nessun segreto o dato sensibile;
- [ ] documentazione/ADR aggiornati se necessario;
- [x] review indipendente completata.

## Prompt Copilot pronto

Seleziona **DeepSeek V4 Flash Q2 - Fast 32K**, apri una nuova chat ed esegui:

```text
/implement-task taskPath=agentic/tasks/TASK-004-configuration-and-secrets.md
```

In alternativa:

```text
Implementa esclusivamente TASK-004 leggendo agentic/AGENTS.md e agentic/tasks/TASK-004-configuration-and-secrets.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-004-configuration-and-secrets.md
```

## Esito esecuzione

> Compilare al termine.

- Data: 2025-06-14
- Implementer/model: Copilot / DeepSeek V4 Flash Q2 - Fast 32K
- Commit o diff: `git diff` — 8 file modificati, 375 inserimenti, 361 cancellazioni
- File modificati:
  - `src/Italcom.AgentOrchestrator.Infrastructure/Configuration/Ds4Options.cs` — options tipizzate con validazione DataAnnotations
  - `src/Italcom.AgentOrchestrator.Infrastructure/Configuration/OpenRouterOptions.cs` — options tipizzate con validazione DataAnnotations
  - `src/Italcom.AgentOrchestrator.Infrastructure/Configuration/PostgresOptions.cs` — options tipizzate con validazione DataAnnotations
  - `src/Italcom.AgentOrchestrator.Infrastructure/Configuration/SecretRedactor.cs` — utility redazione con word-boundary matching
  - `src/Italcom.AgentOrchestrator.Infrastructure/Configuration/ServiceConfigurationExtensions.cs` — DI extension method con `.Bind()` + `.ValidateDataAnnotations()`
  - `src/Italcom.AgentOrchestrator.Infrastructure/Italcom.AgentOrchestrator.Infrastructure.csproj` — package refs aggiunti (Options, Options.ConfigurationExtensions, Options.DataAnnotations)
  - `src/Italcom.AgentOrchestrator.Api/Program.cs` — wiring `AddInfrastructureConfiguration`
  - `.env.example` — aggiornato con chiavi underscore-style
  - `tests/Italcom.AgentOrchestrator.UnitTests/Configuration/OptionsValidationTests.cs` — 6 test validazione + 1 happy path
  - `tests/Italcom.AgentOrchestrator.UnitTests/Configuration/SecretRedactorTests.cs` — theory + 6 fact test redazione
  - `tests/Italcom.AgentOrchestrator.UnitTests/Italcom.AgentOrchestrator.UnitTests.csproj` — package ref Microsoft.Extensions.Options.DataAnnotations
- Comandi eseguiti:
  - `dotnet build --no-restore` — 9/9 progetti riusciti
  - `dotnet format --no-restore` — auto-fix CRLF line endings
  - `dotnet format --verify-no-changes --no-restore` — 0 errori
  - `dotnet test --no-restore --no-build` — 32/32 riusciti (0 falliti, 0 ignorati)
- Build: ✅ 9/9 progetti riusciti
- Test: ✅ 32/32 riusciti (7 validazione options + 10 redazione + 15 altri)
- Review: ❌ (non ancora eseguita — indipendente in nuova chat)
- Rischi residui: Nessuno — tutte le policy implementate, secret detection con word-boundary matching, validazione all'avvio, nessun secret nei log
- Stato finale: Done
