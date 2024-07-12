using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BaseModels;
using Application.SendModels.Category;
using Application.ViewModels.CategoryViewModels;

namespace Application.IService;

public interface ICategoryService
{
    Task<bool> AddCategory(CategoryRequest addCategoryViewModel);
    Task<bool> DeleteCategory(Guid collectionId);
    Task<bool> UpdateCategory(UpdateCategoryRequest updateCategory);
    Task<(List<CategoryViewModel>, int)> ListCategory(ListModels listCategoryModel);
    Task<List<CategoryViewModel>> ListAllCategory();
    Task<(List<CategoryViewModel>, int)> ListCategoryUnused(ListModels listCategoryModel);
    Task<(List<CategoryViewModel>, int)> ListCategoryUsed(ListModels listCategoryModel);
    Task<List<CategoryViewModel>> ListAllCategoryUnused();
    Task<List<CategoryViewModel>> ListAllCategoryUsed();



}

