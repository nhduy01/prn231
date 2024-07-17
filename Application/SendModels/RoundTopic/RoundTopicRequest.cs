namespace Application.SendModels.RoundTopic;

public class RoundTopicRequest
{
    public Guid RoundId { get; set; }
    public List<Guid> ListTopicId { get; set; }
}