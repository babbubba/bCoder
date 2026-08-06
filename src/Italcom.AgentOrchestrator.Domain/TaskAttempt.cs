namespace Italcom.AgentOrchestrator.Domain
{
    public sealed class TaskAttempt
    {
        public TaskAttempt(Guid id, Guid taskId, int attemptNumber, ProviderType provider, string modelId)
        {
            Id = id;
            TaskId = taskId;
            AttemptNumber = attemptNumber;
            Provider = provider;
            ModelId = modelId ?? throw new ArgumentNullException(nameof(modelId));
            Status = AttemptStatus.Queued;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public Guid TaskId { get; }
        public int AttemptNumber { get; }
        public ProviderType Provider { get; }
        public string ModelId { get; }
        public AttemptStatus Status { get; private set; }
        public Usage? Usage { get; private set; }
        public Cost? Cost { get; private set; }
        public bool? BuildSuccess { get; private set; }
        public bool? TestSuccess { get; private set; }
        public bool? ReviewApproved { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public DomainResult<TaskAttempt> Start()
        {
            if (Status != AttemptStatus.Queued)
                return DomainResult<TaskAttempt>.Failure(
                    $"Cannot start an attempt in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = AttemptStatus.Running;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<TaskAttempt>.Success(this);
        }

        public DomainResult<TaskAttempt> Complete(
            Usage usage, Cost cost, bool buildSuccess, bool testSuccess, bool reviewApproved)
        {
            if (Status != AttemptStatus.Running)
                return DomainResult<TaskAttempt>.Failure(
                    $"Cannot complete an attempt in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Usage = usage ?? throw new ArgumentNullException(nameof(usage));
            Cost = cost ?? throw new ArgumentNullException(nameof(cost));
            BuildSuccess = buildSuccess;
            TestSuccess = testSuccess;
            ReviewApproved = reviewApproved;
            Status = AttemptStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<TaskAttempt>.Success(this);
        }

        public DomainResult<TaskAttempt> Fail()
        {
            if (Status != AttemptStatus.Running)
                return DomainResult<TaskAttempt>.Failure(
                    $"Cannot fail an attempt in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = AttemptStatus.Failed;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<TaskAttempt>.Success(this);
        }

        public DomainResult<TaskAttempt> Timeout()
        {
            if (Status != AttemptStatus.Running)
                return DomainResult<TaskAttempt>.Failure(
                    $"Cannot timeout an attempt in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = AttemptStatus.Timeout;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<TaskAttempt>.Success(this);
        }

        public DomainResult<TaskAttempt> Cancel()
        {
            if (Status is AttemptStatus.Completed or AttemptStatus.Cancelled)
                return DomainResult<TaskAttempt>.Failure(
                    $"Cannot cancel an attempt in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = AttemptStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<TaskAttempt>.Success(this);
        }

        public bool IsSuccessful =>
            Status == AttemptStatus.Completed &&
            BuildSuccess == true &&
            TestSuccess == true &&
            ReviewApproved == true;
    }
}
