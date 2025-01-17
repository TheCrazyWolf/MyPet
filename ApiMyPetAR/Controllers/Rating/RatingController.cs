using Microsoft.AspNetCore.Mvc;

namespace ApiMyPetAR.Controllers.Rating;

[ApiController]
[Route("[controller]")]
public class RatingController : ControllerBase
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