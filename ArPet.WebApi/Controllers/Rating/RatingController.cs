using ArPet.Dto.Rating;
using ArPet.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArPet.WebApi.Controllers.Rating;

[ApiController]
[Route("[controller]")]
public class RatingController(PetContext context) : ControllerBase
{
    
    [HttpPost("GetRating")]
    [EndpointSummary("Рейтинг аккаунтов")]
    [EndpointDescription("Возращается массив с данными UserName и суммарное кол-во уровня аккаунтов")]
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