using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class AwardRepository : GenericRepository<Award>, IAwardRepository
{
    public AwardRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context,
        timeService, claimsService)
    {
    }
}