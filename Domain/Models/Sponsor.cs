using Domain.Models.Base;

namespace Domain.Models;

public class Sponsor : BaseModel
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Delegate { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Logo { get; set; }

    //Relation
    public ICollection<Resources> Resources { get; set; }
}