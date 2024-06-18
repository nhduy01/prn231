using System.Linq;
using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(AppDbContext context) : base(context)
    {
    }

    public virtual async Task<Collection?> GetPaintingByCollectionAsync(Guid collectionId)
    {   
        return await DbSet.Include(a => a.PaintingCollection)
            .ThenInclude(x => x.Painting)
            .FirstOrDefaultAsync(x => x.Id == collectionId);

    }
}