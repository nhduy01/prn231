using Application.BaseModels;
using Application.IService;
using Application.SendModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/posts/")]
public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    #region Create Post

    [HttpPost]
    public async Task<IActionResult> CreatePost(PostRequest Post)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(new { Success = false, Message = "Invalid input data. " + errorMessages });
            }

            var result = await _postService.CreatePost(Post);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Post Success",
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

    #region Get 10 Post

    [HttpGet]
    public async Task<IActionResult> Get10Post()
    {
        try
        {
            var result = await _postService.Get10Post();
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
    
    #region Get Post By Page

    [HttpGet]
    public async Task<IActionResult> GetPostByPage([FromQuery] ListModels listModel)
    {
        try
        {
            var (list, totalPage) = await _postService.GetListPost(listModel);
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

    #region Get Post By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        try
        {
            var result = await _postService.GetPostById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Post not found" });
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

    #region Update Post

    [HttpPut]
    public async Task<IActionResult> UpdatePost(PostUpdateRequest updatePost)
    {
        var result = await _postService.UpdatePost(updatePost);
        if (result == null) return NotFound(new { Success = false, Message = "Post not found" });
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Update Successfully"
        });
    }

    #endregion

    #region Delete Post

    [HttpPatch]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var result = await _postService.DeletePost(id);
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