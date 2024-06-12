using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }
}