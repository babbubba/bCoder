# Task index

Stato iniziale: TASK-001 `Ready`; tutti gli altri `Planned`. Aggiornare questa tabella insieme al task.

| ID | Fase | Task | Contesto | Dipendenze | Stato |
|---|---:|---|---:|---|---|
| [001](TASK-001-repository-bootstrap.md) | 0 | Repository bootstrap | **32K** | — | Ready |
| [002](TASK-002-net-solution-skeleton.md) | 0 | .NET solution skeleton | **32K** | 001 | Planned |
| [003](TASK-003-build-format-and-test-baseline.md) | 0 | Build, format and test baseline | **32K** | 002 | Planned |
| [004](TASK-004-configuration-and-secrets.md) | 0 | Configuration and secrets | **32K** | 002, 003 | Planned |
| [005](TASK-005-domain-model-and-invariants.md) | 1 | Domain model and invariants | **64K** | 002, 003 | Planned |
| [006](TASK-006-postgresql-persistence-and-migrations.md) | 1 | PostgreSQL persistence and migrations | **64K** | 004, 005 | Planned |
| [007](TASK-007-observability-baseline.md) | 1 | Observability baseline | **32K** | 002, 004 | Planned |
| [008](TASK-008-api-contracts-and-error-model.md) | 1 | API contracts and error model | **32K** | 005 | Planned |
| [009](TASK-009-common-model-provider-abstraction.md) | 2 | Common model provider abstraction | **32K** | 005 | Planned |
| [010](TASK-010-ds4-provider.md) | 2 | DS4 provider | **32K** | 004, 009 | Planned |
| [011](TASK-011-openrouter-provider.md) | 2 | OpenRouter provider | **32K** | 004, 009 | Planned |
| [012](TASK-012-openrouter-model-catalog-sync.md) | 2 | OpenRouter model catalog sync | **64K** | 011 | Planned |
| [013](TASK-013-capability-and-pricing-normalization.md) | 2 | Capability and pricing normalization | **64K** | 012 | Planned |
| [014](TASK-014-usage-and-cost-accounting.md) | 2 | Usage and cost accounting | **32K** | 006, 009, 011 | Planned |
| [015](TASK-015-deterministic-routing-engine.md) | 3 | Deterministic routing engine | **64K** | 005, 013, 014 | Planned |
| [016](TASK-016-free-first-selection-policy.md) | 3 | Free-first selection policy | **64K** | 015 | Planned |
| [017](TASK-017-privacy-and-data-egress-gate.md) | 3 | Privacy and data-egress gate | **64K** | 005, 015 | Planned |
| [018](TASK-018-budget-and-human-approval-gate.md) | 3 | Budget and human approval gate | **64K** | 006, 014, 015 | Planned |
| [019](TASK-019-retry-evaluation-and-escalation.md) | 3 | Retry, evaluation and escalation | **64K** | 015, 016, 017, 018 | Planned |
| [020](TASK-020-microsoft-agent-framework-integration.md) | 4 | Microsoft Agent Framework integration | **64K** | 009, 010, 019 | Planned |
| [021](TASK-021-planner-agent.md) | 4 | Planner agent | **64K** | 020 | Planned |
| [022](TASK-022-coding-agent.md) | 4 | Coding agent | **64K** | 020, 021 | Planned |
| [023](TASK-023-reviewer-agent.md) | 4 | Reviewer agent | **32K** | 020, 022 | Planned |
| [024](TASK-024-research-agent.md) | 4 | Research agent | **32K** | 020, 017 | Planned |
| [025](TASK-025-agent-as-tool-delegation.md) | 4 | Agent-as-tool delegation | **64K** | 021, 022, 023, 024 | Planned |
| [026](TASK-026-git-repository-and-worktree-manager.md) | 5 | Git repository and worktree manager | **64K** | 005, 006 | Planned |
| [027](TASK-027-safe-filesystem-tools.md) | 5 | Safe filesystem tools | **32K** | 026, 017 | Planned |
| [028](TASK-028-safe-process-runner.md) | 5 | Safe process runner | **64K** | 026, 027 | Planned |
| [029](TASK-029-build-and-test-adapters.md) | 5 | Build and test adapters | **32K** | 028 | Planned |
| [030](TASK-030-checkpointed-orchestration-workflow.md) | 5 | Checkpointed orchestration workflow | **64K** | 019, 025, 026, 029 | Planned |
| [031](TASK-031-rest-and-sse-api.md) | 6 | REST and SSE API | **32K** | 008, 030 | Planned |
| [032](TASK-032-cli-client.md) | 6 | CLI client | **32K** | 031 | Planned |
| [033](TASK-033-administration-and-policy-endpoints.md) | 6 | Administration and policy endpoints | **32K** | 012, 018, 031 | Planned |
| [034](TASK-034-integration-and-end-to-end-harness.md) | 7 | Integration and end-to-end harness | **64K** | 030, 031, 032 | Planned |
| [035](TASK-035-security-hardening-and-threat-tests.md) | 7 | Security hardening and threat tests | **64K** | 017, 027, 028, 034 | Planned |
| [036](TASK-036-performance-and-concurrency-validation.md) | 7 | Performance and concurrency validation | **64K** | 030, 034 | Planned |
| [037](TASK-037-packaging-deployment-and-mvp-runbook.md) | 7 | Packaging, deployment and MVP runbook | **32K** | 033, 034, 035, 036 | Planned |

## Regola di avanzamento

Un task diventa `Ready` solo quando tutte le dipendenze sono `Done`. La review avviene in una nuova chat.
