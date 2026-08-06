namespace Italcom.AgentOrchestrator.Domain;

public sealed record DomainError(string Message, DomainErrorCode Code);

public enum DomainErrorCode
{
    InvalidTransition,
    InvalidState,
    ValidationError,
    NotFound,
    Conflict,
    BudgetExceeded,
    Unauthorized,
    Timeout,
    Deprecated
}

public sealed record DomainResult<T>
{
    private readonly T? _value;
    private readonly DomainError? _error;

    private DomainResult(T value)
    {
        _value = value;
        _error = null;
    }

    private DomainResult(DomainError error)
    {
        _value = default;
        _error = error;
    }

    public bool IsSuccess => _error is null;
    public bool IsFailure => _error is not null;

    public T Value =>
        IsSuccess && _value is not null
            ? _value
            : throw new InvalidOperationException(
                $"Cannot access value of a failed result: {_error?.Message}");

    public DomainError Error =>
        IsFailure && _error is not null
            ? _error
            : throw new InvalidOperationException("Cannot access error of a successful result");

    public static DomainResult<T> Success(T value) => new(value);
    public static DomainResult<T> Failure(string message, DomainErrorCode code) =>
        new(new DomainError(message, code));
}
