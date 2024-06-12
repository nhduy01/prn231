using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class SponsorRepository : GenericRepository<Sponsor>, ISponsorRepository
{
    public SponsorRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }
}