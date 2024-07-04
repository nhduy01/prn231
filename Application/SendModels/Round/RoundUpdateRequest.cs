namespace Application.SendModels.Round;

public class RoundUpdateRequest
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public Guid? EducationalLevelId { get; set; }
    public Guid CurrentUserId { get; set; }
}