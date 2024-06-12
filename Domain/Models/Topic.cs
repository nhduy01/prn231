using Domain.Models.Base;

namespace Domain.Models;

public class Topic : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Guid? RoundId { get; set; }


    //Relation
    public Round Round { get; set; }
}