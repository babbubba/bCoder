using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain
{
    public sealed class ApprovalRequestTests
    {
        private static ApprovalRequest CreatePending() => new(
            Guid.NewGuid(), Guid.NewGuid(), ApprovalType.PaidModel,
            "budget threshold exceeded", new Cost(50, "USD"),
            DataClassification.Internal, TimeSpan.FromHours(24));

        [Fact]
        public void Constructor_sets_initial_status()
        {
            var req = CreatePending();
            Assert.Equal(ApprovalStatus.Pending, req.Status);
        }

        [Fact]
        public void Constructor_throws_on_null_reason() => Assert.Throws<ArgumentNullException>(() => new ApprovalRequest(
                                                                        Guid.NewGuid(), Guid.NewGuid(), ApprovalType.PaidModel,
                                                                        null!, null, DataClassification.Public, TimeSpan.FromHours(1)));

        [Fact]
        public void Constructor_sets_expiration()
        {
            var req = CreatePending();
            Assert.True(req.ExpiresAt > DateTime.UtcNow);
        }

        [Fact]
        public void Approve_transitions_to_Approved()
        {
            var req = CreatePending();
            var result = req.Approve();
            Assert.True(result.IsSuccess);
            Assert.Equal(ApprovalStatus.Approved, req.Status);
        }

        [Fact]
        public void Approve_from_non_pending_fails()
        {
            var req = CreatePending();
            _ = req.Approve();
            var result = req.Approve();
            Assert.True(result.IsFailure);
            Assert.Equal(DomainErrorCode.InvalidTransition, result.Error.Code);
        }

        [Fact]
        public void Approve_when_expired_transitions_to_Expired_and_fails()
        {
            var req = new ApprovalRequest(Guid.NewGuid(), Guid.NewGuid(), ApprovalType.PaidModel,
                "test", null, DataClassification.Public, TimeSpan.FromMilliseconds(1));
            Thread.Sleep(5); // ensure expired
            var result = req.Approve();
            Assert.True(result.IsFailure);
            Assert.Equal(DomainErrorCode.Timeout, result.Error.Code);
            Assert.Equal(ApprovalStatus.Expired, req.Status);
        }

        [Fact]
        public void Reject_transitions_to_Rejected()
        {
            var req = CreatePending();
            var result = req.Reject();
            Assert.True(result.IsSuccess);
            Assert.Equal(ApprovalStatus.Rejected, req.Status);
        }

        [Fact]
        public void Reject_from_non_pending_fails()
        {
            var req = CreatePending();
            _ = req.Approve();
            var result = req.Reject();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Cancel_from_Pending_succeeds()
        {
            var req = CreatePending();
            var result = req.Cancel();
            Assert.True(result.IsSuccess);
            Assert.Equal(ApprovalStatus.Cancelled, req.Status);
        }

        [Fact]
        public void Cancel_from_Approved_fails()
        {
            var req = CreatePending();
            _ = req.Approve();
            var result = req.Cancel();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void CheckExpiry_on_pending_expired_transitions_to_Expired()
        {
            var req = new ApprovalRequest(Guid.NewGuid(), Guid.NewGuid(), ApprovalType.PaidModel,
                "test", null, DataClassification.Public, TimeSpan.FromMilliseconds(1));
            Thread.Sleep(5);
            var result = req.CheckExpiry();
            Assert.True(result.IsSuccess);
            Assert.Equal(ApprovalStatus.Expired, req.Status);
        }

        [Fact]
        public void CheckExpiry_on_non_pending_does_nothing()
        {
            var req = CreatePending();
            _ = req.Approve();
            var before = req.Status;
            var result = req.CheckExpiry();
            Assert.True(result.IsSuccess);
            Assert.Equal(before, req.Status);
        }
    }
}
