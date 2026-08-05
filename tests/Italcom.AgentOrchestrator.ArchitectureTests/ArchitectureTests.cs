using System.Linq;
using System.Reflection;

namespace Italcom.AgentOrchestrator.ArchitectureTests;

public sealed class ArchitectureTests
{
    private static readonly Assembly _domainAssembly = typeof(Italcom.AgentOrchestrator.Domain.AssemblyMarker).Assembly;
    private static readonly Assembly _applicationAssembly = typeof(Italcom.AgentOrchestrator.Application.AssemblyMarker).Assembly;
    private static readonly Assembly _infrastructureAssembly = typeof(Italcom.AgentOrchestrator.Infrastructure.AssemblyMarker).Assembly;
    private static readonly Assembly _agentRuntimeAssembly = typeof(Italcom.AgentOrchestrator.AgentRuntime.AssemblyMarker).Assembly;
    private static readonly Assembly _apiAssembly = typeof(Italcom.AgentOrchestrator.Api.AssemblyMarker).Assembly;
    private static readonly Assembly _cliAssembly = typeof(Italcom.AgentOrchestrator.Cli.AssemblyMarker).Assembly;

    private static IEnumerable<string> GetReferencedAssemblyNames(Assembly asm)
    {
        return asm.GetReferencedAssemblies()
            .Select(r => r.Name)
            .Where(name => name?.StartsWith("Italcom.AgentOrchestrator") == true)
            .Cast<string>();
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_Application()
    {
        var refs = GetReferencedAssemblyNames(_domainAssembly);
        Assert.DoesNotContain(refs, r => r.Contains("Application"));
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_Infrastructure()
    {
        var refs = GetReferencedAssemblyNames(_domainAssembly);
        Assert.DoesNotContain(refs, r => r.Contains("Infrastructure"));
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        var refs = GetReferencedAssemblyNames(_applicationAssembly);
        Assert.DoesNotContain(refs, r => r.Contains("Infrastructure"));
    }

    [Fact]
    public void Application_Should_Depend_On_Domain()
    {
        var refs = GetReferencedAssemblyNames(_applicationAssembly);
        Assert.Contains(refs, r => r.Contains("Domain"));
    }

    [Fact]
    public void Api_Should_Not_Depend_On_Domain_Directly()
    {
        var refs = GetReferencedAssemblyNames(_apiAssembly);
        Assert.DoesNotContain(refs, r => r.Contains("Domain"));
    }

    [Fact]
    public void Cli_Should_Not_Depend_On_Domain_Directly()
    {
        var refs = GetReferencedAssemblyNames(_cliAssembly);
        Assert.DoesNotContain(refs, r => r.Contains("Domain"));
    }
}
