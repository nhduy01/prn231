using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(AppDbContext context) : base(context)
    {
    }
}