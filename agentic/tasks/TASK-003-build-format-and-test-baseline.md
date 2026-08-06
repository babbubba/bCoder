# TASK-003 — Build, format and test baseline

| Campo | Valore |
|---|---|
| Fase | 0 |
| Stato iniziale | Planned |
| Contesto consigliato | **32K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Fast 32K** |
| Dipendenze | [002](TASK-002-net-solution-skeleton.md) |
| Rischio | Basso/Medio |

## Obiettivo

Aggiungere configurazione comune, formatter, analyzers e pipeline locale di build/test.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Fast 32K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [x] Comando unico di verifica locale (`scripts\verify.ps1`)
- [x] Test project eseguibile (9 test runner xUnit funzionanti)
- [x] Build warning policy documentata (`agentic/governance/WARNING_POLICY.md`)

## Verifiche e test

- [ ] dotnet format --verify-no-changes
- [ ] dotnet build
- [ ] dotnet test

## Quality gate

- [x] formatter eseguito;
- [x] build riuscita;
- [x] test pertinenti riusciti;
- [x] diff limitato al task;
- [x] nessun segreto o dato sensibile;
- [x] documentazione/ADR aggiornati se necessario (WARNING_POLICY.md creato);
- [ ] review indipendente completata (da eseguire).

## Prompt Copilot pronto

Seleziona **DeepSeek V4 Flash Q2 - Fast 32K**, apri una nuova chat ed esegui:

```text
/implement-task taskPath=agentic/tasks/TASK-003-build-format-and-test-baseline.md
```

In alternativa:

```text
Implementa esclusivamente TASK-003 leggendo agentic/AGENTS.md e agentic/tasks/TASK-003-build-format-and-test-baseline.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-003-build-format-and-test-baseline.md
```

## Esito esecuzione

> Compilare al termine.

- Data: 2025-03-25
- Implementer/model: Implementer / DeepSeek V4 Flash Q2 - Fast 32K
- Commit o diff: (non eseguito push)
- File modificati:
  - `Directory.Build.props` — centralizzato TargetFramework, Nullable, TreatWarningsAsErrors, analyzers, NoWarn CS1591
  - `tests/Directory.Build.props` — centralizzato test SDK, xUnit, coverlet
  - `src/*/*.csproj` (9 file) — semplificati ereditando da Directory.Build.props
  - `.editorconfig` — regole complete IDE/formatting/stile
  - `scripts/verify.ps1` — pipeline di verifica a 3 step
  - `tests/Italcom.AgentOrchestrator.ArchitectureTests/ArchitectureTests.cs` — commentati campi IDE0052 non utilizzati
  - `agentic/governance/WARNING_POLICY.md` — documentazione policy avvisi build
- Comandi eseguiti:
  - `dotnet format` — auto-fix placeholder files
  - `dotnet format --verify-no-changes` — pass (zero issues)
  - `dotnet build` — success (9/9 progetti)
  - `dotnet test` — success (9/9 test, 0 falliti, 0 ignorati)
  - `scripts\verify.ps1` — full pipeline pass
- Build: **9/9 riusciti**, zero errori/avvisi, TreatWarningsAsErrors attivo
- Test: **9/9 riusciti** (3 Unit, 3 Integration, 3 Architecture), durata 0,6s
- Review: (da completare con `/review-task`)
- Rischi residui:
  - `CS1591` soppresso globalmente — quando i progetti avranno doc XML completi, rimuovere dal NoWarn
  - I progetti placeholder (Class1.cs, Program.cs) sono scheletri — le future implementazioni dovranno rispettare le regole IDE
- Stato finale: **Done** ✅
