using Microsoft.EntityFrameworkCore;
using OidcServer.Client.Dtos;
using OidcServer.Domain.Client;
using OidcServer.Persistence;
using OidcServer.Utils;

namespace OidcServer.Client;

public class ClientService(DatabaseContext dbContext) : IClientService
{
    public async Task<IEnumerable<ClientAggregate>> GetClientsAsync()
    {
        return await dbContext.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<ResultError?> CreateClientAsync(CreateClientRequest request)
    {
        bool existingClient = await dbContext.Clients.AnyAsync(c => c.ClientId == request.ClientId);

        if (existingClient)
        {
            return new ResultError(ResultErrorType.InvalidOperation, "Client already exists");
        }
        dbContext.Add(new ClientAggregate
        {
            ClientId = request.ClientId,
            OidcFlowType = request.OidcFlowType,
        });
        await dbContext.SaveChangesAsync();
        return null;
    }

    public async Task<ResultError?> UpdateClientAsync(CreateClientRequest request)
    {
        var existingClient = await dbContext.Clients.SingleOrDefaultAsync(c => c.ClientId == request.ClientId);
        if (existingClient is null)
        {
            return new ResultError(ResultErrorType.InvalidOperation, "Client does not exist");
        }
        else
        {
            existingClient.OidcFlowType = request.OidcFlowType;
        }
        await dbContext.SaveChangesAsync();
        return null;
    }

    public async Task<ClientAggregate?> GetClientAsync(string clientId) =>
        await dbContext.Clients
            .Where(c => c.ClientId == clientId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
}
