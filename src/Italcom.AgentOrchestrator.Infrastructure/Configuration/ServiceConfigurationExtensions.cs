using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Italcom.AgentOrchestrator.Infrastructure.Configuration
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddInfrastructureConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            _ = services.AddOptions<Ds4Options>()
                .Bind(configuration.GetSection(Ds4Options.SectionName))
                .ValidateDataAnnotations();

            _ = services.AddOptions<OpenRouterOptions>()
                .Bind(configuration.GetSection(OpenRouterOptions.SectionName))
                .ValidateDataAnnotations();

            _ = services.AddOptions<PostgresOptions>()
                .Bind(configuration.GetSection(PostgresOptions.SectionName))
                .ValidateDataAnnotations();

            return services;
        }
    }
}
