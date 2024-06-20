using Application.BaseModels;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }


    #region Get 5 Notification

    [HttpGet("{id}")]
    public async Task<IActionResult> Get5Notification(Guid id)
    {
        try
        {
            var list = await _notificationService.Get5Notification(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Inventory Success",
                Result = new
                {
                    List = list
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

    #region Get Notification By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationById(Guid id)
    {
        try
        {
            var result = await _notificationService.GetNotificationById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Notification not found" });
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

    #region Read Notification

    [HttpPatch]
    public async Task<IActionResult> IsReadNotification(Guid id)
    {
        var result = await _notificationService.ReadNotification(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Successfully"
        });
    }

    #endregion
}