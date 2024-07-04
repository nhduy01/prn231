namespace Infracstructures.SendModels.Sponsor;

public class SponsorUpdateRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Delegate { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid CurrentUserId { get; set; }
}