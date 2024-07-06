using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
{
    public PaintingRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<List<Painting>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status != PaintingStatus.Delete.ToString())
            .ToListAsync();
    }
    public virtual async Task<Painting?> GetByCodeAsync(string code)
    {
        return await DbSet.Where(x => x.Status != PaintingStatus.Delete.ToString())
            .FirstOrDefaultAsync(x => x.Code == code);
    }
    public override async Task<Painting?> GetByIdAsync(Guid id)
    {
        return await DbSet.Where(x => x.Status != PaintingStatus.Delete.ToString())
            .FirstOrDefaultAsync(x => x.Id == id && x.Status == AwardStatus.Active.ToString());
    }
    public virtual async Task<List<Painting>> List20WiningPaintingAsync()
    {
        return await DbSet.Where(x => x.AwardId != null && x.Status != PaintingStatus.Delete.ToString())
            .OrderByDescending(x => x.UpdatedTime)
            .Include(x => x.Award)
            .Take(20).ToListAsync();
    }

    public async Task<List<Account>> ListCompetitorPassRound(Guid id)
    {
        return await DbSet.Include(p => p.Account).Where(p => p.Status == PaintingStatus.Pass.ToString() && p.RoundTopicId == id)
            .Select(p => p.Account).ToListAsync();
    }
}