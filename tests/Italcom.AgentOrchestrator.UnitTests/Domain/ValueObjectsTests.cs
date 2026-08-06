using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class ValueObjectsTests
{
    [Fact]
    public void Budget_IsExceededBy_when_cost_exceeds_budget_returns_true()
    {
        var budget = new Budget(100, "USD");
        var cost = new Cost(150, "USD");
        Assert.True(budget.IsExceededBy(cost));
    }

    [Fact]
    public void Budget_IsExceededBy_when_cost_is_within_budget_returns_false()
    {
        var budget = new Budget(100, "USD");
        var cost = new Cost(80, "USD");
        Assert.False(budget.IsExceededBy(cost));
    }

    [Fact]
    public void Budget_IsExceededBy_with_zero_budget_returns_false()
    {
        var budget = new Budget(0, "USD");
        var cost = new Cost(150, "USD");
        Assert.False(budget.IsExceededBy(cost));
    }

    [Fact]
    public void Cost_Add_with_same_currency_sums_amounts()
    {
        var a = new Cost(10, "USD");
        var b = new Cost(20, "USD");
        var result = a.Add(b);
        Assert.Equal(30, result.Amount);
        Assert.Equal("USD", result.Currency);
    }

    [Fact]
    public void Cost_Add_with_different_currencies_throws()
    {
        var a = new Cost(10, "USD");
        var b = new Cost(20, "EUR");
        Assert.Throws<InvalidOperationException>(() => a.Add(b));
    }

    [Fact]
    public void Cost_Zero_returns_zero_cost()
    {
        var zero = Cost.Zero("EUR");
        Assert.Equal(0, zero.Amount);
        Assert.Equal("EUR", zero.Currency);
    }

    [Fact]
    public void Cost_Zero_defaults_to_USD()
    {
        var zero = Cost.Zero();
        Assert.Equal("USD", zero.Currency);
    }

    [Fact]
    public void Usage_TotalTokens_sums_prompt_and_completion()
    {
        var usage = new Usage(100, 200);
        Assert.Equal(300, usage.TotalTokens);
    }
}
