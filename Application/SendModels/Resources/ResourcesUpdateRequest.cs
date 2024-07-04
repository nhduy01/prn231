namespace Application.SendModels.Resources;

public class ResourcesUpdateRequest
{
    public Guid Id { get; set; }
    public string? Cash { get; set; }
    public string? Artifact { get; set; }
    public Guid? SponsorId { get; set; }
    public Guid? ContestId { get; set; }
    public Guid CurrentUserId { get; set; }

}