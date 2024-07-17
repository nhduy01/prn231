using Application.ViewModels.PaintingViewModels;

namespace Application.ViewModels.ScheduleViewModels;

public class AwardScheduleModels
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public Guid? AwardId { get; set; }
    public Guid? ScheduleId { get; set; }
    public string? Rank { get; set; }
    public string? Status { get; set; }
    public List<PaintingViewModel> PaintingViewModelsList { get; set; }
}