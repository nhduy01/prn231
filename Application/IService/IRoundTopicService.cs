using Application.SendModels.RoundTopic;
using Application.ViewModels.TopicViewModels;

namespace Application.IService;

public interface IRoundTopicService
{
    Task<List<RoundTopicViewModel>> GetListRoundTopic(GetListRoundTopicRequest request);
    Task<bool> AddTopicToRound(RoundTopicRequest roundTopicRequest);
    Task<bool> DeleteTopicInRound(RoundTopicDeleteRequest roundTopicDeleteRequest);
}