using Application.BaseModels;
using Application.SendModels.Round;
using Application.ViewModels.RoundViewModels;
using Application.ViewModels.TopicViewModels;

namespace Application.IService;

public interface IRoundService
{
    public Task<bool> CreateRound(RoundRequest Round);
    public Task<(List<RoundViewModel>, int)> GetListRound(ListModels listModels);
    public Task<List<RoundViewModel>> GetListRoundByContestId(Guid id);
    public Task<RoundViewModel?> GetRoundById(Guid id);
    public Task<bool> UpdateRound(RoundUpdateRequest updateRound);
    Task<bool> DeleteRound(Guid id);
    Task<(List<TopicViewModel>, int)> GetTopicInRound(Guid id, ListModels listModels);
    Task<(List<RoundViewModel>, int)> GetRoundByEducationalLevelId(ListModels listLevelModel, Guid levelId);
}