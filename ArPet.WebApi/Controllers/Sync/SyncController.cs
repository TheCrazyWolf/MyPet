using ArPet.Dto.Pets;
using ArPet.Models;
using ArPet.Storage;
using ArPet.WebApi.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArPet.WebApi.Controllers.Sync;

[ApiController]
[Route("[controller]")]
public class SyncController(PetContext context) : ControllerWithValidate(context: context)
{
    private readonly PetContext _context = context;

    [HttpGet("GetPets")]
    public async Task<IEnumerable<PetDto>> GetPets([FromHeader] string sessionId)
    {
        var currentAccount = await GetIdentityAsync(sessionId);
        if (currentAccount is null) return [];
        var petsByAcocunt = (await _context.Pets.Where(x => x.OwnerId == currentAccount.Id).ToListAsync())
            .Select(x=> new PetDto()
            {
                Id = x.Id,
                Name = x.Name,
                Level = x.Level,
            });
        return petsByAcocunt;
    }
    
    [HttpPost("SyncPets")]
    public async Task<IActionResult> Sync([FromHeader] string sessionId, IList<PetDto> pets)
    {
        var currentAccount = await GetIdentityAsync(sessionId);
        if (currentAccount is null) return StatusCode(403, "Not authorized");
        
        foreach (var item in pets)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (item.Id is 0 || pet is null)
            {
                pet = new Pet
                {
                    OwnerId = currentAccount.Id,
                    Name = item.Name,
                    Level = item.Level
                };
                _context.Add(pet);
            }
            if (pet.OwnerId != currentAccount.Id) continue;
            pet.Name = item.Name;
            pet.Level = item.Level;
        }
        
        await _context.SaveChangesAsync();
        return StatusCode(200, await GetPets(sessionId));
    }
}