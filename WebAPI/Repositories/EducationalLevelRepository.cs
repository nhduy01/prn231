using Domain.Models;
using Infracstructures;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class EducationalLevelRepository : GenericRepository<EducationalLevel>, IEducationalLevelRepository
    {
        public EducationalLevelRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
