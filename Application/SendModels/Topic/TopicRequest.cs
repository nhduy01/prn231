namespace Application.SendModels.Topic;

public class TopicRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Guid CurrentUserId { get; set; }
}