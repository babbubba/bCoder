namespace Italcom.AgentOrchestrator.Infrastructure.Configuration;

public static class SecretRedactor
{
    /// <summary>
    /// Redacts sensitive values from a configuration section for logging purposes.
    /// </summary>
    public static string Redact(string sectionName, string key, string? value)
    {
        if (string.IsNullOrEmpty(value))
            return value ?? string.Empty;

        var sensitiveKeys = new[]
        {
            "apikey", "key", "password", "secret", "token", "connectionstring",
            "api_key", "api-key", "pwd", "credential"
        };

        foreach (var sensitive in sensitiveKeys)
        {
            if (key.Contains(sensitive, StringComparison.OrdinalIgnoreCase))
            {
                return value.Length switch
                {
                    <= 4 => "***",
                    _ => value[..4] + "***"
                };
            }
        }

        return value;
    }
}
