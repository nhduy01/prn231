using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context)
    {
    }

    override 
    public async Task<Schedule?> GetByIdAsync(Guid id)
    {
        return await DbSet.Include(s => s.Painting).Include(s => s.AwardSchedule).ThenInclude(a => a.Award).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Schedule>> GetByExaminerId(Guid id)
    {
        return await DbSet.Where(s => s.ExaminerId == id).ToListAsync();
    }
}