using Application.BaseModels;
using Application.IService;
using Application.ViewModels.SponsorViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.SendModels.Sponsor;

namespace Application.Services;

public class SponsorService : ISponsorService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public SponsorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreateSponsor(SponsorRequest sponsor)
    {
        var newSponsor = _mapper.Map<Sponsor>(sponsor);
        newSponsor.Status = SponsorStatus.Active.ToString();
        await _unitOfWork.SponsorRepo.AddAsync(newSponsor);
        await _unitOfWork.SaveChangesAsync();
        return newSponsor.Id;
    }

    #endregion

    #region Get All

    public async Task<(List<SponsorViewModel>, int)> GetListSponsor(ListModels listModels)
    {
        var list = await _unitOfWork.SponsorRepo.GetAllAsync();
        list = (List<Sponsor>)list.Where(x => x.Status == "ACTIVE");

        var result = new List<Sponsor>();

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<SponsorViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<SponsorViewModel?> GetSponsorById(Guid id)
    {
        var sponsor = await _unitOfWork.SponsorRepo.GetByIdAsync(id);
        if (sponsor == null) return null;
        return _mapper.Map<SponsorViewModel>(sponsor);
    }

    #endregion

    #region Update

    public async Task<SponsorViewModel?> UpdateSponsor(SponsorUpdateRequest updateSponsor)
    {
        var sponsor = await _unitOfWork.SponsorRepo.GetByIdAsync(updateSponsor.Id);
        if (sponsor == null) return null;

        _mapper.Map(updateSponsor, sponsor);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<SponsorViewModel>(sponsor);
    }

    #endregion

    #region Delete

    public async Task<bool?> DeleteSponsor(Guid id)
    {
        var sponsor = await _unitOfWork.SponsorRepo.GetByIdAsync(id);
        if (sponsor == null) return false;

        sponsor.Status = "INACTIVE";
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
}