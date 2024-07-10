using Application.BaseModels;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/awardschedules/")]
public class AwardScheduleController : Controller
{
    private readonly IAwardScheduleService _awardSchedule;

    public AwardScheduleController(IAwardScheduleService awardSchedule)
    {
        _awardSchedule = awardSchedule;
    }

    #region Get Award Schedule By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAwardScheduleById(Guid id)
    {
        try
        {
            var result = await _awardSchedule.GetListByScheduleId(id);
            if (result == null) return NotFound(new { Success = false, Message = "Schedule not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Schedule Award Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Schedule Award Fail",
                Errors = ex
            });
        }
    }

    #endregion
}