namespace Application.ViewModels.ScheduleViewModels;

public class ScheduleViewModel
{
    public Guid Id { get; set; }
    public Guid? RoundId { get; set; }
    public String? Round { get; set; }
    public String? Year { get; set; }
    public Guid? ExaminerId { get; set; }
    public String? Status { get; set; }
    public DateTime EndDate { get; set; }
}