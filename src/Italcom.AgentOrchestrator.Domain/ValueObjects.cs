namespace Italcom.AgentOrchestrator.Domain
{
    public sealed record Budget(decimal Amount, string Currency)
    {
        public bool IsExceededBy(Cost cost) =>
            Amount > 0 && cost.Amount > Amount;
    }

    public sealed record Cost(decimal Amount, string Currency)
    {
        public static Cost Zero(string currency = "USD") => new(0, currency);

        public Cost Add(Cost other) =>
            Currency == other.Currency
                ? new Cost(Amount + other.Amount, Currency)
                : throw new InvalidOperationException(
                    $"Cannot add costs with different currencies: {Currency} vs {other.Currency}");
    }

    public sealed record Usage(int PromptTokens, int CompletionTokens)
    {
        public int TotalTokens => PromptTokens + CompletionTokens;
    }
}
