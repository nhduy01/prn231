using Application.ViewModels.ContestViewModels;
using Domain.Models;

namespace Application.IService;

public interface IContestService
{
    Task<bool> AddContest(AddContestViewModel addContestViewModel);
    Task<bool> DeleteContest(Guid contestId);

    Task<bool> UpdateContest(UpdateContestViewModel updateContest);

    Task<Contest?> GetContestById(Guid awardId);

    Task<List<int>> Get5RecentYear();
}