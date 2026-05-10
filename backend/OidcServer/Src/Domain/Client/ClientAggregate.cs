namespace OidcServer.Domain.Client;

public enum OidcFlowType
{
    ImplicitFlow = 0,
    AuthorizationFlow = 1
}

public class ClientAggregate
{
    public required string ClientId { get; set; }
    public required OidcFlowType OidcFlowType { get; set; }
}
