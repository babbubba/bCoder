# Architettura target

## Stile

Modular monolith con confini espliciti. L'MVP privilegia semplicità operativa, testabilità e controllo deterministico rispetto a una rete di microservizi.

## Solution proposta

```text
src/
  Italcom.AgentOrchestrator.Api/
  Italcom.AgentOrchestrator.Cli/
  Italcom.AgentOrchestrator.Domain/
  Italcom.AgentOrchestrator.Application/
  Italcom.AgentOrchestrator.AgentRuntime/
  Italcom.AgentOrchestrator.Infrastructure/
tests/
  Italcom.AgentOrchestrator.UnitTests/
  Italcom.AgentOrchestrator.IntegrationTests/
  Italcom.AgentOrchestrator.ArchitectureTests/
```

## Componenti

### Domain

Contiene entità, value object, enumerazioni e invarianti:

- WorkRequest;
- AgentTask;
- TaskAttempt;
- ModelDescriptor;
- ModelSelection;
- RoutingPolicy;
- ApprovalRequest;
- ToolInvocation;
- CostRecord;
- WorkflowCheckpoint.

Non dipende da HTTP, database, Agent Framework o SDK provider.

### Application

Contiene use case, porte e coordinamento applicativo:

- creare richiesta;
- pianificare;
- selezionare modello;
- avviare tentativo;
- valutare risultato;
- richiedere approvazione;
- riprendere workflow;
- generare report.

### AgentRuntime

Integra Microsoft Agent Framework e implementa:

- PlannerAgent;
- CodingAgent;
- ReviewerAgent;
- ResearchAgent;
- agent-as-tool delegation;
- sessioni e checkpoint;
- prompt rendering e structured output.

### Infrastructure

Implementa:

- DS4 provider;
- OpenRouter provider;
- PostgreSQL;
- Git/worktree;
- filesystem e process runner;
- build/test adapter;
- OpenTelemetry;
- secrets e configurazione.

### API

Espone REST e SSE. Non contiene logica di routing o business.

### CLI

Client sottile che chiama l'API. Può offrire modalità embedded solo in sviluppo.

## Flusso principale

```text
Request
  -> Planner locale
  -> Piano strutturato
  -> Router deterministico
  -> Tentativo locale
  -> Build/Test/Review
  -> Retry locale
  -> Free model consentito
  -> Paid approval se necessario
  -> Quality gate
  -> Diff e report per approvazione umana
```

## Principi

1. Gli agenti propongono; le policy autorizzano.
2. Il modello non riceve segreti.
3. I provider esterni ricevono solo il contesto minimo autorizzato.
4. Ogni task lavora in una worktree dedicata.
5. Il risultato è valutato da test deterministici prima del giudizio LLM.
6. Retry ed escalation sono espliciti e tracciati.
7. Le API dei provider sono isolate da adapter.
8. Tutte le operazioni lunghe supportano cancellazione e checkpoint.
