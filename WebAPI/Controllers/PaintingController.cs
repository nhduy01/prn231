using Application.BaseModels;
using Application.IService;
using Application.Services;
using Application.ViewModels.AwardViewModels;
using Application.ViewModels.CollectionViewModels;
using Application.ViewModels.PaintingViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaintingController : Controller
{
    private readonly IPaintingService _paintingService;

    public PaintingController(IPaintingService paintingService)
    {
        _paintingService = paintingService;
    }


    #region Create Painting

    [HttpPost]
    public async Task<IActionResult> CreatePainting(AddPaintingViewModel painting)
    {
        try
        {
            var result = await _paintingService.AddPainting(painting);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Painting Success",
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

    #region Update Painting

    [HttpPut]
    public async Task<IActionResult> UpdatePainting(UpdatePaintingViewModel updatePaintingViewModel)
    {
        var result = await _paintingService.UpdatePainting(updatePaintingViewModel);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Update Successfully"
        });
    }

    #endregion

    #region Delete Painting

    [HttpPatch]
    public async Task<IActionResult> DeletePainting(Guid id)
    {
        var result = await _paintingService.DeletePainting(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Delete Successfully"
        });
    }

    #endregion

    #region Get Painting By Code

    [HttpGet("code")]
    public async Task<IActionResult> GetPaintingByCode(string code)
    {
        try
        {
            var result = await _paintingService.GetPaintingByCode(code);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
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

    #region Get All Painting

    [HttpGet("list")]
    public async Task<IActionResult> GetAllAward([FromQuery] ListModels listPaintingModel)
    {
        try
        {
            var (list, totalPage) = await _paintingService.GetListPainting(listPaintingModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Inventory Success",
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

    #region List 20 Wining Painting

    [HttpGet("list20")]
    public async Task<IActionResult> List20WiningPainting()
    {
        try
        {
            var result = await _paintingService.List20WiningPainting();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Inventory Success",
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