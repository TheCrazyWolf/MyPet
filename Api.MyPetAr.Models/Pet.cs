using System.ComponentModel.DataAnnotations;

namespace Api.MyPetAr.Models;

public class Pet
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; } = 0;
}