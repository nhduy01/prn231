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
using Domain.Enums;

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
            category.Status = CategoryStatus.Unused.ToString();

            await _unitOfWork.CategoryRepo.AddAsync(category);

            return await _unitOfWork.SaveChangesAsync() > 0;

        }

        #endregion

        #region Delete Category

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            if (category == null) throw new Exception("Khong tim thay Category");
            if (category.Status == CategoryStatus.Unused.ToString())
            {
                await _unitOfWork.CategoryRepo.DeleteAsync(category);
            }
            else
            {
                category.Status = CategoryStatus.Deleted.ToString();
            }

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region Update Category

        public async Task<bool> UpdateCategory(UpdateCategoryViewModel updateCategory)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(updateCategory.Id);
            if (category == null) throw new Exception("Khong tim thay Category"); 

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

        #region List Category Unused

        public async Task<(List<CategoryViewModel>, int)> ListCategoryUnused(ListModels listCategoryModel)
        {
            var result = _mapper.Map<List<CategoryViewModel>>(_unitOfWork.CategoryRepo.GetCategoryUnused);

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
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            if (category == null) throw new Exception("Khong tim thay Category");

            var result = _mapper.Map<List<PostViewModel>>(_unitOfWork.PostRepo.GetPostByCategory(categoryId));

            #region pagination
            var totalPages = (int)Math.Ceiling((double)result.Count / listPostModel.PageSize);
            int? itemsToSkip = (listPostModel.PageNumber - 1) * listPostModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listPostModel.PageSize)
                .ToList();
            #endregion

            return (result, totalPages);
        }

        #endregion


    }


}
