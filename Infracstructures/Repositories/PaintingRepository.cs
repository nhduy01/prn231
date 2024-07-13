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
            .Include(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.Account)
            .ToListAsync();
    }
    public virtual async Task<Painting?> GetByCodeAsync(string code)
    {
        return await DbSet.Where(x => x.Status != PaintingStatus.Delete.ToString())
            .Include(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Code == code);
    }
    public override async Task<Painting?> GetByIdAsync(Guid id)
    {
        return await DbSet.Where(x => x.Status != PaintingStatus.Delete.ToString())
            .Include(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public virtual async Task<List<Painting>> List16WiningPaintingAsync()
    {
        return await DbSet.Where(x => x.AwardId != null && x.Status != PaintingStatus.Delete.ToString())
            .OrderByDescending(x => x.UpdatedTime)
            .Include(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.Account)
            .Take(16).ToListAsync();
    }

    public async Task<List<Account>> ListCompetitorPassByRound(Guid roundId)
    {
        return await DbSet.Include(p => p.Account).Where(p => p.Status == PaintingStatus.Pass.ToString() && p.RoundTopicId == roundId)
            .Select(p => p.Account).ToListAsync();
    }
    public async Task<List<Painting>> ListByAccountIdAsync(Guid accountId)
    {
        return await DbSet.Where(x => x.AccountId == accountId && x.Status != PaintingStatus.Delete.ToString())
            .Include(x => x.Account)
            .Include(x => x.RoundTopic)
            .ThenInclude(x=>x.Topic)
            .ToListAsync();
    }

    public async Task<List<Guid>> ListAccountIdByListAwardId (List<Guid> listAwardId)
    {
        return await DbSet
            .Where(x => listAwardId.Contains((Guid)x.AwardId))
            .Select(x => x.AccountId)
            .ToListAsync();
    }
}