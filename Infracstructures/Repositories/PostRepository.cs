using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Post>> Get10Post()
    {
        return await DbSet.OrderByDescending(p => p.CreatedTime).Take(10).ToListAsync();
    }

    public async Task<List<Post>> GetPostByCategory(Guid categoryId)
    {
        return await DbSet.Where(x=>x.CategoryId == categoryId).ToListAsync();
    }
}