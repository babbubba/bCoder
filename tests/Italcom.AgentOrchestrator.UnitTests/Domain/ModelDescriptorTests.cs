using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class ModelDescriptorTests
{
    private static readonly Guid Id = Guid.NewGuid();

    [Fact]
    public void IsUsable_true_when_available()
    {
        var model = new ModelDescriptor(Id, ProviderType.DS4, "deepseek-coder-v2",
            0.0001m, "USD", 128000, true, true, true,
            ModelAvailability.Available, ModelTier.Paid);

        Assert.True(model.IsUsable);
    }

    [Fact]
    public void IsUsable_false_when_unavailable()
    {
        var model = new ModelDescriptor(Id, ProviderType.OpenRouter, "gpt-4",
            0.01m, "USD", 128000, true, true, true,
            ModelAvailability.Unavailable, ModelTier.Paid);

        Assert.False(model.IsUsable);
    }

    [Fact]
    public void IsUsable_false_when_deprecated()
    {
        var model = new ModelDescriptor(Id, ProviderType.DS4, "deepseek-v1",
            0.0001m, "USD", 4096, false, false, false,
            ModelAvailability.Deprecated, ModelTier.Free);

        Assert.False(model.IsUsable);
    }

    [Fact]
    public void Record_provides_value_equality()
    {
        var a = new ModelDescriptor(Id, ProviderType.DS4, "m1", 0m, "USD", 4096,
            false, false, false, ModelAvailability.Available, ModelTier.Local);
        var b = new ModelDescriptor(Id, ProviderType.DS4, "m1", 0m, "USD", 4096,
            false, false, false, ModelAvailability.Available, ModelTier.Local);

        Assert.Equal(a, b);
    }
}
