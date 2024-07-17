namespace Application.SendModels.Resources;

public class ResourcesUpdateRequest
{
    public Guid Id { get; set; }
    public string? Sponsorship { get; set; }
    public Guid CurrentUserId { get; set; }
}