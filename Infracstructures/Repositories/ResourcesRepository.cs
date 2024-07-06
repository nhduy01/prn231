using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ResourcesRepository : GenericRepository<Resources>, IResourcesRepository
{
    public ResourcesRepository(AppDbContext context) : base(context)
    {

    }
        public override async Task<Resources?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == ResourcesStatus.Active.ToString());
    }

    public override async Task<List<Resources>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status == ResourcesStatus.Active.ToString()).ToListAsync();
    }
}
