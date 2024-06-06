using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class PaintingCollectionRepository : GenericRepository<PaintingCollection>, IPaintingCollectionRepository
    {
        public PaintingCollectionRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
