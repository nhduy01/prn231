using System.Collections.Generic;
using Application.IService;
using Application.ViewModels.AwardViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.IService.ICommonService;

namespace Application.Services
{
    public class AwardService : IAwardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly IConfiguration _configuration;
        private readonly IClaimsService _claimsService;

        public AwardService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _claimsService = claimsService;
        }

        public async Task<Guid?> AddAward(AddAwardViewModel addAwardViewModel, Guid Staffid)
        {
            Award award = _mapper.Map<Award>(addAwardViewModel);
            award.Id = Guid.NewGuid();
            award.CreatedBy = _claimsService.GetCurrentUserId();
            award.Status = "ACTIVE";
            await _unitOfWork.AwardRepo.AddAsync(award);

            var check = await _unitOfWork.SaveChangesAsync() > 0;
            AddAwardViewModel result = _mapper.Map<AddAwardViewModel>(award);
            //view.
            if (check)
            {
                return award.Id;
            }
            return null;
        }

        public async Task<(List<AwardViewModel>,int)> GetListAward(ListAwardModel listAwardModel)
        {
            var awardList = await _unitOfWork.AwardRepo.GetAllAsync();
            awardList = (List<Award>)awardList.Where(x => x.Status == "ACTIVE");
            var result = _mapper.Map<List<AwardViewModel>>(awardList);

            var totalPages = (int)Math.Ceiling((double)result.Count / listAwardModel.pageSize);
            int? itemsToSkip = (listAwardModel.pageNumber - 1) * listAwardModel.pageSize;
            result = result.Skip((int)itemsToSkip)
                        .Take((int)listAwardModel.pageSize)
                         .ToList();
            return (result, totalPages);
        }

        public async Task<AwardViewModel> DeleteAward(Guid awardId)
        {
            var award = await _unitOfWork.AwardRepo.GetByIdAsync(awardId);
            if (award == null)
            {
                return null;
            }
            else
            {
                award.Status = "INACTIVE";
                /*bool oot = (updateProduct.OutOfStock.ToString().ToUpper().Equals("TRUE")) ? true : false;*/
                /*product.OutOfStock = oot;*/
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<AwardViewModel>(award);
            }
        }

        public async Task<UpdateAwardViewModel> UpdateAward(UpdateAwardViewModel updateAward, Guid StaffId)
        {
            var award = await _unitOfWork.AwardRepo.GetByIdAsync(updateAward.Id);
            if (award == null)
            {
                return null;
            }
            else
            {
                award.Rank = updateAward.Rank;
                award.Quantity = updateAward.Quantity;
                award.Cash = updateAward.Cash;
                award.Artifact = updateAward.Artifact;
                award.Description = updateAward.Description;
                award.EducationalLevelId = updateAward.EducationalLevelId;
                award.UpdatedBy = StaffId;
                award.UpdatedTime = _currentTime.GetCurrentTime();


                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<UpdateAwardViewModel>(award);
            }
        }

        
    }
}
