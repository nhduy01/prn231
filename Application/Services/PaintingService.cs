using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.SendModels.Painting;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class PaintingService : IPaintingService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PaintingService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
        IConfiguration configuration,
        IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Add Painting

    public async Task<Guid?> AddPainting(PaintingRequest request)
    {
        var painting = _mapper.Map<Painting>(request);
        painting.CreatedBy = _claimsService.GetCurrentUserId();
        painting.Status = PaintingStatus.Draft.ToString();
        await _unitOfWork.PaintingRepo.AddAsync(painting);

        var check = await _unitOfWork.SaveChangesAsync() > 0;
        //view.
        if (check) return painting.Id;
        return null;
    }

    #endregion

    #region Get List Painting

    public async Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel)
    {
        var paintingList = await _unitOfWork.PaintingRepo.GetAllAsync();
        paintingList = (List<Painting>)paintingList.Where(x => x.Status != PaintingStatus.Delete.ToString());
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

    public async Task<PaintingViewModel?> DeletePainting(Guid paintingId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);
        if (painting == null) return null;
        
        if (painting.Status != PaintingStatus.Draft.ToString())
        {
            return null;
        }

        painting.Status = PaintingStatus.Delete.ToString();

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Update Painting

    public async Task<UpdatePaintingViewModel?> UpdatePainting(UpdatePaintingViewModel updatePainting)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(updatePainting.Id);

        if (painting == null) return null;
        
        if (painting.Status != PaintingStatus.Draft.ToString())
        {
            return null;
        }

        painting = _mapper.Map<Painting>(updatePainting);

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UpdatePaintingViewModel>(painting);
    }

    #endregion

    #region Submit Painting

    public async Task<PaintingViewModel?> SubmitPainting(Guid paintingId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);
        if (painting == null) return null;
        
        if (painting.Status != PaintingStatus.Draft.ToString())
        {
            return null;
        }

        painting.Status = PaintingStatus.Submitted.ToString();
        
        painting.SubmittedTimestamp = DateTime.Now;

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Review Decision of Painting

    public async Task<PaintingViewModel?> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(request.Id);
        if (painting == null) return null;
        
        if (painting.Status != PaintingStatus.Submitted.ToString())
        {
            return null;
        }

        if (request.Result == true)
        {
            painting.Status = PaintingStatus.Accepted.ToString();
        }
        else
        {
            painting.Status = PaintingStatus.Rejected.ToString();

        }
        
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
        
        if (painting.Status != PaintingStatus.Accepted.ToString())
        {
            return null;
        }

        if (request.Result == true)
        {
            painting.Status = PaintingStatus.Pass.ToString();
        }
        else
        {
            painting.Status = PaintingStatus.NotPass.ToString();

        }
        
        painting.FinalDecisionTimestamp = DateTime.Now;
        
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Get Painting By Code

    public async Task<PaintingViewModel> GetPaintingByCode(string code)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByCodeAsync(code);
        return _mapper.Map<PaintingViewModel>(painting);
        ;
    }

    #endregion
    
    #region Get Painting By Id

    public async Task<PaintingViewModel> GetPaintingById(Guid id)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(id);
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region List 20 Wining Painting

    public async Task<PaintingViewModel> List20WiningPainting()
    {
        var painting = await _unitOfWork.PaintingRepo.List20WiningPaintingAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion
}