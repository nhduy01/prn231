namespace Application.SendModels.RoundTopic;

public class GetListRoundTopicRequest
{
    public Guid ContestId { get; set; }
    public Guid AccountId { get; set; }
}