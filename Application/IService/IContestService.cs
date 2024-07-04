using Application.SendModels.Contest;
using Domain.Models;

namespace Application.IService;

public interface IContestService
{
    Task<bool> AddContest(ContestRequest addContestViewModel);
    Task<bool> DeleteContest(Guid contestId);

    Task<bool> UpdateContest(UpdateContest updateContest);

    Task<Contest?> GetContestById(Guid awardId);

    Task<List<int>> Get5RecentYear();
}