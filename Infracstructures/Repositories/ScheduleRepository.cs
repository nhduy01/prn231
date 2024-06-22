using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Schedule?> GetById(Guid id)
    {
        return await DbSet.Include(s => s.Painting).FirstOrDefaultAsync(s => s.Id == id);
    }
}