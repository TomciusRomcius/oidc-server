using Microsoft.AspNetCore.Mvc;
using OidcServer.Admin.AdminLogin;
using OidcServer.Utils;

namespace OidcServer.Admin.Login;

[ApiController]
[Route("api/admin/[controller]")] 
public class LoginController(ILoginService loginService) : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        Result<string> result = loginService.Login(request);

        if (!result.Ok())
        {
            // TODO: controller utils
            return BadRequest(result.GetError());
        }
        
        return Ok(new { Data = result.GetValue() });
    }
}
