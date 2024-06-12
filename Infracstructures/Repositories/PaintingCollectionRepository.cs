using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PaintingCollectionRepository : GenericRepository<PaintingCollection>, IPaintingCollectionRepository
{
    public PaintingCollectionRepository(AppDbContext context) : base(context)
    {
    }
}