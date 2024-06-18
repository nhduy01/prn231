using System.Linq;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    public ContestRepository(AppDbContext context) : base(context)
    {
    }

    /*public async Task<ContestViewModel> GetAllContestInformation(Guid contestId)
    {

        return await DbSet.Include(x => x.EducationalLevel)
            .ThenInclude(x => x.Round)
            .Include(x => x.EducationalLevel);
    }*/

    public async Task<List<int>> Get5RecentYearAsync()
    {
        var result = DbSet.Select(x => (int)x.CreatedTime.Year).Take(5).ToListAsync();
        return await result;
    }
}