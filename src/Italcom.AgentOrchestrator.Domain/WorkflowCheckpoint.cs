namespace Italcom.AgentOrchestrator.Domain
{
    public sealed record WorkflowCheckpoint(
        Guid Id,
        Guid WorkflowId,
        string SerializedState,
        string StateType,
        DateTime CreatedAt)
    {
        public WorkflowCheckpoint WithNewState(string serializedState, string stateType) =>
            this with
            {
                SerializedState = serializedState,
                StateType = stateType,
                CreatedAt = DateTime.UtcNow
            };
    }
}
