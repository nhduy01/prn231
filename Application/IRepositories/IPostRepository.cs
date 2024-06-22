using Domain.Models;

namespace Application.IRepositories;

public interface IPostRepository : IGenericRepository<Post>
{
    public Task<List<Post>> Get10Post();
}