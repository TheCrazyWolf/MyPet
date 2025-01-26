using Api.MyPetAr.Models;
using Api.MyPetAr.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiMyPet.Context;

public class PetContext : DbContext
{
    public DbSet<Identity> Identities { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Session> Sessions { get; set; }>
}