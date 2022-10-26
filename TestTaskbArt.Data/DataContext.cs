using Microsoft.EntityFrameworkCore;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Entities;

namespace TestTaskbArt.Data;

 public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }