using Application.IService;
using Application.IService.ICommonService;
using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class CollectionService : ICollectionService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CollectionService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
        IConfiguration configuration, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Add Collection

    public async Task<bool> AddCollection(AddCollectionViewModel addCollectionViewModel)
    {
        var collection = _mapper.Map<Collection>(addCollectionViewModel);
        collection.Status = CollectionStatus.Active.ToString();
        await _unitOfWork.CollectionRepo.AddAsync(collection);

        return await _unitOfWork.SaveChangesAsync() > 0;
        
    }

    #endregion

    #region Delete Collection

    public async Task<bool> DeleteCollection(Guid collectionId)
    {
        var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(collectionId);
        if (collection == null) throw new Exception("Khong tim thay Collection");


        collection.Status = CollectionStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion

    #region Update Collection

    public async Task<bool> UpdateCollection(UpdateCollectionViewModel updateCollection)
    {
        var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(updateCollection.Id);
        if (collection == null) throw new Exception("Khong tim thay Collection"); ;

        /*collection.Name = updateCollection.Name;
        collection.Description = updateCollection.Description;
        collection.Image = updateCollection.Image;*/
        collection = _mapper.Map<Collection>(updateCollection);

        return await _unitOfWork.SaveChangesAsync()>0;

    }

    #endregion

    #region Get Collection By Id

    public async Task<CollectionViewModel> GetCollectionById(Guid collectionId)
    {
        var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(collectionId);
        return _mapper.Map<CollectionViewModel>(collection);
    }

    #endregion

    #region Get Painting By Collection

    public async Task<Collection> GetPaintingByCollection(Guid collectionId)
    {
        var collection = await _unitOfWork.CollectionRepo.GetPaintingByCollectionAsync(collectionId);
        return _mapper.Map<Collection>(collection);
    }

    #endregion
}