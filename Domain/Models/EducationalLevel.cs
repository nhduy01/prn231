using Domain.Models.Base;

namespace Domain.Models;

public class EducationalLevel : BaseModel
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public string Level { get; set; }
    public Guid? ContestId { get; set; }

    //Relation
    public ICollection<Award> Award { get; set; }
    public Contest Contest { get; set; }
    public ICollection<Round> Round { get; set; }
}