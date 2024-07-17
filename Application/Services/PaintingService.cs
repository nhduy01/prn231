using Application.BaseModels;
using Application.IService;
using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.SendModels.Painting;

namespace Application.Services;

public class PaintingService : IPaintingService
{
    private readonly IMapper _mapper;
    private readonly INotificationService _notificationService;
    private readonly IUnitOfWork _unitOfWork;


    public PaintingService(IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
    {
        _notificationService = notificationService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Draft Painting Preliminary Round

    public async Task<bool> DraftPaintingForPreliminaryRound(PaintingRequest2 request)
    {
        var painting = _mapper.Map<Painting>(request);
        painting.Status = PaintingStatus.Draft.ToString();
        painting.Code = ""; // Sửa Db thì xóa
        painting.RoundTopicId = await _unitOfWork.RoundTopicRepo.GetRoundTopicId(request.RoundId, request.TopicId);
        await _unitOfWork.PaintingRepo.AddAsync(painting);

        await _unitOfWork.SaveChangesAsync();

        painting.Code = await GeneratePaintingCode(painting.Id, request.RoundId);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Submit Painting Preliminary Round

    public async Task<bool> SubmitPaintingForPreliminaryRound(PaintingRequest request)
    {
        var check = await _unitOfWork.RoundRepo.CheckSubmitValidDate(request.RoundId);

        if (check)
        {
            var painting = _mapper.Map<Painting>(request);
            painting.Status = PaintingStatus.Submitted.ToString();
            painting.Code = ""; // Sửa Db thì xóa
            painting.RoundTopicId = await _unitOfWork.RoundTopicRepo.GetRoundTopicId(request.RoundId, request.TopicId);
            await _unitOfWork.PaintingRepo.AddAsync(painting);
            await _unitOfWork.SaveChangesAsync();

            painting.Code = await GeneratePaintingCode(painting.Id, request.RoundId);
            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                var notification = new Notification();
                //notification.Status = NotificationStatus.
                //_notificationService.CreateNotification()
            }

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        throw new Exception("Khong trong thoi gian nop bai");
    }

    #endregion

    #region Submit Painting Preliminary Round For Competitor

    public async Task<bool> SubmitPaintingForPreliminaryRoundForCompetitor(PaintingRequest2 request)
    {
        var check = await _unitOfWork.RoundRepo.CheckSubmitValidDate(request.RoundId);
        if (check)
        {
            var painting = _mapper.Map<Painting>(request);
            painting.Code = ""; // Sửa Db thì xóa
            painting.Status = PaintingStatus.Submitted.ToString();
            painting.RoundTopicId = await _unitOfWork.RoundTopicRepo.GetRoundTopicId(request.RoundId, request.TopicId);
            await _unitOfWork.PaintingRepo.AddAsync(painting);
            await _unitOfWork.SaveChangesAsync();

            painting.Code = await GeneratePaintingCode(painting.Id, request.RoundId);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        throw new Exception("Khong trong thoi gian nop bai");
    }

    #endregion

    #region Add Painting Final Round

    public async Task<bool> AddPaintingForFinalRound(PaintingRequest request)
    {
        var painting = _mapper.Map<Painting>(request);
        painting.Status = PaintingStatus.FinalRound.ToString();
        painting.Code = ""; // Sửa Db thì xóa
        painting.RoundTopicId = await _unitOfWork.RoundTopicRepo.GetRoundTopicId(request.RoundId, request.TopicId);
        await _unitOfWork.PaintingRepo.AddAsync(painting);

        await _unitOfWork.SaveChangesAsync();

        painting.Code = await GeneratePaintingCode(painting.Id, request.RoundId);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get List Painting

    public async Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel)
    {
        var paintingList = await _unitOfWork.PaintingRepo.GetAllAsync();
        if (paintingList.Count == 0) throw new Exception("Khong tim thay Painting nao");
        var result = _mapper.Map<List<PaintingViewModel>>(paintingList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listPaintingModel.PageSize);
        int? itemsToSkip = (listPaintingModel.PageNumber - 1) * listPaintingModel.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listPaintingModel.PageSize)
            .ToList();
        return (result, totalPages);
    }

    #endregion

    #region Delete Painting

    public async Task<bool> DeletePainting(Guid paintingId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);
        if (painting == null) throw new Exception("Khong tim thay Painting");

        if (painting.Status != PaintingStatus.Draft.ToString())
        {
            throw new Exception("Khong duoc xoa");
            ;
        }

        painting.Status = PaintingStatus.Delete.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Update Painting

    public async Task<bool> UpdatePainting(UpdatePaintingRequest updatePainting)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(updatePainting.Id);

        if (painting == null) throw new Exception("Khong tim thay Painting");


        if (painting.Status != PaintingStatus.Draft.ToString()) throw new Exception("Khong duoc sua");

        _mapper.Map(updatePainting, painting);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Review Decision of Painting

    public async Task<PaintingViewModel?> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(request.Id);
        if (painting == null) return null;

        if (painting.Status != PaintingStatus.Submitted.ToString()) return null;

        if (request.IsPassed)
            painting.Status = PaintingStatus.Accepted.ToString();
        else
            painting.Status = PaintingStatus.Rejected.ToString();
        painting.ReviewedTimestamp = DateTime.Now;

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Final Decision of Painting

    public async Task<PaintingViewModel?> FinalDecisionOfPainting(PaintingUpdateStatusRequest request)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(request.Id);
        if (painting == null) return null;

        if (painting.Status != PaintingStatus.Accepted.ToString()) return null;

        if (request.IsPassed)
            painting.Status = PaintingStatus.Pass.ToString();
        else
            painting.Status = PaintingStatus.NotPass.ToString();

        painting.FinalDecisionTimestamp = DateTime.Now;

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Get Painting By Code

    public async Task<PaintingViewModel> GetPaintingByCode(string code)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByCodeAsync(code);
        if (painting == null) throw new Exception("Khong tim thay Painting");
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Get Painting By Id

    public async Task<PaintingViewModel> GetPaintingById(Guid id)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(id);
        if (painting == null) throw new Exception("Khong tim thay Painting");
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region List 16 Wining Painting

    public async Task<List<PaintingViewModel>> List16WiningPainting()
    {
        var painting = await _unitOfWork.PaintingRepo.List16WiningPaintingAsync();
        if (painting.Count == 0) throw new Exception("Khong tim thay Painting nao");
        return _mapper.Map<List<PaintingViewModel>>(painting);
    }

    #endregion

    #region List Painting By AccountId

    public async Task<(List<PaintingViewModel>, int)> ListPaintingByAccountId(Guid accountId,
        ListModels listPaintingModel)
    {
        var listPainting = await _unitOfWork.PaintingRepo.ListByAccountIdAsync(accountId);
        if (listPainting.Count == 0) throw new Exception("Khong tim thay Painting");
        var result = _mapper.Map<List<PaintingViewModel>>(listPainting);

        #region pagination

        var totalPages = (int)Math.Ceiling((double)result.Count / listPaintingModel.PageSize);
        int? itemsToSkip = (listPaintingModel.PageNumber - 1) * listPaintingModel.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listPaintingModel.PageSize)
            .ToList();

        #endregion

        return (result, totalPages);
    }

    #endregion

    #region Filter Painting

    public async Task<(List<PaintingViewModel>, int)> FilterPainting(FilterPaintingRequest filterPainting,
        ListModels listPaintingModel)
    {
        var listPainting = await _unitOfWork.PaintingRepo.FilterPaintingAsync(filterPainting);
        if (listPainting.Count == 0) throw new Exception("Khong tim thay Painting");
        var result = _mapper.Map<List<PaintingViewModel>>(listPainting);

        #region pagination

        var totalPages = (int)Math.Ceiling((double)result.Count / listPaintingModel.PageSize);
        int? itemsToSkip = (listPaintingModel.PageNumber - 1) * listPaintingModel.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listPaintingModel.PageSize)
            .ToList();

        #endregion

        return (result, totalPages);
    }

    #endregion

    #region Submit Painting

    public async Task<bool> SubmitPainting(Guid paintingId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);
        if (painting == null) throw new Exception("Khong tim thay Painting");

        if (painting.Status != PaintingStatus.Draft.ToString()) throw new Exception("Painting da Submit");

        painting.Status = PaintingStatus.Submitted.ToString();

        painting.SubmittedTimestamp = DateTime.Now;

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Generate Painting Code Async

    private async Task<string> GeneratePaintingCode(Guid paintingId, Guid RoundId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);

        var year = painting.RoundTopic.Round.EducationalLevel.Contest.StartTime.ToString("yy");
        var levelChar = painting.RoundTopic.Round.EducationalLevel.Level.Last().ToString();
        var roundCode = painting.RoundTopic.Round.Name == "Vòng Chung Kết" ? "CK" : "VL";

        int number;
        number = await _unitOfWork.PaintingRepo.CreateNewNumberOfPaintingCode(RoundId);

        var code = $"NVX{year}-{levelChar}-{roundCode}-{number:D5}";

        return code;
    }

    #endregion
}