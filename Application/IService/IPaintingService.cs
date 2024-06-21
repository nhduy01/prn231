using Application.BaseModels;
using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using Domain.Models;
using Infracstructures.SendModels.Painting;

namespace Application.IService;

public interface IPaintingService
{
    Task<Guid?> AddPaintingForPreliminaryRound(PaintingRequest request);
    Task<Guid?> AddPaintingForFinalRound(PaintingRequest request);
    Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel);
    Task<PaintingViewModel?> DeletePainting(Guid paintingId);
    Task<UpdatePaintingViewModel?> UpdatePainting(UpdatePaintingViewModel updatePainting);
    Task<PaintingViewModel?> GetPaintingByCode(string code);
    Task<PaintingViewModel?> GetPaintingById(Guid id);
    Task<PaintingViewModel> List20WiningPainting();


    public Task<PaintingViewModel?> SubmitPainting(Guid paintingId);
    public Task<PaintingViewModel?> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request);
    public Task<PaintingViewModel?> FinalDecisionOfPainting(PaintingUpdateStatusRequest request);
}