namespace Application.ViewModels.AwardViewModels;

public class UpdateAwardViewModel
{
    public Guid Id { get; set; }
    public string Rank { get; set; }
    public int Quantity { get; set; }
    public double Cash { get; set; }
    public string Artifact { get; set; }
    public string Description { get; set; }
    public Guid? EducationalLevelId { get; set; }
    public Guid CurrentUserId { get; set; }
}