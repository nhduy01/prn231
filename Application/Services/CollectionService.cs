using Application.IService;
using Application.ViewModels.AwardViewModels;
using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;
using WebAPI.IService.ICommonService;

namespace Application.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly IConfiguration _configuration;
        private readonly IClaimsService _claimsService;

        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _claimsService = claimsService;
        }

        #region Add Collection
        public async Task<Guid?> AddCollection(AddCollectionViewModel addCollectionViewModel)
        {
            Collection collection = _mapper.Map<Collection>(addCollectionViewModel);
            collection.CreatedBy = _claimsService.GetCurrentUserId();
            collection.Status = "ACTIVE";
            await _unitOfWork.CollectionRepo.AddAsync(collection);

            var check = await _unitOfWork.SaveChangesAsync() > 0;
            AddCollectionViewModel result = _mapper.Map<AddCollectionViewModel>(collection);
            //view.
            if (check)
            {
                return collection.Id;
            }
            return null;
        }
        #endregion

        #region Delete Collection
        public async Task<CollectionViewModel> DeleteCollection(Guid collectionId)
        {
            var award = await _unitOfWork.CollectionRepo.GetByIdAsync(collectionId);
            if (award == null)
            {
                return null;
            }
            else
            {
                award.Status = "INACTIVE";
                
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<CollectionViewModel>(award);
            }
        }
        #endregion

        #region Update Collection
        public async Task<UpdateCollectionViewModel> UpdateCollection(UpdateCollectionViewModel updateCollection)
        {
            var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(updateCollection.Id);
            if (collection == null)
            {
                return null;
            }
            else
            {
                collection.Name = updateCollection.Name;
                collection.Description = updateCollection.Description;
                collection.Image = updateCollection.Image;

                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<UpdateCollectionViewModel>(collection);
            }
        }
        #endregion

        #region Get Collection By Id
        public async Task<CollectionViewModel> GetCollectionById(Guid collectionId)
        {
            var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(collectionId);
            return _mapper.Map<CollectionViewModel>(collection); ;
        }
        #endregion
    }
}
