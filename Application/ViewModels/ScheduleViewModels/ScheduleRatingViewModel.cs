namespace Application.ViewModels.ScheduleViewModels;

public class ScheduleRatingViewModel
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public Guid? RoundId { get; set; }
    public Guid? ExaminerId { get; set; }
}