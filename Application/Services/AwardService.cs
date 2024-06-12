using Application.IService;
using Application.IService.ICommonService;
using Application.ViewModels.AwardViewModels;
using AutoMapper;
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

    public async Task<Guid?> AddAward(AddAwardViewModel addAwardViewModel)
    {
        var award = _mapper.Map<Award>(addAwardViewModel);
        award.CreatedBy = _claimsService.GetCurrentUserId();
        award.Status = "ACTIVE";
        await _unitOfWork.AwardRepo.AddAsync(award);

        var check = await _unitOfWork.SaveChangesAsync() > 0;
        var result = _mapper.Map<AddAwardViewModel>(award);
        //view.
        if (check) return award.Id;
        return null;
    }

    #endregion

    #region Get List Award

    public async Task<(List<AwardViewModel>, int)> GetListAward(ListAwardModel listAwardModel)
    {
        var awardList = await _unitOfWork.AwardRepo.GetAllAsync();
        awardList = (List<Award>)awardList.Where(x => x.Status == "ACTIVE");
        var result = _mapper.Map<List<AwardViewModel>>(awardList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listAwardModel.pageSize);
        int? itemsToSkip = (listAwardModel.pageNumber - 1) * listAwardModel.pageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listAwardModel.pageSize)
            .ToList();
        return (result, totalPages);
    }

    #endregion

    #region Delete Award

    public async Task<AwardViewModel> DeleteAward(Guid awardId)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(awardId);
        if (award == null) return null;

        award.Status = "INACTIVE";

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AwardViewModel>(award);
    }

    #endregion

    #region Update Award

    public async Task<UpdateAwardViewModel> UpdateAward(UpdateAwardViewModel updateAward)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(updateAward.Id);
        if (award == null) return null;

        award.Rank = updateAward.Rank;
        award.Quantity = updateAward.Quantity;
        award.Cash = updateAward.Cash;
        award.Artifact = updateAward.Artifact;
        award.Description = updateAward.Description;
        award.EducationalLevelId = updateAward.EducationalLevelId;
        award.UpdatedBy = _claimsService.GetCurrentUserId();
        award.UpdatedTime = _currentTime.GetCurrentTime();


        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UpdateAwardViewModel>(award);
    }

    #endregion


    #region Get Award By Id

    public async Task<AwardViewModel> GetAwardById(Guid awardId)
    {
        var award = await _unitOfWork.AwardRepo.GetByIdAsync(awardId);
        return _mapper.Map<AwardViewModel>(award);
        ;
    }

    #endregion
}