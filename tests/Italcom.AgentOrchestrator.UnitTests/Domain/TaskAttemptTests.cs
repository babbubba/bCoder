using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class TaskAttemptTests
{
    private static TaskAttempt CreateQueued() => new(
        Guid.NewGuid(), Guid.NewGuid(), 1, ProviderType.DS4, "deepseek-coder-v2");

    [Fact]
    public void Constructor_sets_initial_status()
    {
        var attempt = CreateQueued();
        Assert.Equal(AttemptStatus.Queued, attempt.Status);
    }

    [Fact]
    public void Constructor_throws_on_null_modelId()
    {
        Assert.Throws<ArgumentNullException>(() => new TaskAttempt(
            Guid.NewGuid(), Guid.NewGuid(), 1, ProviderType.DS4, null!));
    }

    [Fact]
    public void Start_transitions_from_Queued_to_Running()
    {
        var attempt = CreateQueued();
        var result = attempt.Start();
        Assert.True(result.IsSuccess);
        Assert.Equal(AttemptStatus.Running, attempt.Status);
    }

    [Fact]
    public void Start_from_non_queued_fails()
    {
        var attempt = CreateQueued();
        attempt.Start();
        var result = attempt.Start();
        Assert.True(result.IsFailure);
        Assert.Equal(DomainErrorCode.InvalidTransition, result.Error.Code);
    }

    [Fact]
    public void Complete_transitions_and_stores_results()
    {
        var attempt = CreateQueued();
        attempt.Start();
        var usage = new Usage(100, 200);
        var cost = new Cost(0.05m, "USD");
        var result = attempt.Complete(usage, cost, buildSuccess: true, testSuccess: true, reviewApproved: true);

        Assert.True(result.IsSuccess);
        Assert.Equal(AttemptStatus.Completed, attempt.Status);
        Assert.Equal(300, attempt.Usage!.TotalTokens);
        Assert.Equal(0.05m, attempt.Cost!.Amount);
        Assert.True(attempt.BuildSuccess);
        Assert.True(attempt.TestSuccess);
        Assert.True(attempt.ReviewApproved);
    }

    [Fact]
    public void Complete_from_non_running_fails()
    {
        var attempt = CreateQueued();
        var usage = new Usage(0, 0);
        var cost = Cost.Zero();
        var result = attempt.Complete(usage, cost, true, true, true);
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Complete_throws_on_null_usage()
    {
        var attempt = CreateQueued();
        attempt.Start();
        Assert.Throws<ArgumentNullException>(() =>
            attempt.Complete(null!, Cost.Zero(), true, true, true));
    }

    [Fact]
    public void Complete_throws_on_null_cost()
    {
        var attempt = CreateQueued();
        attempt.Start();
        Assert.Throws<ArgumentNullException>(() =>
            attempt.Complete(new Usage(0, 0), null!, true, true, true));
    }

    [Fact]
    public void Fail_transitions_from_Running_to_Failed()
    {
        var attempt = CreateQueued();
        attempt.Start();
        var result = attempt.Fail();
        Assert.True(result.IsSuccess);
        Assert.Equal(AttemptStatus.Failed, attempt.Status);
    }

    [Fact]
    public void Timeout_transitions_from_Running_to_Timeout()
    {
        var attempt = CreateQueued();
        attempt.Start();
        var result = attempt.Timeout();
        Assert.True(result.IsSuccess);
        Assert.Equal(AttemptStatus.Timeout, attempt.Status);
    }

    [Fact]
    public void Cancel_from_Queued_succeeds()
    {
        var attempt = CreateQueued();
        var result = attempt.Cancel();
        Assert.True(result.IsSuccess);
        Assert.Equal(AttemptStatus.Cancelled, attempt.Status);
    }

    [Fact]
    public void Cancel_from_Completed_fails()
    {
        var attempt = CreateQueued();
        attempt.Start();
        attempt.Complete(new Usage(0, 0), Cost.Zero(), true, true, true);
        var result = attempt.Cancel();
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void IsSuccessful_true_when_completed_and_all_flags_true()
    {
        var attempt = CreateQueued();
        attempt.Start();
        attempt.Complete(new Usage(100, 200), new Cost(0.05m, "USD"), true, true, true);
        Assert.True(attempt.IsSuccessful);
    }

    [Fact]
    public void IsSuccessful_false_when_not_completed()
    {
        var attempt = CreateQueued();
        Assert.False(attempt.IsSuccessful);
    }

    [Fact]
    public void IsSuccessful_false_when_build_fails()
    {
        var attempt = CreateQueued();
        attempt.Start();
        attempt.Complete(new Usage(0, 0), Cost.Zero(), buildSuccess: false, testSuccess: true, reviewApproved: true);
        Assert.False(attempt.IsSuccessful);
    }

    [Fact]
    public void IsSuccessful_false_when_test_fails()
    {
        var attempt = CreateQueued();
        attempt.Start();
        attempt.Complete(new Usage(0, 0), Cost.Zero(), true, false, true);
        Assert.False(attempt.IsSuccessful);
    }

    [Fact]
    public void IsSuccessful_false_when_review_not_approved()
    {
        var attempt = CreateQueued();
        attempt.Start();
        attempt.Complete(new Usage(0, 0), Cost.Zero(), true, true, false);
        Assert.False(attempt.IsSuccessful);
    }
}
