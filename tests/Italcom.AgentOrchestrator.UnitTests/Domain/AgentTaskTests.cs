using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class AgentTaskTests
{
    private static Guid WorkRequestId => Guid.Parse("11111111-1111-1111-1111-111111111111");

    private static AgentTask CreateNotStarted() => new(
        Guid.NewGuid(), WorkRequestId, "test task", Array.Empty<Guid>(),
        acceptanceCriteria: "must pass", contextHint: 100, riskLabel: "high");

    [Fact]
    public void Constructor_sets_initial_status()
    {
        var task = CreateNotStarted();
        Assert.Equal(TaskStatus.NotStarted, task.Status);
    }

    [Fact]
    public void Constructor_throws_on_null_description()
    {
        Assert.Throws<ArgumentNullException>(() => new AgentTask(
            Guid.NewGuid(), WorkRequestId, null!, Array.Empty<Guid>()));
    }

    [Fact]
    public void Constructor_throws_on_null_dependencyIds()
    {
        Assert.Throws<ArgumentNullException>(() => new AgentTask(
            Guid.NewGuid(), WorkRequestId, "task", null!));
    }

    [Fact]
    public void Constructor_stores_optional_parameters()
    {
        var task = CreateNotStarted();
        Assert.Equal("must pass", task.AcceptanceCriteria);
        Assert.Equal(100, task.ContextHint);
        Assert.Equal("high", task.RiskLabel);
    }

    [Fact]
    public void DependencyIds_is_immutable()
    {
        var deps = new[] { Guid.NewGuid(), Guid.NewGuid() };
        var task = new AgentTask(Guid.NewGuid(), WorkRequestId, "task", deps);
        Assert.Equal(2, task.DependencyIds.Count);
        Assert.Equal(deps[0], task.DependencyIds[0]);
    }

    [Fact]
    public void Start_transitions_from_NotStarted_to_InProgress()
    {
        var task = CreateNotStarted();
        var result = task.Start();
        Assert.True(result.IsSuccess);
        Assert.Equal(TaskStatus.InProgress, task.Status);
    }

    [Fact]
    public void Start_from_non_not_started_fails()
    {
        var task = CreateNotStarted();
        task.Start();
        var result = task.Start();
        Assert.True(result.IsFailure);
        Assert.Equal(DomainErrorCode.InvalidTransition, result.Error.Code);
    }

    [Fact]
    public void Complete_transitions_from_InProgress_to_Completed()
    {
        var task = CreateNotStarted();
        task.Start();
        var result = task.Complete();
        Assert.True(result.IsSuccess);
        Assert.Equal(TaskStatus.Completed, task.Status);
    }

    [Fact]
    public void Complete_from_non_in_progress_fails()
    {
        var task = CreateNotStarted();
        var result = task.Complete();
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Fail_transitions_from_InProgress_to_Failed()
    {
        var task = CreateNotStarted();
        task.Start();
        var result = task.Fail();
        Assert.True(result.IsSuccess);
        Assert.Equal(TaskStatus.Failed, task.Status);
    }

    [Fact]
    public void Skip_transitions_from_NotStarted_to_Skipped()
    {
        var task = CreateNotStarted();
        var result = task.Skip();
        Assert.True(result.IsSuccess);
        Assert.Equal(TaskStatus.Skipped, task.Status);
    }

    [Fact]
    public void Skip_from_non_not_started_fails()
    {
        var task = CreateNotStarted();
        task.Start();
        var result = task.Skip();
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Escalate_transitions_from_InProgress_to_Escalated()
    {
        var task = CreateNotStarted();
        task.Start();
        var result = task.Escalate();
        Assert.True(result.IsSuccess);
        Assert.Equal(TaskStatus.Escalated, task.Status);
    }

    [Fact]
    public void Escalate_from_non_in_progress_fails()
    {
        var task = CreateNotStarted();
        var result = task.Escalate();
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Full_lifecycle_success()
    {
        var task = CreateNotStarted();
        Assert.True(task.Start().IsSuccess);
        Assert.True(task.Complete().IsSuccess);
        Assert.Equal(TaskStatus.Completed, task.Status);
    }
}
