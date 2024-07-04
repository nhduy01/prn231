using Application.BaseModels;
using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using Domain.Models;
using Infracstructures.SendModels.Painting;

namespace Application.IService;

public interface IPaintingService
{

    Task<bool> DraftPaintingForPreliminaryRound(SendModels.Painting.PaintingRequest request);
    Task<bool> SubmitPaintingForPreliminaryRound(SendModels.Painting.PaintingRequest request);
    Task<bool> AddPaintingForFinalRound(SendModels.Painting.PaintingRequest request);
    Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel);
    Task<bool> DeletePainting(Guid paintingId);
    Task<bool> UpdatePainting(UpdatePaintingRequest updatePainting);
    Task<PaintingViewModel?> GetPaintingByCode(string code);
    Task<PaintingViewModel?> GetPaintingById(Guid id);
    Task<PaintingViewModel> List20WiningPainting();


    /*public Task<bool> SubmitPainting(Guid paintingId);*/
    public Task<PaintingViewModel?> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request);
    public Task<PaintingViewModel?> FinalDecisionOfPainting(PaintingUpdateStatusRequest request);
}