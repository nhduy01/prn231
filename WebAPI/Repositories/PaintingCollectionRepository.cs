using Domain.Models;
using Infracstructures;
using WebAPI.IService.ICommonService;

namespace WebAPI.Repositories
{
    public class PaintingCollectionRepository : GenericRepository<PaintingCollection>, IPaintingCollectionRepository
    {
        public PaintingCollectionRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
