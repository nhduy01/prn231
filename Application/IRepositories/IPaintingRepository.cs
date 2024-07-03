using Domain.Models;

namespace Application.IRepositories;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting?> GetByCodeAsync(string code);
    Task<List<Painting>> List20WiningPaintingAsync();
    Task<List<Account>> ListCompetitorPassRound(Guid id);
}