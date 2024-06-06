using Domain.Models;
using Infracstructures;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
    {
        public PaintingRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
