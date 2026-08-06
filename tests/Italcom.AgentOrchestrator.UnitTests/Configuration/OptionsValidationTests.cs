using System.ComponentModel.DataAnnotations;
using Italcom.AgentOrchestrator.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Italcom.AgentOrchestrator.UnitTests.Configuration;

public sealed class OptionsValidationTests
{
    private sealed class ServiceCollectionSpy : IServiceCollection
    {
        private readonly List<ServiceDescriptor> _descriptors = [];
        public int Count => _descriptors.Count;
        public bool IsReadOnly => false;
        public ServiceDescriptor this[int index]
        {
            get => _descriptors[index];
            set => _descriptors[index] = value;
        }

        public void Add(ServiceDescriptor item) => _descriptors.Add(item);
        public void Clear() => _descriptors.Clear();
        public bool Contains(ServiceDescriptor item) => _descriptors.Contains(item);
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => _descriptors.CopyTo(array, arrayIndex);
        public bool Remove(ServiceDescriptor item) => _descriptors.Remove(item);
        public IEnumerator<ServiceDescriptor> GetEnumerator() => _descriptors.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Fact]
    public void Ds4Options_validation_fails_when_BaseUrl_missing()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["DS4:BaseUrl"] = "",
                ["DS4:Model"] = "test-model"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<Ds4Options>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void Ds4Options_validation_fails_when_Model_missing()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["DS4:BaseUrl"] = "http://valid.url/",
                ["DS4:Model"] = ""
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<Ds4Options>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void Ds4Options_validation_fails_when_BaseUrl_not_valid_url()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["DS4:BaseUrl"] = "not-a-url",
                ["DS4:Model"] = "test-model"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<Ds4Options>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void OpenRouterOptions_validation_fails_when_ApiKey_missing()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["OpenRouter:BaseUrl"] = "http://valid.url/",
                ["OpenRouter:ApiKey"] = ""
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<OpenRouterOptions>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void OpenRouterOptions_validation_fails_when_BaseUrl_invalid()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["OpenRouter:BaseUrl"] = "invalid",
                ["OpenRouter:ApiKey"] = "some-key"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<OpenRouterOptions>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void PostgresOptions_validation_fails_when_ConnectionString_missing()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Postgres:ConnectionString"] = ""
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<PostgresOptions>>();

        var result = ValidateOptions(options);
        Assert.False(result);
    }

    [Fact]
    public void All_options_pass_validation_with_valid_values()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["DS4:BaseUrl"] = "http://192.168.253.18:8000/v1/",
                ["DS4:Model"] = "deepseek-v4-flash",
                ["OpenRouter:BaseUrl"] = "https://openrouter.ai/api/v1/",
                ["OpenRouter:ApiKey"] = "sk-or-v1-secret",
                ["Postgres:ConnectionString"] = "Host=localhost;Port=5432;Database=test;Username=agent;Password=secure"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructureConfiguration(config);

        var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetRequiredService<IOptions<Ds4Options>>());
        Assert.NotNull(provider.GetRequiredService<IOptions<OpenRouterOptions>>());
        Assert.NotNull(provider.GetRequiredService<IOptions<PostgresOptions>>());
    }

    private static bool ValidateOptions<TOptions>(IOptions<TOptions> options) where TOptions : class
    {
        try
        {
            _ = options.Value;
            return true;
        }
        catch (OptionsValidationException)
        {
            return false;
        }
    }
}
