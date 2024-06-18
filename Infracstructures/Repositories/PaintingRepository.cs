using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

    public virtual async Task<List<Painting>> List20WiningPaintingAsync()
    {
        return await DbSet.Where(x => x.AwardId != null).OrderByDescending(x => x.UpdatedTime).Include(x => x.Award).Take(20).ToListAsync() ;
    }

}