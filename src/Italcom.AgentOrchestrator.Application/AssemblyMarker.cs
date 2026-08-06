namespace Italcom.AgentOrchestrator.Application
{
    public sealed class AssemblyMarker
    {
        // Mantiene il riferimento a Domain assembly affinché il linker non lo elida
        internal static readonly Type DomainMarker = typeof(Italcom.AgentOrchestrator.Domain.AssemblyMarker);
    }
}
