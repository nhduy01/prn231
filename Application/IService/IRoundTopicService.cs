using Application.SendModels.RoundTopic;
using Application.ViewModels.TopicViewModels;

namespace Application.IService;

public interface IRoundTopicService
{
    Task<List<RoundTopicViewModel>> GetListRoundTopicForCompetitor(GetListRoundTopicRequest request);
    Task<bool> AddTopicToRound(RoundTopicRequest roundTopicRequest);
    Task<bool> DeleteTopicInRound(RoundTopicDeleteRequest roundTopicDeleteRequest);
    Task<List<RoundTopicViewModel>> GetListRoundTopicForStaff(Guid id);
    Task<bool> IsExistedId(Guid id);
}