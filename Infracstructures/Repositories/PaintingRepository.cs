using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
{
    public PaintingRepository(AppDbContext context) : base(context)
    {

    }

    public virtual async Task<Painting?> GetByCodeAsync(String code)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Code == code);
    }

}