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

}