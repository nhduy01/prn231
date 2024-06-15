namespace Application.SendModels.Post;

public class PostRequest
{
    public string Url { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Image { get; set; }
}
public class CreateImage {
}