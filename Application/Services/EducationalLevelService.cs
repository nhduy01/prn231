using Application.BaseModels;
using Application.Common;
using Application.IService;
using Application.SendModels.EducationalLevel;
using Application.SendModels.Round;
using Application.ViewModels.EducationalLevelViewModels;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class EducationalLevelService : IEducationalLevelService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public EducationalLevelService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<bool> CreateEducationalLevel(EducationalLevelRequest EducationalLevel)
    {
        
            var newEducationalLevel = _mapper.Map<EducationalLevel>(EducationalLevel);
            newEducationalLevel.Status = EducationalLevelStatus.Active.ToString();
            await _unitOfWork.EducationalLevelRepo.AddAsync(newEducationalLevel);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get All

    public async Task<(List<EducationalLevelViewModel>, int)> GetListEducationalLevel(ListModels listModels)
    {
        var list = await _unitOfWork.EducationalLevelRepo.GetAllAsync();
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<EducationalLevelViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<EducationalLevelViewModel?> GetEducationalLevelById(Guid id)
    {
        var EducationalLevel = await _unitOfWork.EducationalLevelRepo.GetByIdAsync(id);
        if (EducationalLevel == null) throw new Exception("Khong tim thay EducationalLevel");

        return _mapper.Map<EducationalLevelViewModel>(EducationalLevel);
    }

    #endregion

    #region Update

    public async Task<bool> UpdateEducationalLevel(EducationalLevelUpdateRequest updateEducationalLevel)
    {
        var EducationalLevel = await _unitOfWork.EducationalLevelRepo.GetByIdAsync(updateEducationalLevel.Id);
        if (EducationalLevel == null) throw new Exception("Khong tim thay EducationalLevel");
        _mapper.Map(updateEducationalLevel, EducationalLevel);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Delete

    public async Task<bool> DeleteEducationalLevel(Guid id)
    {
        var EducationalLevel = await _unitOfWork.EducationalLevelRepo.GetByIdAsync(id);
        if (EducationalLevel == null) throw new Exception("Khong tim thay EducationalLevel");
        EducationalLevel.Status = EducationalLevelStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion
}