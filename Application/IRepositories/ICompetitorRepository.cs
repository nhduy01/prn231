using Domain.Models;

namespace Application.IRepositories;

public interface ICompetitorRepository : IGenericRepository<Competitor>
{
    public Task<Competitor?> Login(string email);
    public Task<Competitor?> GetByRefreshToken(string token);
    public Task<bool> CheckDuplicate(string email, string phone);
}