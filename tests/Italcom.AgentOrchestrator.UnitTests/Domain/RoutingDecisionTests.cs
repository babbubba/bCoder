using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class RoutingDecisionTests
{
    [Fact]
    public void IsFreeTier_true_when_tier_is_Free()
    {
        var decision = new RoutingDecision(Guid.NewGuid(), Guid.NewGuid(),
            ProviderType.DS4, "free-model", ModelTier.Free, 0m, "USD",
            "free tier", DateTime.UtcNow);

        Assert.True(decision.IsFreeTier);
    }

    [Fact]
    public void IsFreeTier_false_when_tier_is_not_Free()
    {
        var decision = new RoutingDecision(Guid.NewGuid(), Guid.NewGuid(),
            ProviderType.DS4, "paid-model", ModelTier.Paid, 0.01m, "USD",
            "paid tier", DateTime.UtcNow);

        Assert.False(decision.IsFreeTier);
    }

    [Fact]
    public void IsLocalTier_true_when_tier_is_Local()
    {
        var decision = new RoutingDecision(Guid.NewGuid(), Guid.NewGuid(),
            ProviderType.DS4, "local-model", ModelTier.Local, 0m, "USD",
            "local tier", DateTime.UtcNow);

        Assert.True(decision.IsLocalTier);
    }

    [Fact]
    public void IsLocalTier_false_when_tier_is_not_Local()
    {
        var decision = new RoutingDecision(Guid.NewGuid(), Guid.NewGuid(),
            ProviderType.OpenRouter, "frontier-model", ModelTier.Frontier, 0.1m, "USD",
            "frontier tier", DateTime.UtcNow);

        Assert.False(decision.IsLocalTier);
    }
}
