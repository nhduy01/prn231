using Domain.Models;

namespace Application.IRepositories;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting?> GetByCodeAsync(String code);
    Task<List<Painting>> List20WiningPaintingAsync();
}