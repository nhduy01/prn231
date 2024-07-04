using Application.BaseModels;
using Application.IService;
using Application.SendModels.Category;
using Application.Services;
using Application.ViewModels.CategoryViewModels;
using Application.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/categories/")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    #region Create Category

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryRequest category)
    {
        try
        {
            var result = await _categoryService.AddCategory(category);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Category Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Category

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest updateCategoryViewModel)
    {
        var result = await _categoryService.UpdateCategory(updateCategoryViewModel);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Update Successfully"
        });
    }

    #endregion

    #region Delete Category

    [HttpPatch]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _categoryService.DeleteCategory(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Delete Successfully"
        });
    }

    #endregion

    #region List All Category

    [HttpGet("getallcategory")]
    public async Task<IActionResult> ListAllCategory([FromRoute] ListModels listCategoryModel)
    {
        try
        {
            var result = await _categoryService.ListAllCategory(listCategoryModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region List All Category

    [HttpGet("getcategoryunused")]
    public async Task<IActionResult> ListCategoryUnused([FromRoute] ListModels listCategoryModel)
    {
        try
        {
            var result = await _categoryService.ListCategoryUnused(listCategoryModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region List Post By Category Id

    [HttpGet("getpostbycategory/{id}")]
    public async Task<IActionResult> ListPostByCategoryId([FromRoute] Guid categoryId , ListModels listCategoryModel)
    {
        try
        {
            var result = await _categoryService.ListPostByCategoryId(listCategoryModel,categoryId);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion
}

