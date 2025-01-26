using Api.MyPetAr.Models.Identity;
using ApiMyPet.Context;
using ApiMyPet.Dto.Auths;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMyPetAR.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController(PetContext context) : ControllerBase
{
    
    [HttpPost(Name = "Auth")]
    public async Task<IActionResult> Auth(AuthDto authDto)
    {
        var account = await context.Identities.FirstOrDefaultAsync(x=> x.Password == authDto.Password && x.Username == authDto.Login);
        if (account is null) return StatusCode(403, "Invalid login or password");

        var session = new Session()
        {
            UserId = account.Id
        };
        
        context.Add(session);
        await context.SaveChangesAsync();
        return StatusCode(200, new SessionResult { SessionId = session.SessionId });
    }
    
    [HttpPost(Name = "Register")]
    public async Task<IActionResult> Register(AuthDto authDto)
    {
        var account = await context.Identities.FirstOrDefaultAsync(x=> x.Password == authDto.Password && x.Username == authDto.Login);
        if (account is not null) return StatusCode(403, "This account already exists");

        var identity = new Identity()
        {
            Username = authDto.Login,
            Password = authDto.Password,
        };
        context.Add(identity);
        await context.SaveChangesAsync();
        return StatusCode(200, "Success");
    }
}