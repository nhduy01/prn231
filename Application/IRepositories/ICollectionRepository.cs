using Domain.Models;

namespace Application.IRepositories;

public interface ICollectionRepository : IGenericRepository<Collection>
{
    Task<Collection?> GetPaintingByCollectionAsync(Guid collectionId);
}