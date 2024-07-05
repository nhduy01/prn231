using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(AppDbContext context) : base(context)
    {
    }

    public virtual async Task<List<Painting>> GetPaintingByCollectionAsync(Guid collectionId)
    {
        return await DbSet.Where(x => x.Id == collectionId)
            .SelectMany(x => x.PaintingCollection.Select(x => x.Painting))
            .ToListAsync();
    }
}