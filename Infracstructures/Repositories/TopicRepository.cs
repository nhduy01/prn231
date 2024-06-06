using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
