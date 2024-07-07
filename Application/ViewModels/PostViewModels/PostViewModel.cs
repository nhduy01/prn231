namespace Infracstructures.ViewModels.PostViewModels;

public class PostViewModel
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public Guid? StaffId { get; set; }
    public Guid CategoryId { get; set; }
    public String CategoryName {  get; set; }
}