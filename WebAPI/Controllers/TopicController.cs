using Application.BaseModels;
using Application.IService;
using Application.SendModels.Topic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/topics/")]
public class TopicController : Controller
{
    private readonly ITopicService _topicService;

    public TopicController(ITopicService topicService)
    {
        _topicService = topicService;
    }

    #region Create Topic

    [HttpPost]
    public async Task<IActionResult> CreateTopic(TopicRequest Topic)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { Success = false, Message = "Invalid input data. " + errorMessages });
            }

            var result = await _topicService.CreateTopic(Topic);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Topic Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Create Topic Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Topic By Page

    [HttpGet]
    public async Task<IActionResult> GetTopicByPage([FromQuery] ListModels listModel)
    {
        try
        {
            var (list, totalPage) = await _topicService.GetListTopic(listModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Topic Success",
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
                Message = "Get Topic Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Topic By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTopicById([FromRoute] Guid id)
    {
        try
        {
            var result = await _topicService.GetTopicById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Topic not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Topic Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Topic Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Topic

    [HttpPut]
    public async Task<IActionResult> UpdateTopic(TopicUpdateRequest updateTopic)
    {
        try
        {
            var result = await _topicService.UpdateTopic(updateTopic);
            if (result == null) return NotFound(new { Success = false, Message = "Topic not found" });
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

    #region Delete Topic

    [HttpPatch]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        try
        {
            var result = await _topicService.DeleteTopic(id);
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