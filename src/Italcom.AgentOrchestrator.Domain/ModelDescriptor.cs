namespace Italcom.AgentOrchestrator.Domain
{
    public sealed record ModelDescriptor(
        Guid Id,
        ProviderType Provider,
        string ModelId,
        decimal PricePerToken,
        string Currency,
        int ContextWindow,
        bool SupportsTools,
        bool SupportsStructuredOutput,
        bool SupportsReasoning,
        ModelAvailability Availability,
        ModelTier Tier)
    {
        public bool IsUsable =>
            Availability == ModelAvailability.Available;
    }
}
