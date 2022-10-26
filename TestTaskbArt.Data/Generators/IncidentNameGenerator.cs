using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace TestTaskbArt.Data.Generators;

public class IncidentNameGenerator : ValueGenerator<string>
{
    public override string Next(EntityEntry entry) => "Incident_" + Guid.NewGuid();
    
    public override bool GeneratesTemporaryValues => false;
}