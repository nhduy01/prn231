namespace Application.ViewModels.SponsorViewModels;

public class SponsorViewModel
{
    public Guid Id { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Delegate { get; set; }
    public string? PhoneNumber { get; set; }
}