using Application.ViewModels.ContestViewModels;

namespace Application.IService
{
    public interface IContestService
    {
        Task<Guid?> AddContest(AddContestViewModel addContestViewModel);
        Task<Guid> DeleteContest(Guid contestId);
        Task<UpdateContestViewModel> UpdateContest(UpdateContestViewModel updateContest);
        Task<ContestViewModel> GetContestById(Guid awardId);
    }
}
