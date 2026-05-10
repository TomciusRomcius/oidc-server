using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OidcServer.Admin.AdminLogin;
using OidcServer.Configurations;
using OidcServer.Utils;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace OidcServer.Admin.Login;

public sealed class LoginService : ILoginService
{
    private readonly AdminCredentialsConfiguration _adminCredentials;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly SigningCredentials _signingCredentials;

    public LoginService(IOptions<AdminCredentialsConfiguration> adminCredentials, 
        IOptions<JwtConfiguration> jwtConfiguration)
    {
        _adminCredentials = adminCredentials.Value;
        _jwtConfiguration = jwtConfiguration.Value;
        
        SymmetricSecurityKey key = new(
            Encoding.UTF8.GetBytes(_jwtConfiguration.SigningKey)
        );
        _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }
    
    public Result<List<Claim>> Login(LoginRequest request)
    {
        if (request.Username != _adminCredentials.Username || request.Password != _adminCredentials.Password)
        {
            return new Result<List<Claim>>(
                new ResultError(ResultErrorType.Validation, "Username or password is incorrect")
            );
        }
        // Successful login
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.UniqueName, "Username"),
            new(ClaimTypes.Role, RoleTypes.Admin)
        ];

        return new Result<List<Claim>>(claims);
    }
}
