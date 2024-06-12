using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context,
        timeService, claimsService)
    {
    }
}