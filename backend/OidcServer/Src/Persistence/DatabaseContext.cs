using Microsoft.EntityFrameworkCore;
using OidcServer.Domain.Client;
using OidcServer.Persistence.Configurations;

namespace OidcServer.Persistence;

public class DatabaseContext : DbContext
{  
    public DbSet<ClientAggregate> Clients { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
