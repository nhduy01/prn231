using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class EducationalLevelRepository : GenericRepository<EducationalLevel>, IEducationalLevelRepository
{
    public EducationalLevelRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) :
        base(context, timeService, claimsService)
    {
    }

    public async Task<List<EducationalLevel>> GetListEducationalLevel(Guid contestId)
    {
        return await _dbSet.Where(x => x.ContestId == contestId).ToListAsync();
    }
}