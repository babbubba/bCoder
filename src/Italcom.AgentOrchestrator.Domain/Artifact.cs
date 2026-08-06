namespace Italcom.AgentOrchestrator.Domain;

public sealed record Artifact(
    Guid Id,
    Guid TaskId,
    Guid TaskAttemptId,
    string Name,
    string ContentType,
    long SizeBytes,
    DateTime CreatedAt)
{
    public bool IsDiff => ContentType.Equals("application/vnd.git.diff", StringComparison.OrdinalIgnoreCase);
    public bool IsLog => ContentType.Contains("log", StringComparison.OrdinalIgnoreCase);
}
