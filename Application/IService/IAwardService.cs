using Application.BaseModels;
using Application.ViewModels.AwardViewModels;

namespace Application.IService;

public interface IAwardService
{
    Task<bool> AddAward(AddAwardViewModel addAwardViewModel);
    Task<(List<AwardViewModel>, int)> GetListAward(ListModels listAwardModel);
    Task<bool> DeleteAward(Guid awardId);
    Task<bool> UpdateAward(UpdateAwardViewModel updateAward);
    Task<AwardViewModel> GetAwardById(Guid awardId);
}