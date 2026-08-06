using Italcom.AgentOrchestrator.Domain;

namespace Italcom.AgentOrchestrator.UnitTests.Domain;

public sealed class ArtifactTests
{
    [Fact]
    public void IsDiff_true_for_git_diff_content_type()
    {
        var artifact = new Artifact(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "changes.diff", "application/vnd.git.diff", 1024, DateTime.UtcNow);
        Assert.True(artifact.IsDiff);
    }

    [Fact]
    public void IsDiff_false_for_other_content_types()
    {
        var artifact = new Artifact(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "output.txt", "text/plain", 512, DateTime.UtcNow);
        Assert.False(artifact.IsDiff);
    }

    [Fact]
    public void IsLog_true_for_log_content_type()
    {
        var artifact = new Artifact(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "build.log", "text/log", 256, DateTime.UtcNow);
        Assert.True(artifact.IsLog);
    }

    [Fact]
    public void IsLog_true_for_application_log()
    {
        var artifact = new Artifact(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "output", "application/x-log", 128, DateTime.UtcNow);
        Assert.True(artifact.IsLog);
    }

    [Fact]
    public void IsLog_false_for_plain_text()
    {
        var artifact = new Artifact(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "readme.txt", "text/plain", 64, DateTime.UtcNow);
        Assert.False(artifact.IsLog);
    }
}
