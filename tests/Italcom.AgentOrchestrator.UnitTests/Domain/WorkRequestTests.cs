using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain
{
    public sealed class WorkRequestTests
    {
        private static WorkRequest CreatePending() => new(Guid.NewGuid(), "test goal", DataClassification.Internal, null);

        [Fact]
        public void Constructor_sets_initial_status()
        {
            var wr = CreatePending();
            Assert.Equal(WorkRequestStatus.Pending, wr.Status);
        }

        [Fact]
        public void Constructor_throws_on_null_goal() => Assert.Throws<ArgumentNullException>(() => new WorkRequest(Guid.NewGuid(), null!, DataClassification.Public, null));

        [Fact]
        public void Plan_transitions_from_Pending_to_Planned()
        {
            var wr = CreatePending();
            var result = wr.Plan();
            Assert.True(result.IsSuccess);
            Assert.Equal(WorkRequestStatus.Planned, wr.Status);
        }

        [Fact]
        public void Plan_from_non_pending_fails()
        {
            var wr = CreatePending();
            _ = wr.Plan();
            var result = wr.Plan();
            Assert.True(result.IsFailure);
            Assert.Equal(DomainErrorCode.InvalidTransition, result.Error.Code);
        }

        [Fact]
        public void Start_transitions_from_Planned_to_InProgress()
        {
            var wr = CreatePending();
            _ = wr.Plan();
            var result = wr.Start();
            Assert.True(result.IsSuccess);
            Assert.Equal(WorkRequestStatus.InProgress, wr.Status);
        }

        [Fact]
        public void Start_from_non_planned_fails()
        {
            var wr = CreatePending();
            var result = wr.Start();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Complete_transitions_from_InProgress_to_Completed()
        {
            var wr = CreatePending();
            _ = wr.Plan();
            _ = wr.Start();
            var result = wr.Complete();
            Assert.True(result.IsSuccess);
            Assert.Equal(WorkRequestStatus.Completed, wr.Status);
        }

        [Fact]
        public void Complete_from_non_in_progress_fails()
        {
            var wr = CreatePending();
            var result = wr.Complete();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Cancel_from_Pending_succeeds()
        {
            var wr = CreatePending();
            var result = wr.Cancel();
            Assert.True(result.IsSuccess);
            Assert.Equal(WorkRequestStatus.Cancelled, wr.Status);
        }

        [Fact]
        public void Cancel_from_Completed_fails()
        {
            var wr = CreatePending();
            _ = wr.Plan();
            _ = wr.Start();
            _ = wr.Complete();
            var result = wr.Cancel();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Cancel_from_Cancelled_fails()
        {
            var wr = CreatePending();
            _ = wr.Cancel();
            var result = wr.Cancel();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Fail_transitions_from_InProgress_to_Failed()
        {
            var wr = CreatePending();
            _ = wr.Plan();
            _ = wr.Start();
            var result = wr.Fail();
            Assert.True(result.IsSuccess);
            Assert.Equal(WorkRequestStatus.Failed, wr.Status);
        }

        [Fact]
        public void Fail_from_non_in_progress_fails()
        {
            var wr = CreatePending();
            var result = wr.Fail();
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Status_is_updated_after_transition()
        {
            var wr = CreatePending();
            var before = wr.UpdatedAt;
            Thread.Sleep(1); // ensure time difference
            _ = wr.Plan();
            Assert.True(wr.UpdatedAt > before);
        }
    }
}
