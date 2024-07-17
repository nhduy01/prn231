using Application.SendModels.Contest;
using Application.ViewModels.ContestViewModels;

namespace Application.IService;

public interface IContestService
{
    Task<bool> AddContest(ContestRequest addContestViewModel);
    Task<bool> DeleteContest(Guid contestId);

    Task<bool> UpdateContest(UpdateContest updateContest);

    Task<ContestDetailViewModel?> GetContestById(Guid contestId);

    Task<List<int>> Get5RecentYear();

    Task<List<ContestViewModel?>> GetAllContest();

    Task<ContestDetailViewModel> GetNearestContest();
}