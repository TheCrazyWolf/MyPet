using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArPet.Models;

public class Pet
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; } = 0;
    public int? OwnerId { get; set; }
    [ForeignKey("OwnerId")] public Identity.Identity? Owner { get; set; }
}