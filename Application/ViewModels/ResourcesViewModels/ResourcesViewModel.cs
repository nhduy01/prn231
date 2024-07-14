namespace Application.ViewModels.ResourcesViewModels;

public class ResourcesViewModel
{
    public Guid? Id { get; set; }
    public string Sponsorship { get; set; }
    public Guid? SponsorId { get; set; }
    public Guid? ContestId { get; set; }
}