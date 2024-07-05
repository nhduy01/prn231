using Application.SendModels.Collection;
using Application.ViewModels.CollectionViewModels;
using Application.ViewModels.PaintingViewModels;
using Domain.Models;

namespace Application.IService;

public interface ICollectionService
{
    Task<bool> AddCollection(CollectionRequest addCollectionViewModel);
    Task<bool> DeleteCollection(Guid collectionId);
    Task<bool> UpdateCollection(UpdateCollectionRequest updateCollection);
    Task<CollectionViewModel> GetCollectionById(Guid collectionId);
    Task<List<PaintingViewModel>> GetPaintingByCollection(Guid collectionId);
}