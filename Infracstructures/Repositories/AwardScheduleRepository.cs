using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class AwardScheduleRepository : GenericRepository<AwardSchedule>, IAwardScheduleRepository
{
    public AwardScheduleRepository(AppDbContext context) : base(context)
    {
    }
}