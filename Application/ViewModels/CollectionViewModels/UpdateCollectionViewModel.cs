namespace Application.ViewModels.CollectionViewModels;

public class UpdateCollectionViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public Guid CurrentUserId { get; set; }

}