using ApiMyPet.Context;
using ApiMyPet.Dto.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMyPetAR.Controllers.Rating;

[ApiController]
[Route("[controller]")]
public class RatingController(PetContext context) : ControllerBase
{
    
    [HttpPost("GetRating")]
    public async Task<IActionResult> GetRating([FromHeader] string sessionId)
    {
        var rating = await context.Pets
            .Include(x => x.Owner) 
            .GroupBy(x => x.OwnerId) 
            .Select(g => new RatingDto()
            {
                UserName = g.First().Owner!.Username ?? "Unknown", 
                Level = g.Sum(x => x.Level)
            })
            .OrderByDescending(x => x.Level) 
            .ToListAsync(); 

        return Ok(rating);
    }
}