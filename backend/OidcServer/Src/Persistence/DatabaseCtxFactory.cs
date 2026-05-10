using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OidcServer.Persistence;

public class DatabaseCtxFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        string? host = args.FirstOrDefault(arg => arg.StartsWith("--host"))?.Split("=")?[1];
        string? database = args.FirstOrDefault(arg => arg.StartsWith("--database"))?.Split("=")?[1];
        string? username = args.FirstOrDefault(arg => arg.StartsWith("--username"))?.Split("=")?[1];
        string? password = args.FirstOrDefault(arg => arg.StartsWith("--password"))?.Split("=")?[1];
        string port = args.FirstOrDefault(arg => arg.StartsWith("--port"))?.Split("=")?[1] ?? "5432";

        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        ArgumentException.ThrowIfNullOrWhiteSpace(database);
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        if (!int.TryParse(port, out int portNum))
        {
            throw new ArgumentException("Port must be an integer!");
        }
        string conString = $@"
            Host={host};Database={database};Username={username};Password={password};Port={portNum}
        ";
        DbContextOptions<DatabaseContext> opts = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(conString)
            .Options;
        return new DatabaseContext(opts);
    }
}
