using System.ComponentModel.DataAnnotations;

namespace Italcom.AgentOrchestrator.Infrastructure.Configuration
{
    public sealed class Ds4Options
    {
        public const string SectionName = "DS4";

        [Required(AllowEmptyStrings = false)]
        [Url]
        public string BaseUrl { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; } = string.Empty;
    }
}
