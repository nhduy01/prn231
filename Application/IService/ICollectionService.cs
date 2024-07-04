using Application.SendModels.Collection;
using Application.ViewModels.CollectionViewModels;
using Domain.Models;

namespace Application.IService;

public interface ICollectionService
{
    Task<bool> AddCollection(CollectionRequest addCollectionViewModel);
    Task<bool> DeleteCollection(Guid collectionId);
    Task<bool> UpdateCollection(UpdateCollectionRequest updateCollection);
    Task<CollectionViewModel> GetCollectionById(Guid collectionId);

    Task<Collection> GetPaintingByCollection(Guid collectionId);
}