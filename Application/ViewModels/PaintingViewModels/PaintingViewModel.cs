namespace Application.ViewModels.PaintingViewModels;

public class PaintingViewModel
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime SubmitTime { get; set; }
    public Guid? RoundId { get; set; }
    public Guid? ScheduleId { get; set; }
    public string Status { get; set; }
    public string Code { get; set; }
}