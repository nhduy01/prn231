namespace Application.SendModels.EducationalLevel;

public class EducationalLevelRequest
{
    public string Description { get; set; }
    public string Level { get; set; }
    public Guid ContestId { get; set; }
    public Guid CurrentUserId { get; set; }
}