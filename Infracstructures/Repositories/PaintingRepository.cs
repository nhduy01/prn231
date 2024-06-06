using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class PaintingRepository : GenericRepository<Painting>, IPaintingRepository
    {
        public PaintingRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
