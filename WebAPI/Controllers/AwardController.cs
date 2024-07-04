using Application.BaseModels;
using Application.IService;
using Application.ViewModels.AwardViewModels;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/awards/")]
public class AwardController : Controller
{
    private readonly IAwardService _awardService;

    public AwardController(IAwardService awardService)
    {
        _awardService = awardService;
    }

    #region Create Award

    [HttpPost]
    public async Task<IActionResult> CreateAward(AddAwardViewModel award)
    {
        try
        {
            if (!Enum.IsDefined(typeof(RankAward), award.Rank))
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Rank is not Exist!"
                });
            }
            var result = await _awardService.AddAward(award);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Award Success",
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

    #region Update Award

    [HttpPut]
    public async Task<IActionResult> UpdateAward(UpdateAwardViewModel updateAward)
    {
        var result = await _awardService.UpdateAward(updateAward);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Update Successfully"
        });
    }

    #endregion

    #region Delete Award

    [HttpPatch]
    public async Task<IActionResult> DeleteAward(Guid id)
    {
        var result = await _awardService.DeleteAward(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Delete Successfully"
        });
    }

    #endregion

    #region Get All Award

    [HttpGet]
    public async Task<IActionResult> GetAllAward([FromQuery] ListModels listAwardModel)
    {
        try
        {
            var (list, totalPage) = await _awardService.GetListAward(listAwardModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Award Success",
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

    #region Get Award By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAwardById(Guid id)
    {
        try
        {
            var result = await _awardService.GetAwardById(id);
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