using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class RoundRepository : GenericRepository<Round>, IRoundRepository
{
    public RoundRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Round?> GetRoundDetail(Guid id)
    {
        return await DbSet.Include(r => r.EducationalLevel).ThenInclude(e => e.Award).FirstOrDefaultAsync(r => r.Id == id);
    }
    public virtual async Task<Round?> GetTopic(Guid RoundId)
    {
        return await DbSet.Include(a => a.Topic)
            .FirstOrDefaultAsync(x => x.Id == RoundId);
    }
}