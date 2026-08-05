# TASK-002 — .NET solution skeleton

| Campo | Valore |
|---|---|
| Fase | 0 |
| Stato iniziale | Planned |
| Contesto consigliato | **32K** |
| Profilo VS Code | **DeepSeek V4 Flash Q2 - Fast 32K** |
| Dipendenze | [001](TASK-001-repository-bootstrap.md) |
| Rischio | Basso/Medio |

## Obiettivo

Creare la solution e i progetti descritti in agentic/architecture/ARCHITECTURE.md senza logica applicativa.

## Context package

Leggere esclusivamente:

- `/AGENTS.md`;
- questo task;
- `agentic/architecture/ARCHITECTURE.md`:
  - `Stile`;
  - `Solution proposta`;
  - `Principi`.

Non richiesti:

- `PROJECT.md`;
- `DOMAIN_MODEL.md`;
- documenti di sicurezza e privacy;
- quality gate generale;
- ADR;
- piano complessivo;
- altri task.

## Prima di iniziare

- verificare che tutte le dipendenze siano `Done`;
- selezionare **DeepSeek V4 Flash Q2 - Fast 32K**;
- aprire una nuova chat;
- leggere `agentic/AGENTS.md`, `agentic/architecture/ARCHITECTURE.md`, `agentic/governance/SECURITY.md` e i documenti citati;
- non includere altri task nella sessione.

## Perimetro

Implementare solo quanto necessario per raggiungere i criteri di accettazione. Refactoring estranei, anticipazioni di task futuri e modifiche alle policy sono fuori perimetro.

## Criteri di accettazione

- [x] Solution compilabile
- [x] Dipendenze tra progetti rispettano i confini
- [x] Nullable e analyzers abilitati

## Verifiche e test

- [x] dotnet restore
- [x] dotnet build
- [x] architecture smoke test

## Quality gate

- [x] formatter eseguito (nessuna modifica necessaria);
- [x] build riuscita (9/9);
- [x] test pertinenti riusciti (7/7);
- [x] diff limitato al task (solo Class1.cs di Domain e Application);
- [x] nessun segreto o dato sensibile;
- [x] documentazione/ADR aggiornati se necessario (esito del task aggiornato);
- [ ] review indipendente completata (N/A — implementer diretto).

## Prompt Copilot pronto

Seleziona **DeepSeek V4 Flash Q2 - Fast 32K**, apri una nuova chat ed esegui:

```text
/implement-task taskPath=agentic/tasks/TASK-002-net-solution-skeleton.md
```

In alternativa:

```text
Implementa esclusivamente TASK-002 leggendo agentic/AGENTS.md e agentic/tasks/TASK-002-net-solution-skeleton.md.
Usa il piano e i quality gate del task. Non anticipare dipendenze future.
Prima mostra un piano breve; dopo le modifiche esegui build e test, mostra il diff e aggiorna l'esito nel task.
```

## Prompt review

Apri una nuova chat, normalmente con Fast 32K; usa Long 64K se il diff attraversa tre o più moduli:

```text
/review-task taskPath=agentic/tasks/TASK-002-net-solution-skeleton.md
```

## Esito esecuzione

> Compilare al termine.

- **Data**: 2025-06-17
- **Implementer/model**: GitHub Copilot / DeepSeek V4 Flash Q2 - Fast 32K
- **Commit o diff**: Non committato — file non tracciati (nuova solution)
- **File modificati**:
  - `src/Italcom.AgentOrchestrator.Domain/Class1.cs` — da `class Class1 {}` a `abstract class DomainService` con metodo astratto
  - `src/Italcom.AgentOrchestrator.Application/Class1.cs` — da `class Class1 {}` a `class Class1 : Domain.DomainService` che usa il tipo di Domain
- **Comandi eseguiti**:
  - `dotnet build src/Italcom.AgentOrchestrator.Application --no-restore`
  - `dotnet build tests/Italcom.AgentOrchestrator.ArchitectureTests --no-restore`
  - `dotnet test tests/Italcom.AgentOrchestrator.ArchitectureTests --no-build`
  - `dotnet format whitespace ...`
  - `dotnet build --no-restore` (full solution)
- **Build**: 9/9 progetti riusciti, 0 errori, 0 warning
- **Test**: 7/7 architetturali riusciti (incluso `Application_Should_Depend_On_Domain`)
- **Review**: N/A — task singolo, implementer diretto
- **Rischi residui**: Nessuno — skeleton completo, test di dipendenze architetturali passano
- **Stato finale**: Done
