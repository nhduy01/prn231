namespace Application.ViewModels.PaintingViewModels;

public class AddPaintingViewModel
{
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? AwardId { get; set; }
    public Guid? RoundId { get; set; }
    public Guid? TopicId { get; set; }
    public string Code { get; set; }
}