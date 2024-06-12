using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(AppDbContext context) : base(context)
    {
    }
}