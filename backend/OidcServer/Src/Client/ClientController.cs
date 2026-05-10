using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OidcServer.Client.Dtos;
using OidcServer.Domain.Client;
using OidcServer.Utils;

namespace OidcServer.Client;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = RoleTypes.Admin)]
public class ClientController(IClientService clientService) : ControllerBase
{
    /// <summary>
    /// Retrieves all registered OIDC clients.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(DataResponse<IEnumerable<ClientAggregate>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientsAsync()
    {
        IEnumerable<ClientAggregate> result = await clientService.GetClientsAsync();
        return Ok(new DataResponse<IEnumerable<ClientAggregate>>(result));
    }

    /// <summary>
    /// Register a new OIDC client.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientRequest request)
    {
        var error = await clientService.CreateClientAsync(request);
        return error != null
            ? ControllerUtils.ResultErrorToResponse(error)
            : NoContent();
    }
}
