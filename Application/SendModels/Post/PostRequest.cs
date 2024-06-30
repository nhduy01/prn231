using Application.SendModels.Image;

namespace Application.SendModels.Post;

public class PostRequest
{
    public string? Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public List<ImageRequest>? Images { get; set; }
}