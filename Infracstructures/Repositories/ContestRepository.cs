using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    public ContestRepository(AppDbContext context) : base(context)
    {
    }

    /*public async Task<ContestViewModel> GetAllContestInformation(Guid contestId)
    {

        return await _dbSet.Include(x => x.EducationalLevel)
            .ThenInclude(x => x.Round)
            .Include(x => x.EducationalLevel);
    }*/
}