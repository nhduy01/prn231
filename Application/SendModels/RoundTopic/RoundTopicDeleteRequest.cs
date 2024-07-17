namespace Application.SendModels.RoundTopic;

public class RoundTopicDeleteRequest
{
    public Guid RoundId { get; set; }
    public Guid TopicId { get; set; }
}