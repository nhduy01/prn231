using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class EducationalLevelRepository : GenericRepository<EducationalLevel>, IEducationalLevelRepository
    {
        public EducationalLevelRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
