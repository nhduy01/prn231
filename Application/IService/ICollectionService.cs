using Application.ViewModels.CollectionViewModels;

namespace Application.IService;

public interface ICollectionService
{
    Task<Guid?> AddCollection(AddCollectionViewModel addCollectionViewModel);
    Task<CollectionViewModel> DeleteCollection(Guid collectionId);
    Task<UpdateCollectionViewModel> UpdateCollection(UpdateCollectionViewModel updateCollection);
    Task<CollectionViewModel> GetCollectionById(Guid collectionId);
}