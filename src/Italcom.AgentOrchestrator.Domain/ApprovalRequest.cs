namespace Italcom.AgentOrchestrator.Domain
{
    public sealed class ApprovalRequest
    {
        public ApprovalRequest(
            Guid id,
            Guid workflowId,
            ApprovalType type,
            string reason,
            Cost? estimatedCost,
            DataClassification dataClassification,
            TimeSpan expiresIn)
        {
            Id = id;
            WorkflowId = workflowId;
            Type = type;
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
            EstimatedCost = estimatedCost;
            DataClassification = dataClassification;
            ExpiresAt = DateTime.UtcNow + expiresIn;
            Status = ApprovalStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public Guid WorkflowId { get; }
        public ApprovalType Type { get; }
        public string Reason { get; }
        public Cost? EstimatedCost { get; }
        public DataClassification DataClassification { get; }
        public DateTime ExpiresAt { get; }
        public ApprovalStatus Status { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public bool IsExpired => DateTime.UtcNow > ExpiresAt;

        public DomainResult<ApprovalRequest> Approve()
        {
            if (Status != ApprovalStatus.Pending)
                return DomainResult<ApprovalRequest>.Failure(
                    $"Cannot approve a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            if (IsExpired)
            {
                Status = ApprovalStatus.Expired;
                UpdatedAt = DateTime.UtcNow;
                return DomainResult<ApprovalRequest>.Failure(
                    "Approval request has expired",
                    DomainErrorCode.Timeout);
            }

            Status = ApprovalStatus.Approved;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<ApprovalRequest>.Success(this);
        }

        public DomainResult<ApprovalRequest> Reject()
        {
            if (Status != ApprovalStatus.Pending)
                return DomainResult<ApprovalRequest>.Failure(
                    $"Cannot reject a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = ApprovalStatus.Rejected;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<ApprovalRequest>.Success(this);
        }

        public DomainResult<ApprovalRequest> Cancel()
        {
            if (Status is ApprovalStatus.Approved or ApprovalStatus.Rejected or ApprovalStatus.Cancelled)
                return DomainResult<ApprovalRequest>.Failure(
                    $"Cannot cancel a request in {Status} state",
                    DomainErrorCode.InvalidTransition);

            Status = ApprovalStatus.Cancelled;
            UpdatedAt = DateTime.UtcNow;
            return DomainResult<ApprovalRequest>.Success(this);
        }

        public DomainResult<ApprovalRequest> CheckExpiry()
        {
            if (Status != ApprovalStatus.Pending)
                return DomainResult<ApprovalRequest>.Success(this);

            if (IsExpired)
            {
                Status = ApprovalStatus.Expired;
                UpdatedAt = DateTime.UtcNow;
            }

            return DomainResult<ApprovalRequest>.Success(this);
        }
    }
}
