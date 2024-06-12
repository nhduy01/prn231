using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context,
        timeService, claimsService)
    {
    }
}