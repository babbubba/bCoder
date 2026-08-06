using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class WorkflowCheckpointTests
{
    [Fact]
    public void WithNewState_returns_new_instance_with_updated_values()
    {
        var original = new WorkflowCheckpoint(
            Guid.NewGuid(), Guid.NewGuid(),
            "{\"step\":1}", "InitialState", DateTime.UtcNow);

        var updated = original.WithNewState("{\"step\":2}", "ProcessingState");

        Assert.NotEqual(original, updated);
        Assert.Equal("{\"step\":2}", updated.SerializedState);
        Assert.Equal("ProcessingState", updated.StateType);
        Assert.True(updated.CreatedAt >= original.CreatedAt);
    }

    [Fact]
    public void WithNewState_preserves_ids()
    {
        var id = Guid.NewGuid();
        var workflowId = Guid.NewGuid();
        var original = new WorkflowCheckpoint(id, workflowId, "s1", "T1", DateTime.UtcNow);
        var updated = original.WithNewState("s2", "T2");

        Assert.Equal(id, updated.Id);
        Assert.Equal(workflowId, updated.WorkflowId);
    }
}
