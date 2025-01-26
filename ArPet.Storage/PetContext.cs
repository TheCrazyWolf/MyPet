using ArPet.Models;
using ArPet.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArPet.Storage;

public class PetContext : DbContext
{
    public DbSet<Identity> Identities { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Session> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
        base.OnConfiguring(optionsBuilder);
    }
}