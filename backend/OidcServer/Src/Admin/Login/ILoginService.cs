using System.Security.Claims;
using OidcServer.Utils;

namespace OidcServer.Admin.AdminLogin;

public interface ILoginService
{
    Result<List<Claim>> Login(LoginRequest request);
}
