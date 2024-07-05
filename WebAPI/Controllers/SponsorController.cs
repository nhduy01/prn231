using Application.BaseModels;
using Application.IService;
using Infracstructures.SendModels.Sponsor;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/sponsors/")]
public class SponsorController : Controller
{
    private readonly ISponsorService _sponsorService;

    public SponsorController(ISponsorService sponsorService)
    {
        _sponsorService = sponsorService;
    }


    #region Create sponsor

    [HttpPost]
    public async Task<IActionResult> CreateSponsor(SponsorRequest sponsor)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { Success = false, Message = "Invalid input data. " + errorMessages });
            }

            var result = await _sponsorService.CreateSponsor(sponsor);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create sponsor Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Create sponsor Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Get sponsor By Page

    [HttpGet]
    public async Task<IActionResult> GetSponsorByPage([FromQuery] ListModels listModel)
    {
        try
        {
            var (list, totalPage) = await _sponsorService.GetListSponsor(listModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Sponsor Success",
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
                Message = "Get Sponsor Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Sponsor By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetsponsorById([FromRoute] Guid id)
    {
        try
        {
            var result = await _sponsorService.GetSponsorById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Sponsor not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Sponsor Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Sponsor Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Update sponsor

    [HttpPut]
    public async Task<IActionResult> UpdateSponsor(SponsorUpdateRequest updatesponsor)
    {
        try
        {
            var result = await _sponsorService.UpdateSponsor(updatesponsor);
            if (result == null) return NotFound(new { Success = false, Message = "Sponsor not found" });
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

    #region Delete sponsor

    [HttpPatch]
    public async Task<IActionResult> Deletesponsor(Guid id)
    {
        try
        {
            var result = await _sponsorService.DeleteSponsor(id);
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
}