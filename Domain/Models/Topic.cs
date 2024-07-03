using Domain.Models.Base;

namespace Domain.Models;

public class Topic : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    //Relation
    public ICollection<RoundTopic> RoundTopic { get; set; }
}