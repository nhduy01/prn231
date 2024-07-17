using Domain.Models;

namespace Application.IRepositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<Category>> GetCategoryUnused();
    Task<List<Category>> GetCategoryUsed();
}