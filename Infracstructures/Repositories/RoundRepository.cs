using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class RoundRepository : GenericRepository<Round>, IRoundRepository
{
    public RoundRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context,
        timeService, claimsService)
    {
    }
}