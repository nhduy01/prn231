using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

}