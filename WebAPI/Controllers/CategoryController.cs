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
                Message = "Create Category Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Category

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest updateCategoryViewModel)
    {
        try
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
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Update Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Delete Category

    [HttpPatch]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
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
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Delete Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region List All Category

    [HttpGet("getallcategory")]
    public async Task<IActionResult> ListAllCategory([FromQuery] ListModels listCategoryModel)
    {
        try
        {
            var (list, totalPage) = await _categoryService.ListAllCategory(listCategoryModel);
            if (totalPage < listCategoryModel.PageNumber)
            {
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Category Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region List Category Unused

    [HttpGet("getcategoryunused")]
    public async Task<IActionResult> ListCategoryUnused([FromQuery] ListModels listCategoryModel)
    {
        try
        {
            var (list, totalPage) = await _categoryService.ListCategoryUnused(listCategoryModel);
            if (totalPage < listCategoryModel.PageNumber)
            {
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
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
            var (list, totalPage) = await _categoryService.ListPostByCategoryId(listCategoryModel,categoryId);
            if (totalPage < listCategoryModel.PageNumber)
            {
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Category Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
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

