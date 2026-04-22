using OidcServer.Utils;

namespace OidcServer.Admin.AdminLogin;

public interface ILoginService
{
    Result<string> Login(LoginRequest request);
}
