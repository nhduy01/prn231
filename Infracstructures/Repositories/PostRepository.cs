using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<List<Post>> GetAllAsync()
    {
        return await DbSet.Include(x=>x.Category).ToListAsync();
    }
    public async Task<List<Post>> Get10Post()
    {
        return await DbSet.Where(x => x.Status != PostStatus.Inactive.ToString()).OrderByDescending(p => p.CreatedTime).Include(x => x.Category).Take(10).ToListAsync();
    }

    public async Task<List<Post>> GetPostByCategory(Guid categoryId)
    {
        return await DbSet.Where(x => x.CategoryId == categoryId && x.Status != PostStatus.Inactive.ToString()).ToListAsync();
    }

    public async Task<List<Post>> GetPostByStaffId(Guid staffId)
    {
        return await DbSet.Where(x => x.StaffId == staffId).Include(x => x.Category).ToListAsync();
    }
}