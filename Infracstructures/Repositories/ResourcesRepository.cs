using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class ResourcesRepository : GenericRepository<Resources>, IResourcesRepository
{
    public ResourcesRepository(AppDbContext context) : base(context)
    {
    }
}