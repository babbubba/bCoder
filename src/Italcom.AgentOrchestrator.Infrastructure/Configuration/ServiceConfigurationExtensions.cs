using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Italcom.AgentOrchestrator.Infrastructure.Configuration;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddInfrastructureConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<Ds4Options>()
            .Bind(configuration.GetSection(Ds4Options.SectionName))
            .ValidateDataAnnotations();

        services.AddOptions<OpenRouterOptions>()
            .Bind(configuration.GetSection(OpenRouterOptions.SectionName))
            .ValidateDataAnnotations();

        services.AddOptions<PostgresOptions>()
            .Bind(configuration.GetSection(PostgresOptions.SectionName))
            .ValidateDataAnnotations();

        return services;
    }
}
