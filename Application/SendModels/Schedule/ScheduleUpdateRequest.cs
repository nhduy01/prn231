namespace Application.SendModels.Schedule;

public class ScheduleUpdateRequest
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime EndDate { get; set; }
    public Guid CurrentUserId { get; set; }
}