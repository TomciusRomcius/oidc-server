using OidcServer.Client.Dtos;
using OidcServer.Domain.Client;
using OidcServer.Utils;

namespace OidcServer.Client;

public interface IClientService
{
    Task<IEnumerable<ClientAggregate>> GetClientsAsync();
    Task<ResultError?> CreateClientAsync(CreateClientRequest request);
}
