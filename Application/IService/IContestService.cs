using Application.ViewModels.ContestViewModels;
using Domain.Models;

namespace Application.IService;

public interface IContestService
{
    Task<Guid?> AddContest(AddContestViewModel addContestViewModel);
    Task<Guid> DeleteContest(Guid contestId);

    Task<UpdateContestViewModel> UpdateContest(UpdateContestViewModel updateContest);

    Task<Contest?> GetContestById(Guid awardId);

    Task<List<int>> Get5RecentYear();
}