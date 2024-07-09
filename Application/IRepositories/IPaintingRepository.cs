using Domain.Models;

namespace Application.IRepositories;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting?> GetByCodeAsync(string code);
    Task<List<Painting>> List20WiningPaintingAsync();
    Task<List<Account>> ListCompetitorPassByRound(Guid roundId);
    Task<List<Painting>> ListByAccountIdAsync(Guid accountId);
    Task<List<Guid>> ListAccountIdByListAwardId(List<Guid> listAwardId);
}