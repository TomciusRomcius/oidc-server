using System.ComponentModel.DataAnnotations;
using OidcServer.Domain.Client;

namespace OidcServer.Client.Dtos;

public class CreateClientRequest
{
    [Required]
    public required string ClientId { get; set; }
    [Required]
    public required OidcFlowType OidcFlowType { get; set; }
}
