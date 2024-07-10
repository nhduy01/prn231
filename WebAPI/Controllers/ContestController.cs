using Application.BaseModels;
using Application.IRepositories;
using Application.IService;
using Application.SendModels.Contest;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/contests/")]
public class ContestController : Controller
{
    private readonly IContestService _contestService;

    public ContestController(IContestService contestService, IContestRepository contestRepository)
    {
        _contestService = contestService;
    }

    #region Create Contest

    [HttpPost]
    public async Task<IActionResult> CreateContest(ContestRequest contest)
    {
        try
        {
            var result = await _contestService.AddContest(contest);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Award Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Contest

    [HttpPut]
    public async Task<IActionResult> UpdateContest(UpdateContest updateContestViewModel)
    {
        try
        {
            var result = await _contestService.UpdateContest(updateContestViewModel);
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
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }

    #endregion

    #region Delete Contest

    [HttpPatch]
    public async Task<IActionResult> DeleteContest(Guid id)
    {
        try
        {
            var result = await _contestService.DeleteContest(id);
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
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }

    }

    #endregion


    #region Get Contest By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContestById([FromRoute] Guid id)
    {
        try
        {
            var result = await _contestService.GetContestById(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Contest Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = null,
                Errors = ex
            });
        }
    }

    #endregion

    #region Get All Contest

    [HttpGet("getallcontest")]
    public async Task<IActionResult> GetAllContest()
    {
        try
        {
            var result = await _contestService.GetAllContest();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Contest Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = null,
                Errors = ex
            });
        }
    }

    #endregion

    #region Get 5 recent contest year

    [HttpGet("get5recentyear")]
    public async Task<IActionResult> Get5RecentContestYear()
    {
        try
        {
            var result = await _contestService.Get5RecentYear();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get 5 Recent Contest Year Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = null,
                Errors = ex
            });
        }
    }

    #endregion


    #region Get Nearest Contest

    [HttpGet()]
    public async Task<IActionResult> GetNearestContest()
    {
        try
        {
            var result = await _contestService.GetNearestContest();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Contest Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = null,
                Errors = ex
            });
        }
    }

    #endregion
}