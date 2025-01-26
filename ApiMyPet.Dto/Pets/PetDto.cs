namespace ApiMyPet.Dto.Pets;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; } = 0;
}