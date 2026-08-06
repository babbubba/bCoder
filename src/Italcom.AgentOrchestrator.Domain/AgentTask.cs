namespace Italcom.AgentOrchestrator.Domain;

public sealed class AgentTask
{
    private TaskStatus _status;
    private readonly List<Guid> _dependencyIds = [];

    public AgentTask(
        Guid id,
        Guid workRequestId,
        string description,
        IReadOnlyList<Guid> dependencyIds,
        string? acceptanceCriteria = null,
        int? contextHint = null,
        string? riskLabel = null)
    {
        Id = id;
        WorkRequestId = workRequestId;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        _dependencyIds = dependencyIds?.ToList() ?? throw new ArgumentNullException(nameof(dependencyIds));
        AcceptanceCriteria = acceptanceCriteria;
        ContextHint = contextHint;
        RiskLabel = riskLabel;
        _status = TaskStatus.NotStarted;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public Guid WorkRequestId { get; }
    public string Description { get; }
    public IReadOnlyList<Guid> DependencyIds => _dependencyIds.AsReadOnly();
    public string? AcceptanceCriteria { get; }
    public int? ContextHint { get; }
    public string? RiskLabel { get; }
    public TaskStatus Status => _status;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public DomainResult<AgentTask> Start()
    {
        if (_status != TaskStatus.NotStarted)
            return DomainResult<AgentTask>.Failure(
                $"Cannot start a task in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = TaskStatus.InProgress;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<AgentTask>.Success(this);
    }

    public DomainResult<AgentTask> Complete()
    {
        if (_status != TaskStatus.InProgress)
            return DomainResult<AgentTask>.Failure(
                $"Cannot complete a task in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = TaskStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<AgentTask>.Success(this);
    }

    public DomainResult<AgentTask> Fail()
    {
        if (_status != TaskStatus.InProgress)
            return DomainResult<AgentTask>.Failure(
                $"Cannot fail a task in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = TaskStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<AgentTask>.Success(this);
    }

    public DomainResult<AgentTask> Skip()
    {
        if (_status != TaskStatus.NotStarted)
            return DomainResult<AgentTask>.Failure(
                $"Cannot skip a task in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = TaskStatus.Skipped;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<AgentTask>.Success(this);
    }

    public DomainResult<AgentTask> Escalate()
    {
        if (_status != TaskStatus.InProgress)
            return DomainResult<AgentTask>.Failure(
                $"Cannot escalate a task in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = TaskStatus.Escalated;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<AgentTask>.Success(this);
    }
}
