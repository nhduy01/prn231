using Application.BaseModels;
using Application.SendModels.Round;
using Application.ViewModels.RoundViewModels;

namespace Application.IService;

public interface IRoundService
{
    public Task<Guid?> CreateRound(RoundRequest Round);
    public Task<(List<RoundViewModel>, int)> GetListRound(ListModels listModels);
    public Task<RoundViewModel?> GetRoundById(Guid id);
    public Task<RoundViewModel?> UpdateRound(RoundUpdateRequest updateRound);
    public Task<bool?> DeleteRound(Guid id);
}