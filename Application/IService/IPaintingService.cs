using Application.BaseModels;
using Application.ViewModels.AwardViewModels;
using Application.ViewModels.PaintingViewModels;

namespace Application.IService;

public interface IPaintingService
{
    Task<Guid?> AddPainting(AddPaintingViewModel addPaintingViewModel);
    Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel);
    Task<PaintingViewModel> DeletePainting(Guid paintingId);
    Task<UpdatePaintingViewModel> UpdatePainting(UpdatePaintingViewModel updatePainting);
    Task<PaintingViewModel> GetPaintingByCode(String code);
    Task<PaintingViewModel> List20WiningPainting();
}