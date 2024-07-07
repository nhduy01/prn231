using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BaseModels;
using Application.SendModels.Category;
using Application.ViewModels.CategoryViewModels;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.IService;

public interface ICategoryService
{
    Task<bool> AddCategory(CategoryRequest addCategoryViewModel);
    Task<bool> DeleteCategory(Guid collectionId);
    Task<bool> UpdateCategory(UpdateCategoryRequest updateCategory);
    Task<(List<CategoryViewModel>, int)> ListAllCategory(ListModels listCategoryModel);
    Task<(List<CategoryViewModel>, int)> ListCategoryUnused(ListModels listCategoryModel);
    

}

