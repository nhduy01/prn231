using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Award;
using Application.ViewModels.AwardViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class AwardService : IAwardService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AwardService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration,
        IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Add Award

    public async Task<bool> AddAward(AwardRequest addAwardViewModel)
    {
        var award = _mapper.Map<Award>(addAwardViewModel);
        award.Status = AwardStatus.Active.ToString();
        await _unitOfWork.AwardRepo.AddAsync(award);

        return await _unitOfWork.SaveChangesAsync() > 0;

    }

    #endregion

    #region Get List Award

    public async Task<(List<AwardViewModel>, int)> GetListAward(ListModels listAwardModel)
    {
        var awardList = await _unitOfWork.AwardRepo.GetAllAsync();
        awardList = awardList.Where(x => x.Status == AwardStatus.Active.ToString()).ToList();
        var result = _mapper.Map<List<AwardViewModel>>(awardList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listAwardModel.PageSize);
        int? itemsToSkip = (listAwardModel.PageNumber - 1) * listAwardModel.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listAwardModel.PageSize)
            .ToList();
        return (result, totalPages);
    }

    #endregion

    #region Delete Award

    public async Task<bool> DeleteAward(Guid awardId)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(awardId);
        if (award == null) throw new Exception("Khong tim thay Award");

        award.Status = AwardStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Update Award

    public async Task<bool> UpdateAward(UpdateAwardRequest updateAward)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(updateAward.Id);
        if (award == null) throw new Exception("Khong tim thay Award");

        award = _mapper.Map<Award>(updateAward);
        award.UpdatedTime = _currentTime.GetCurrentTime();

       
        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion


    #region Get Award By Id

    public async Task<AwardViewModel> GetAwardById(Guid awardId)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(awardId);
        return _mapper.Map<AwardViewModel>(award);
    }

    #endregion
}