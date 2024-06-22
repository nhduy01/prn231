using Application.ViewModels.PaintingCollectionViewModels;

namespace Application.IService;

public interface IPaintingCollectionService
{
    Task<bool> AddPaintingToCollection(AddPaintingCollectionViewModel addPaintingCollectionViewModel);

    Task<bool> DeletePaintingInCollection(Guid paintingcollectionId);
}