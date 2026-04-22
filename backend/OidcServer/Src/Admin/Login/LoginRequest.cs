using System.ComponentModel.DataAnnotations;

namespace OidcServer.Admin.AdminLogin;

public class LoginRequest
{
    [Required]
    [MinLength(8)]
    public required string Username { get; set; }
    [Required]
    [MinLength(8)]
    public required string Password { get; set; }
}
