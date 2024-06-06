using Domain.Models;
using Infracstructures;
using WebAPI.IRepositories;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class ContestRepository : GenericRepository<Contest>, IContestRepository
    {
        public ContestRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
