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
using Domain.Enums;
using Application.SendModels.Category;

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

        public async Task<bool> AddCategory(CategoryRequest addCategoryViewModel)
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

        public async Task<bool> UpdateCategory(UpdateCategoryRequest updateCategory)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(updateCategory.Id);
            if (category == null) throw new Exception("Khong tim thay Category");
            
            _mapper.Map(updateCategory, category);

            category.UpdatedTime = _currentTime.GetCurrentTime();
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region List All Category

        public async Task<(List<CategoryViewModel>, int)> ListCategory(ListModels listCategoryModel)
        {
            var list = await _unitOfWork.CategoryRepo.GetAllAsync();
            if (list.Count == 0) throw new Exception("Khong tim thay Category nao");
            var result =  _mapper.Map<List<CategoryViewModel>>(list);

            var totalPages = (int)Math.Ceiling((double)result.Count / listCategoryModel.PageSize);
            int? itemsToSkip = (listCategoryModel.PageNumber - 1) * listCategoryModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listCategoryModel.PageSize)
                .ToList();
            return (result, totalPages);
        }

        #endregion

        #region List All Category

        public async Task<List<CategoryViewModel>> ListAllCategory()
        {
            var list = await _unitOfWork.CategoryRepo.GetAllAsync();
            if (list.Count == 0) throw new Exception("Khong tim thay Category nao");
            var result = _mapper.Map<List<CategoryViewModel>>(list);

            return result;
        }

#endregion

        #region List Category Unused With Pagination

        public async Task<(List<CategoryViewModel>, int)> ListCategoryUnused(ListModels listCategoryModel)
        {
            var list = await _unitOfWork.CategoryRepo.GetCategoryUnused();
            if (list.Count == 0) throw new Exception("Khong co Category nao dang khong duoc su dung");
            var result = _mapper.Map<List<CategoryViewModel>>(list);

            var totalPages = (int)Math.Ceiling((double)result.Count / listCategoryModel.PageSize);
            int? itemsToSkip = (listCategoryModel.PageNumber - 1) * listCategoryModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listCategoryModel.PageSize)
                .ToList();
            return (result, totalPages);
        }

        #endregion


        #region List Category Used With Pagination

        public async Task<(List<CategoryViewModel>, int)> ListCategoryUsed(ListModels listCategoryModel)
        {
            var list = await _unitOfWork.CategoryRepo.GetCategoryUsed();
            if (list.Count == 0) throw new Exception("Khong co Category nao dang duoc su dung");
            var result = _mapper.Map<List<CategoryViewModel>>(list);

            var totalPages = (int)Math.Ceiling((double)result.Count / listCategoryModel.PageSize);
            int? itemsToSkip = (listCategoryModel.PageNumber - 1) * listCategoryModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listCategoryModel.PageSize)
                .ToList();
            return (result, totalPages);
        }

        #endregion

        #region List All Category Unused 

        public async Task<List<CategoryViewModel>> ListAllCategoryUnused()
        {
            var list = await _unitOfWork.CategoryRepo.GetCategoryUnused();
            if (list.Count == 0) throw new Exception("Khong co Category nao dang khong duoc su dung");
            var result = _mapper.Map<List<CategoryViewModel>>(list);
            return result;
        }

        #endregion


        #region List All Category Used With Pagination

        public async Task<List<CategoryViewModel>> ListAllCategoryUsed()
        {
            var list = await _unitOfWork.CategoryRepo.GetCategoryUsed();
            if (list.Count == 0) throw new Exception("Khong co Category nao dang duoc su dung");
            var result = _mapper.Map<List<CategoryViewModel>>(list);
            return result;
        }

        #endregion
    }


}
