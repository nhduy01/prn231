using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PaintingCollectionRepository : GenericRepository<PaintingCollection>, IPaintingCollectionRepository
{
    public PaintingCollectionRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) :
        base(context, timeService, claimsService)
    {
    }
}