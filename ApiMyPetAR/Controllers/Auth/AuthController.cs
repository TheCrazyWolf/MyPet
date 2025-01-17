using Microsoft.AspNetCore.Mvc;

namespace ApiMyPetAR.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    
    [HttpPost(Name = "Auth")]
    public IActionResult Auth([FromHeader] string sessionId)
    {
        return StatusCode(200);
    }
    
    [HttpPost(Name = "Register")]
    public IActionResult Register([FromHeader] string sessionId)
    {
        return StatusCode(200);
    }
}