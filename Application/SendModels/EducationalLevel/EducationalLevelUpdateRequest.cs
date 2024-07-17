namespace Application.SendModels.EducationalLevel;

public class EducationalLevelUpdateRequest
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? EducationLevel { get; set; }
    public string? Level { get; set; }
    public Guid ContestId { get; set; }
    public Guid CurrentUserId { get; set; }
}