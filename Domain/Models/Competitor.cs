using Domain.Models.Base;

namespace Domain.Models;

public class Competitor : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? Avatar { get; set; }
    public bool Gender { get; set; } = true;
    public Guid? GuardianId { get; set; }

    public string? RefreshToken { get; set; }

    //Relation


    public ICollection<Collection> Collection { get; set; }
    public Account Account { get; set; }
    public ICollection<Painting> Painting { get; set; }
}