namespace Italcom.AgentOrchestrator.Domain;

public sealed class TaskAttempt
{
    private AttemptStatus _status;

    public TaskAttempt(Guid id, Guid taskId, int attemptNumber, ProviderType provider, string modelId)
    {
        Id = id;
        TaskId = taskId;
        AttemptNumber = attemptNumber;
        Provider = provider;
        ModelId = modelId ?? throw new ArgumentNullException(nameof(modelId));
        _status = AttemptStatus.Queued;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public Guid TaskId { get; }
    public int AttemptNumber { get; }
    public ProviderType Provider { get; }
    public string ModelId { get; }
    public AttemptStatus Status => _status;
    public Usage? Usage { get; private set; }
    public Cost? Cost { get; private set; }
    public bool? BuildSuccess { get; private set; }
    public bool? TestSuccess { get; private set; }
    public bool? ReviewApproved { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public DomainResult<TaskAttempt> Start()
    {
        if (_status != AttemptStatus.Queued)
            return DomainResult<TaskAttempt>.Failure(
                $"Cannot start an attempt in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = AttemptStatus.Running;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<TaskAttempt>.Success(this);
    }

    public DomainResult<TaskAttempt> Complete(
        Usage usage, Cost cost, bool buildSuccess, bool testSuccess, bool reviewApproved)
    {
        if (_status != AttemptStatus.Running)
            return DomainResult<TaskAttempt>.Failure(
                $"Cannot complete an attempt in {_status} state",
                DomainErrorCode.InvalidTransition);

        Usage = usage ?? throw new ArgumentNullException(nameof(usage));
        Cost = cost ?? throw new ArgumentNullException(nameof(cost));
        BuildSuccess = buildSuccess;
        TestSuccess = testSuccess;
        ReviewApproved = reviewApproved;
        _status = AttemptStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<TaskAttempt>.Success(this);
    }

    public DomainResult<TaskAttempt> Fail()
    {
        if (_status != AttemptStatus.Running)
            return DomainResult<TaskAttempt>.Failure(
                $"Cannot fail an attempt in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = AttemptStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<TaskAttempt>.Success(this);
    }

    public DomainResult<TaskAttempt> Timeout()
    {
        if (_status != AttemptStatus.Running)
            return DomainResult<TaskAttempt>.Failure(
                $"Cannot timeout an attempt in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = AttemptStatus.Timeout;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<TaskAttempt>.Success(this);
    }

    public DomainResult<TaskAttempt> Cancel()
    {
        if (_status is AttemptStatus.Completed or AttemptStatus.Cancelled)
            return DomainResult<TaskAttempt>.Failure(
                $"Cannot cancel an attempt in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = AttemptStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<TaskAttempt>.Success(this);
    }

    public bool IsSuccessful =>
        _status == AttemptStatus.Completed &&
        BuildSuccess == true &&
        TestSuccess == true &&
        ReviewApproved == true;
}
