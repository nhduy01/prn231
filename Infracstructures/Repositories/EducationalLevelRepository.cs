using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class EducationalLevelRepository : GenericRepository<EducationalLevel>, IEducationalLevelRepository
{
    public EducationalLevelRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<EducationalLevel>> GetListEducationalLevel(Guid contestId)
    {
        return await DbSet.Where(x => x.ContestId == contestId).ToListAsync();
    }

    public virtual async Task<bool> CheckValidRoundDate(Guid EducationalLevelId,DateTime RoundStartTime, DateTime RoundEndTime)
    {
        var temp = await DbSet.FirstOrDefaultAsync(x => x.Id == EducationalLevelId);
        bool check = false;
        if ((RoundStartTime >= temp.StartTime) && (RoundEndTime <= temp.EndTime) && (RoundStartTime < RoundEndTime))
        {
            check = true;
        }
        return check;
    }
}