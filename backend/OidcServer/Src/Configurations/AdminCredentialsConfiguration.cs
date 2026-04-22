using System.ComponentModel.DataAnnotations;

namespace OidcServer.Configurations;

public class AdminCredentialsConfiguration
{
    [Required]
    [MinLength(8)]
    public required string Username { get; set; }
    [Required]
    [MinLength(8)]
    public required string Password { get; set; }
}
