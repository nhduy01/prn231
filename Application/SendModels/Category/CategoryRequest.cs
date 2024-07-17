namespace Application.SendModels.Category;

public class CategoryRequest
{
    public Guid CurrentUserId { get; set; }
    public string Name { get; set; }
}