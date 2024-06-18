using Application.BaseModels;
using Application.IService;
using Application.SendModels.Round;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoundController : Controller
{
    private readonly IRoundService _roundService;

    public RoundController(IRoundService roundService)
    {
        _roundService = roundService;
    }
    
        #region Create Round

    [HttpPost]
    public async Task<IActionResult> CreateRound(RoundRequest Round)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { Success = false, Message = "Invalid input data. " + errorMessages });
            }

            var result = await _roundService.CreateRound(Round);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Round Success",
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

    #region Get Round By Page

    [HttpGet]
    public async Task<IActionResult> GetRoundByPage([FromQuery] ListModels listModel)
    {
        try
        {
            var (list, totalPage) = await _roundService.GetListRound(listModel);
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

    #region Get Round By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoundById(Guid id)
    {
        try
        {
            var result = await _roundService.GetRoundById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Round not found" });
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

    #region Update Round

    [HttpPut]
    public async Task<IActionResult> UpdateRound(RoundUpdateRequest updateRound)
    {
        var result = await _roundService.UpdateRound(updateRound);
        if (result == null) return NotFound(new { Success = false, Message = "Round not found" });
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Update Successfully"
        });
    }

    #endregion

    #region Delete Round

    [HttpPatch]
    public async Task<IActionResult> DeleteRound(Guid id)
    {
        var result = await _roundService.DeleteRound(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Delete Successfully"
        });
    }

    #endregion
}