using Microsoft.AspNetCore.Mvc;

namespace ApiMyPetAR.Controllers.Sync;

[ApiController]
[Route("[controller]")]
public class SyncController : ControllerBase
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