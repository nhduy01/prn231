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

    public async Task<Contest> GetAllContestInformationAsync(Guid contestId)
    {

        return await DbSet
            .Include(x=>x.Resources)
            .ThenInclude(x=>x.Sponsor)
            .Include(x => x.EducationalLevel)
            .ThenInclude(x=>x.Round)
            .ThenInclude(x=>x.Topic)
            .Include(x => x.EducationalLevel)
            .ThenInclude(x=>x.Award)
            .FirstOrDefaultAsync(x =>x .Id == contestId);
    }

    public async Task<List<int>> Get5RecentYearAsync()
    {
        var result = DbSet.Select(x => (int)x.CreatedTime.Year).Take(5).ToListAsync();
        return await result;
    }
}