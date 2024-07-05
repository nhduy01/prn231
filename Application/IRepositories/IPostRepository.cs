using Domain.Models;

namespace Application.IRepositories;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> Get10Post();
    Task<List<Post>> GetPostByCategory(Guid categoryId);
    Task<List<Post>> GetPostByStaffId(Guid staffId);
}