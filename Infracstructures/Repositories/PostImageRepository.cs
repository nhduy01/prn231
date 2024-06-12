using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class PostImageRepository : GenericRepository<PostImage>, IPostImageRepository
{
    public PostImageRepository(AppDbContext context) : base(context)
    {
    }
}