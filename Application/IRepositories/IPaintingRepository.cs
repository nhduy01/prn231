using Application.SendModels.Painting;
using Domain.Models;

namespace Application.IRepositories;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting?> GetByCodeAsync(string code);
    Task<List<Painting>> List16WiningPaintingAsync();
    Task<List<Account>> ListCompetitorPassByRound(Guid roundId);
    Task<List<Painting>> ListByAccountIdAsync(Guid accountId);
    Task<List<Guid>> ListAccountIdByListAwardId(List<Guid> listAwardId);
    Task<List<Painting>> FilterPaintingAsync(FilterPaintingRequest filterPainting);
    Task<int> CreateNewNumberOfPaintingCode(Guid roundId);
}