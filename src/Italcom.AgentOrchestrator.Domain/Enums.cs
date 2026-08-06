namespace Italcom.AgentOrchestrator.Domain;

public enum WorkRequestStatus
{
    Pending,
    Planned,
    InProgress,
    Completed,
    Cancelled,
    Failed
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    Failed,
    Skipped,
    Escalated
}

public enum AttemptStatus
{
    Queued,
    Running,
    Completed,
    Failed,
    Timeout,
    Cancelled
}

public enum ApprovalStatus
{
    Pending,
    Approved,
    Rejected,
    Expired,
    Cancelled
}

public enum ModelTier
{
    Local,
    Free,
    Paid,
    Frontier
}

public enum DataClassification
{
    Public,
    Internal,
    Confidential,
    Restricted
}

public enum ProviderType
{
    DS4,
    OpenRouter,
    Other
}

public enum ModelAvailability
{
    Available,
    Unavailable,
    Deprecated
}

public enum ApprovalType
{
    ExternalProvider,
    PaidModel,
    DestructiveOperation,
    DataExport,
    PolicyOverride
}
