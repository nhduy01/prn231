using Domain.Models.Base;

namespace Domain.Models;

public class Schedule : BaseModel
{
    public string? Description { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? RoundId { get; set; }
    public Guid? ExaminerId { get; set; }


    //Relation
    public Round Round { get; set; }
    public Account Account { get; set; }
    public ICollection<AwardSchedule> AwardSchedule { get; set; }
    public ICollection<Painting> Painting { get; set; }
}