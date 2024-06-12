using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PostImageRepository : GenericRepository<PostImage>, IPostImageRepository
{
    public PostImageRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }
}