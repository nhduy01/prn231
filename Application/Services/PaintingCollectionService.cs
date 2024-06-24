using Application.IService;
using Application.IService.ICommonService;
using Application.ViewModels.PaintingCollectionViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class PaintingCollectionService : IPaintingCollectionService
{
    private readonly IAuthentication _authentication;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public PaintingCollectionService(IUnitOfWork unitOfWork, IAuthentication authentication, IMapper mapper,
        IMailService mailService, IClaimsService claimsService)
    {
        _claimsService = claimsService;
        _mailService = mailService;
        _authentication = authentication;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> AddPaintingToCollection(AddPaintingCollectionViewModel addPaintingCollectionViewModel)
    {
        var paintingCollection = _mapper.Map<PaintingCollection>(addPaintingCollectionViewModel);
        await _unitOfWork.PaintingCollectionRepo.AddAsync(paintingCollection);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletePaintingInCollection(Guid paintingcollectionId)
    {
        var paintingcollection = await _unitOfWork.PaintingCollectionRepo.GetByIdAsync(paintingcollectionId);
        if (paintingcollection == null) throw new Exception("Khong tim thay PaintingCollection");
        await _unitOfWork.PaintingCollectionRepo.DeleteAsync(paintingcollection);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}