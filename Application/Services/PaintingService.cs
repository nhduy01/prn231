using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.ViewModels.AwardViewModels;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class PaintingService : IPaintingService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PaintingService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration,
        IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Add Painting

    public async Task<Guid?> AddPainting(AddPaintingViewModel addPaintingViewModel)
    {
        var painting = _mapper.Map<Painting>(addPaintingViewModel);
        painting.CreatedBy = _claimsService.GetCurrentUserId();
        painting.Status = "ACTIVE";
        await _unitOfWork.PaintingRepo.AddAsync(painting);

        var check = await _unitOfWork.SaveChangesAsync() > 0;
        var result = _mapper.Map<AddPaintingViewModel>(painting);
        //view.
        if (check) return painting.Id;
        return null;
    }

    #endregion

    #region Get List Painting

    public async Task<(List<PaintingViewModel>, int)> GetListPainting(ListModels listPaintingModel)
    {
        var paintingList = await _unitOfWork.PaintingRepo.GetAllAsync();
        paintingList = (List<Painting>)paintingList.Where(x => x.Status == "ACTIVE");
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

    public async Task<PaintingViewModel> DeletePainting(Guid paintingId)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(paintingId);
        if (painting == null) return null;

        painting.Status = "INACTIVE";

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PaintingViewModel>(painting);
    }

    #endregion

    #region Update Painting

    public async Task<UpdatePaintingViewModel> UpdatePainting(UpdatePaintingViewModel updatePainting)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByIdAsync(updatePainting.Id);
        if (painting == null) return null;

        painting = _mapper.Map<Painting>(updatePainting);

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UpdatePaintingViewModel>(painting);
    }

    #endregion


    #region Get Award By Id

    public async Task<PaintingViewModel> GetPaintingByCode(String code)
    {
        var painting = await _unitOfWork.PaintingRepo.GetByCodeAsync(code);
        return _mapper.Map<PaintingViewModel>(painting);
        ;
    }

    #endregion

    
}