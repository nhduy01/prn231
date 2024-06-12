using Domain.Models.Base;

namespace Domain.Models;

public class AwardSchedule : BaseModel
{
    public int Quantity { get; set; }
    public Guid? AwardId { get; set; }

    public Guid? ScheduleId { get; set; }

    //Relation
    public Award Award { get; set; }
    public Schedule Schedule { get; set; }
}