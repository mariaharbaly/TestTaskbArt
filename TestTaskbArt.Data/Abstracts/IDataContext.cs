using Microsoft.EntityFrameworkCore;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data.Abstracts;

public interface IDataContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}