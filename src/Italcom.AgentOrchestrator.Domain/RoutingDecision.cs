namespace Italcom.AgentOrchestrator.Domain
{
    public sealed record RoutingDecision(
        Guid Id,
        Guid TaskAttemptId,
        ProviderType SelectedProvider,
        string SelectedModelId,
        ModelTier SelectedTier,
        decimal EstimatedCost,
        string Currency,
        string Reason,
        DateTime CreatedAt)
    {
        public bool IsFreeTier => SelectedTier == ModelTier.Free;
        public bool IsLocalTier => SelectedTier == ModelTier.Local;
    }
}
