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
}
