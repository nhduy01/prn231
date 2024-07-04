using Application.SendModels.PaintingCollection;

namespace Application.IService;

public interface IPaintingCollectionService
{
    Task<bool> AddPaintingToCollection(PaintingCollectionRequest addPaintingCollectionViewModel);

    Task<bool> DeletePaintingInCollection(Guid paintingcollectionId);
}