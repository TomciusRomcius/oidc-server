using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OidcServer.Admin.AdminLogin;
using OidcServer.Utils;

namespace OidcServer.Admin.Login;

[ApiController]
[Route("api/admin/[controller]")] 
public class LoginController(ILoginService loginService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        Result<List<Claim>> result = loginService.Login(request);
        
        if (!result.Ok())
        {
            // TODO: controller utils
            return BadRequest(result.GetError());
        }

        List<Claim> claims = result.GetValue();
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        return NoContent();
    }
}
