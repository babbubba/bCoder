namespace Italcom.AgentOrchestrator.Infrastructure.Configuration
{
    public static class SecretRedactor
    {
        private static readonly string[] SensitiveKeys =
        [
            "apikey", "key", "password", "secret", "token", "connectionstring",
            "api_key", "api-key", "pwd", "credential"
        ];

        /// <summary>
        /// Redacts sensitive values from a configuration section for logging purposes.
        /// </summary>
        public static string Redact(string sectionName, string key, string? value)
        {
            _ = sectionName;

            if (string.IsNullOrEmpty(value))
                return value ?? string.Empty;

            foreach (var sensitive in SensitiveKeys)
            {
                if (IsSensitiveWordMatch(key, sensitive))
                {
                    return value.Length <= 4 ? "***" : value[..4] + "***";
                }
            }

            return value;
        }

        private static bool IsSensitiveWordMatch(string key, string sensitive)
        {
            var index = 0;
            while ((index = key.IndexOf(sensitive, index, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                var endIndex = index + sensitive.Length;

                var beforeOk = index == 0
                    || IsSeparator(key[index - 1])
                    || (char.IsUpper(key[index - 1]) && char.IsLower(key[index]));

                var afterOk = endIndex >= key.Length
                    || IsSeparator(key[endIndex])
                    || char.IsUpper(key[endIndex]);

                if (beforeOk && afterOk)
                    return true;

                index = endIndex;
            }

            return false;
        }

        private static bool IsSeparator(char c) =>
            c is '_' or '-' or '.';
    }
}
