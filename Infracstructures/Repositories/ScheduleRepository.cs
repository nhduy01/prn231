using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Schedule?> GetByIdAsync(Guid id)
    {
        return await DbSet.Include(s => s.Painting).Include(s => s.AwardSchedule).ThenInclude(a => a.Award).FirstOrDefaultAsync(s => s.Id == id);
    }
}