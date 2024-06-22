using Application.IRepositories;
using Application.ViewModels.RoundViewModels;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class RoundRepository : GenericRepository<Round>, IRoundRepository
{
    public RoundRepository(AppDbContext context) : base(context)
    {
    }
    public virtual async Task<Round> GetTopic(Guid RoundId)
    {
        return await DbSet.Include(a => a.Topic)
            .FirstOrDefaultAsync(x => x.Id == RoundId);
    }
}