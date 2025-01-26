using Api.MyPetAr.Models.Identity;
using ApiMyPet.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMyPetAR.Controllers.Common;

public class ControllerWithValidate(PetContext context) : ControllerBase
{
    [NonAction]
    protected async Task<Identity?> GetIdentityAsync(string sessionId)
    {
        return (await context.Sessions
            .Include(x => x.Identity)
            .FirstOrDefaultAsync(x => x.SessionId == sessionId))?.Identity;
    }
}