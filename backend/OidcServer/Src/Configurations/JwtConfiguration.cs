using System.ComponentModel.DataAnnotations;

namespace OidcServer.Configurations;

public class JwtConfiguration
{
    [Required]
    public required string Issuer { get; init; }
    [Required]
    public required string Audience { get; init; }
    [Required]
    public required string SigningKey { get; init; }
    [Required]
    public required int ExpirationMinutes { get; init; }
}
