using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.MyPetAr.Models.Identity;

public class Session
{
    [Key] public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public DateTime DateTime { get; set; } = DateTime.Now;
    public Identity? Identity { get; set; }
    [ForeignKey("Identity")] public int? UserId { get; set; }
}