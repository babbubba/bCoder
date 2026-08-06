using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class DomainResultTests
{
    [Fact]
    public void Success_result_IsSuccess_is_true()
    {
        var result = DomainResult<int>.Success(42);
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void Success_result_returns_value()
    {
        var result = DomainResult<int>.Success(42);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Failure_result_IsFailure_is_true()
    {
        var result = DomainResult<int>.Failure("error", DomainErrorCode.InvalidTransition);
        Assert.True(result.IsFailure);
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Failure_result_returns_error()
    {
        var result = DomainResult<int>.Failure("error", DomainErrorCode.InvalidTransition);
        Assert.Equal("error", result.Error.Message);
        Assert.Equal(DomainErrorCode.InvalidTransition, result.Error.Code);
    }

    [Fact]
    public void Accessing_value_on_failure_throws()
    {
        var result = DomainResult<int>.Failure("error", DomainErrorCode.InvalidTransition);
        Assert.Throws<InvalidOperationException>(() => result.Value);
    }

    [Fact]
    public void Accessing_error_on_success_throws()
    {
        var result = DomainResult<int>.Success(42);
        Assert.Throws<InvalidOperationException>(() => result.Error);
    }

    [Fact]
    public void Failure_with_different_error_codes()
    {
        var codes = new[]
        {
            DomainErrorCode.InvalidTransition,
            DomainErrorCode.InvalidState,
            DomainErrorCode.ValidationError,
            DomainErrorCode.NotFound,
            DomainErrorCode.Conflict,
            DomainErrorCode.BudgetExceeded,
            DomainErrorCode.Unauthorized,
            DomainErrorCode.Timeout,
            DomainErrorCode.Deprecated,
        };

        foreach (var code in codes)
        {
            var result = DomainResult<string>.Failure($"code={code}", code);
            Assert.True(result.IsFailure);
            Assert.Equal(code, result.Error.Code);
        }
    }
}
