using Application.BaseModels;
using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using Infracstructures.SendModels.Painting;

namespace Application.IService;

public interface IPaintingService
{
    Task<bool> DraftPaintingForPreliminaryRound(PaintingRequest2 request);
    Task<bool> SubmitPaintingForPreliminaryRound(PaintingRequest request);
    Task<bool> AddPaintingForFinalRound(PaintingRequest request);
    Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel);
    Task<bool> DeletePainting(Guid paintingId);
    Task<bool> UpdatePainting(UpdatePaintingRequest updatePainting);
    Task<PaintingViewModel?> GetPaintingByCode(string code);
    Task<PaintingViewModel?> GetPaintingById(Guid id);
    Task<List<PaintingViewModel>> List16WiningPainting();

    Task<(List<PaintingViewModel>, int)> FilterPainting(FilterPaintingRequest filterPainting,
        ListModels listPaintingModel);


    /*public Task<bool> SubmitPainting(Guid paintingId);*/
    public Task<PaintingViewModel?> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request);
    public Task<PaintingViewModel?> FinalDecisionOfPainting(PaintingUpdateStatusRequest request);


    Task<bool> SubmitPaintingForPreliminaryRoundForCompetitor(PaintingRequest2 request);
    Task<(List<PaintingViewModel>, int)> ListPaintingByAccountId(Guid accountId, ListModels listPaintingModel);
}