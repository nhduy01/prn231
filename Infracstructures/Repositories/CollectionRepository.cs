using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<List<Collection>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status == CollectionStatus.Active.ToString())
            .Include(x => x.Account)
            .ToListAsync();
    }
    public override async Task<Collection?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == CollectionStatus.Active.ToString());
    }
    public virtual async Task<List<Painting>> GetPaintingByCollectionAsync(Guid collectionId)
    {
        return await DbSet.Where(x => x.Id == collectionId)
            .SelectMany(x => x.PaintingCollection.Select(x => x.Painting).Where(x=>x.Status != PaintingStatus.Delete.ToString()))
            .ToListAsync();
    }
    public virtual async Task<List<Collection>> GetCollectionByAccountIdAsync(Guid accountId)
    {
        return await DbSet.Where(x=>x.CreatedBy == accountId && x.Status == CollectionStatus.Active.ToString()).Include(x => x.Account).ToListAsync();
    }
}