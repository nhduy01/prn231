namespace Infracstructures.ViewModels.PostViewModels;

public class PostViewModel
{
    public string Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid? ContestId { get; set; }
    public Guid? StaffId { get; set; }
}