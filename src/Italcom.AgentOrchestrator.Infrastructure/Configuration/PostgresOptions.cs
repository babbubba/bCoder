using System.ComponentModel.DataAnnotations;

namespace Italcom.AgentOrchestrator.Infrastructure.Configuration;

public sealed class PostgresOptions
{
    public const string SectionName = "Postgres";

    [Required(AllowEmptyStrings = false)]
    public string ConnectionString { get; set; } = string.Empty;
}
