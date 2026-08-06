using System.ComponentModel.DataAnnotations;

namespace Italcom.AgentOrchestrator.Infrastructure.Configuration
{
    public sealed class OpenRouterOptions
    {
        public const string SectionName = "OpenRouter";

        [Required(AllowEmptyStrings = false)]
        [Url]
        public string BaseUrl { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string ApiKey { get; set; } = string.Empty;
    }
}
