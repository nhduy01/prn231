using Domain.Models;

namespace Application.IRepositories;

public interface IContestRepository : IGenericRepository<Contest>
{
    Task<List<int>> Get5RecentYearAsync();
}