using Application.ViewModels.AwardViewModels;

namespace Application.IService
{
    public interface IAwardService
    {
        Task<Guid?> AddAward(AddAwardViewModel addAwardViewModel, Guid id);
        Task<(List<AwardViewModel>,int)> GetListAward(ListAwardModel listAwardModel);
        Task<AwardViewModel> DeleteAward(Guid awardId);
        Task<UpdateAwardViewModel> UpdateAward(UpdateAwardViewModel updateAward, Guid StaffId);

        
    }
}
