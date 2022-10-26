using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Configurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(x => x.Name);
        builder.HasOne(x => x.Incident).WithMany().HasForeignKey(x => x.IncidentName).IsRequired(false);
        builder.HasMany(x => x.Contacts).WithOne().HasForeignKey(x => x.AccountName).IsRequired(false);
    }
}