using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskbArt.Data.Entities;
using TestTaskbArt.Data.Generators;

namespace TestTaskbArt.Data.Configurations;

internal class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.ToTable("Incidents");
        builder.HasKey(x => x.Name);
        builder.Property(x => x.Name).ValueGeneratedOnAdd().HasValueGenerator<IncidentNameGenerator>();;
    }
}