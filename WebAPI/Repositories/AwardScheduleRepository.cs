using Domain.Models;
using Infracstructures;
using WebAPI.IRepositories;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class AwardScheduleRepository : GenericRepository<AwardSchedule>, IAwardScheduleRepository
    {
        public AwardScheduleRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
