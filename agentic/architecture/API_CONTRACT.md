# Contratto API iniziale

## Endpoint MVP

```text
POST   /api/work-requests
GET    /api/work-requests/{id}
POST   /api/work-requests/{id}/plan
POST   /api/agentic/tasks/{id}/execute
POST   /api/agentic/tasks/{id}/cancel
POST   /api/agentic/tasks/{id}/resume
GET    /api/agentic/tasks/{id}
GET    /api/agentic/tasks/{id}/events
GET    /api/agentic/tasks/{id}/artifacts
GET    /api/approvals
POST   /api/approvals/{id}/approve
POST   /api/approvals/{id}/reject
GET    /api/models
POST   /api/models/refresh
```

## Streaming

`GET /api/agentic/tasks/{id}/events` usa SSE e produce eventi tipizzati:

- TaskStarted;
- ModelSelected;
- AgentMessage;
- ToolStarted;
- ToolCompleted;
- ApprovalRequired;
- BuildCompleted;
- TestsCompleted;
- ReviewCompleted;
- TaskCompleted;
- TaskFailed.

## Error model

Usare Problem Details con `code`, `correlationId`, `retryable` e dettagli non sensibili.
