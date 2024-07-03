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

    #region Get By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var result = _awardSchedule.GetListByScheduleId(id);
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