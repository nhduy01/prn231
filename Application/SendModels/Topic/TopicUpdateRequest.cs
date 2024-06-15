namespace Application.SendModels.Topic;

public class TopicUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Guid? RoundId { get; set; }
}