namespace Application.SendModels.Schedule;

public class ScheduleRequest
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Guid? RoundId { get; set; }
    public Guid? ExaminerId { get; set; }
}