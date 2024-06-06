using Domain.Models;
using Infracstructures;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
