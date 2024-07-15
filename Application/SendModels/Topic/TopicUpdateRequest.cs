namespace Application.SendModels.Topic;

public class TopicUpdateRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CurrentUserId { get; set; }
}