using Domain.Models;

namespace Application.IRepositories;

public interface ICollectionRepository : IGenericRepository<Collection>
{
    Task<List<Painting>> GetPaintingByCollectionAsync(Guid collectionId);
    Task<List<Collection>> GetCollectionByAccountIdAsync(Guid accountId);
}