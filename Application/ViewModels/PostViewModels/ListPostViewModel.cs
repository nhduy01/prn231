namespace Application.ViewModels.PostViewModels;

public class ListPostViewModel
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid? StaffId { get; set; }
    public Guid? CategoryId { get; set; }
    public String? CategoryName {  get; set; }
}