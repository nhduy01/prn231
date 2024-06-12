namespace Infracstructures.SendModels.Sponsor;

public class SponsorRequest
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Delegate { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid? CreatedBy { get; set; }
}