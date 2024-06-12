using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    public ContestRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }

    /*public async Task<ContestViewModel> GetAllContestInformation(Guid contestId)
    {

        return await _dbSet.Include(x => x.EducationalLevel)
            .ThenInclude(x => x.Round)
            .Include(x => x.EducationalLevel);
    }*/
}