namespace Application.ViewModels.AwardViewModels;

public class AwardViewModel
{
    public DateTime CreatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string Rank { get; set; }
    public int Quantity { get; set; }
    public double Cash { get; set; }
    public string Artifact { get; set; }
    public string Description { get; set; }
    public Guid? EducationalLevelId { get; set; }
}