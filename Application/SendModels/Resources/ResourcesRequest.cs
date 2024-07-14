namespace Application.SendModels.Resources;

public class ResourcesRequest
{
    public string Cash { get; set; }
    public string Artifact { get; set; }
    public Guid SponsorId { get; set; }
    public Guid ContestId { get; set; }
    public Guid CurrentUserId { get; set; }
}