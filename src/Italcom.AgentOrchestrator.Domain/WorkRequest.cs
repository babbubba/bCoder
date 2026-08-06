namespace Italcom.AgentOrchestrator.Domain
{
    public sealed class WorkRequest
    {
        public WorkRequest(Guid id, string goal, DataClassification dataClassification, Budget? budget)
        {
            Id = id;
            Goal = goal ?? throw new ArgumentNullException(nameof(goal));
            DataClassification = dataClassification;
            Budget = budget;
            Status = WorkRequestStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string Goal { get; }
        public DataClassification DataClassification { get; }
        public Budget? Budget { get; }
        public WorkRequestStatus Status { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public DomainResult<WorkRequest> Plan()
        {
            if (Status != WorkRequestStatus.Pending)
                return DomainResult<WorkRequest>.Failure(
                    $"Cannot plan a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = WorkRequestStatus.Planned;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<WorkRequest>.Success(this);
        }

        public DomainResult<WorkRequest> Start()
        {
            if (Status != WorkRequestStatus.Planned)
                return DomainResult<WorkRequest>.Failure(
                    $"Cannot start a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = WorkRequestStatus.InProgress;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<WorkRequest>.Success(this);
        }

        public DomainResult<WorkRequest> Complete()
        {
            if (Status != WorkRequestStatus.InProgress)
                return DomainResult<WorkRequest>.Failure(
                    $"Cannot complete a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = WorkRequestStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<WorkRequest>.Success(this);
        }

        public DomainResult<WorkRequest> Cancel()
        {
            if (Status is WorkRequestStatus.Completed or WorkRequestStatus.Cancelled)
                return DomainResult<WorkRequest>.Failure(
                    $"Cannot cancel a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = WorkRequestStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<WorkRequest>.Success(this);
        }

        public DomainResult<WorkRequest> Fail()
        {
            if (Status != WorkRequestStatus.InProgress)
                return DomainResult<WorkRequest>.Failure(
                    $"Cannot fail a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = WorkRequestStatus.Failed;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<WorkRequest>.Success(this);
        }
    }
}
