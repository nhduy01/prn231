using Application.ViewModels.CollectionViewModels;
using Domain.Models;

namespace Application.IService;

public interface ICollectionService
{
    Task<bool> AddCollection(AddCollectionViewModel addCollectionViewModel);
    Task<bool> DeleteCollection(Guid collectionId);
    Task<bool> UpdateCollection(UpdateCollectionViewModel updateCollection);
    Task<CollectionViewModel> GetCollectionById(Guid collectionId);

    Task<Collection> GetPaintingByCollection(Guid collectionId);
}