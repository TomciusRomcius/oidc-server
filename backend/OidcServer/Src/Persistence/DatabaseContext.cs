using Microsoft.EntityFrameworkCore;

namespace OidcServer.Persistence;

public class DatabaseContext : DbContext
{  
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }
}
