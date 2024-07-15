using Application.BaseModels;
using Application.IService;
using Application.SendModels.Category;
using Application.SendModels.RoundTopic;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/roundtopics/")]
public class RoundTopicController : ControllerBase
{
    private readonly IRoundTopicService _roundTopicService;

    public RoundTopicController(IRoundTopicService roundTopicService)
    {
        _roundTopicService = roundTopicService;
    }

    #region Add Topic To Round

    [HttpPost]
    public async Task<IActionResult> AddTopicToRound(RoundTopicRequest roundTopicRequest)
    {
        try
        {
            var result = await _roundTopicService.AddTopicToRound(roundTopicRequest);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Add RoundTopic Success",
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

    #region Delete Topic In Round

    [HttpDelete("deleteroundtopic")]
    public async Task<IActionResult> DeleteTopicInRound(RoundTopicDeleteRequest roundTopicDeleteRequest)
    {
        try
        {
            var result = await _roundTopicService.DeleteTopicInRound(roundTopicDeleteRequest);
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

}

