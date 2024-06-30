using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.ICommonService;
using Application.IService;
using AutoMapper;
using Infracstructures;
using Microsoft.Extensions.Configuration;
using Application.ViewModels.CollectionViewModels;
using Domain.Models;
using Application.ViewModels.CategoryViewModels;
using Application.ViewModels.AwardViewModels;
using Application.BaseModels;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IClaimsService _claimsService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
            IConfiguration configuration, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _claimsService = claimsService;
        }

        #region Add Category

        public async Task<bool> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            var category = _mapper.Map<Category>(addCategoryViewModel);

            await _unitOfWork.CategoryRepo.AddAsync(category);

            return await _unitOfWork.SaveChangesAsync() > 0;

        }

        #endregion

        #region Delete Category

        public async Task<bool> DeleteCategory(Guid collectionId)
        {
            var collection = await _unitOfWork.CollectionRepo.GetByIdAsync(collectionId);
            if (collection == null) throw new Exception("Khong tim thay Collection");
            await _unitOfWork.CollectionRepo.DeleteAsync(collection);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region Update Category

        public async Task<bool> UpdateCategory(UpdateCategoryViewModel updateCategory)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(updateCategory.Id);
            if (category == null) throw new Exception("Khong tim thay Collection"); ;

            category = _mapper.Map<Category>(updateCategory);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region List All Category

        public async Task<(List<CategoryViewModel>, int)> ListAllCategory(ListModels listCategoryModel)
        {
            var result =  _mapper.Map<List<CategoryViewModel>>(_unitOfWork.CategoryRepo.GetAllAsync());

            var totalPages = (int)Math.Ceiling((double)result.Count / listCategoryModel.PageSize);
            int? itemsToSkip = (listCategoryModel.PageNumber - 1) * listCategoryModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listCategoryModel.PageSize)
                .ToList();
            return (result, totalPages);
        }

        #endregion

        #region List Post By Category Id

        public async Task<(List<PostViewModel>, int)> ListPostByCategoryId(ListModels listPostModel,Guid categoryId)
        {
            var result = _mapper.Map<List<PostViewModel>>(_unitOfWork.PostRepo.GetPostByCategory(categoryId));

            var totalPages = (int)Math.Ceiling((double)result.Count / listPostModel.PageSize);
            int? itemsToSkip = (listPostModel.PageNumber - 1) * listPostModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listPostModel.PageSize)
                .ToList();
            return (result, totalPages);
        }


        #endregion
    }


}
