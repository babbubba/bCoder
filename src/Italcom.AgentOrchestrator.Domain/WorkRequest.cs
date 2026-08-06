using System.Runtime.CompilerServices;

namespace Italcom.AgentOrchestrator.Domain;

public sealed class WorkRequest
{
    private WorkRequestStatus _status;

    public WorkRequest(Guid id, string goal, DataClassification dataClassification, Budget? budget)
    {
        Id = id;
        Goal = goal ?? throw new ArgumentNullException(nameof(goal));
        DataClassification = dataClassification;
        Budget = budget;
        _status = WorkRequestStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public string Goal { get; }
    public DataClassification DataClassification { get; }
    public Budget? Budget { get; }
    public WorkRequestStatus Status => _status;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public DomainResult<WorkRequest> Plan()
    {
        if (_status != WorkRequestStatus.Pending)
            return DomainResult<WorkRequest>.Failure(
                $"Cannot plan a request in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = WorkRequestStatus.Planned;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<WorkRequest>.Success(this);
    }

    public DomainResult<WorkRequest> Start()
    {
        if (_status != WorkRequestStatus.Planned)
            return DomainResult<WorkRequest>.Failure(
                $"Cannot start a request in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = WorkRequestStatus.InProgress;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<WorkRequest>.Success(this);
    }

    public DomainResult<WorkRequest> Complete()
    {
        if (_status != WorkRequestStatus.InProgress)
            return DomainResult<WorkRequest>.Failure(
                $"Cannot complete a request in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = WorkRequestStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<WorkRequest>.Success(this);
    }

    public DomainResult<WorkRequest> Cancel()
    {
        if (_status is WorkRequestStatus.Completed or WorkRequestStatus.Cancelled)
            return DomainResult<WorkRequest>.Failure(
                $"Cannot cancel a request in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = WorkRequestStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<WorkRequest>.Success(this);
    }

    public DomainResult<WorkRequest> Fail()
    {
        if (_status != WorkRequestStatus.InProgress)
            return DomainResult<WorkRequest>.Failure(
                $"Cannot fail a request in {_status} state",
                DomainErrorCode.InvalidTransition);

        _status = WorkRequestStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
        return DomainResult<WorkRequest>.Success(this);
    }
}
