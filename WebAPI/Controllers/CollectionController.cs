using Application.BaseModels;
using Application.IService;
using Application.SendModels.Collection;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/collections/")]
public class CollectionController : Controller
{
    private readonly ICollectionService _collectionService;

    public CollectionController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }


    #region Create Collection

    [HttpPost]
    public async Task<IActionResult> CreateCollection(CollectionRequest collection)
    {
        try
        {
            var result = await _collectionService.AddCollection(collection);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Collection Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Create Collection Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Collection

    [HttpPut]
    public async Task<IActionResult> UpdateCollection(UpdateCollectionRequest updateCollectionViewModel)
    {
        try
        {
            var result = await _collectionService.UpdateCollection(updateCollectionViewModel);
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
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Update Fail",
                Errors = ex
            });
        }

    }

    #endregion

    #region Delete Collection

    [HttpPatch]
    public async Task<IActionResult> DeleteCollection(Guid id)
    {
        try
        {
            var result = await _collectionService.DeleteCollection(id);
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

    #region Get Collection By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollectionById([FromRoute]Guid id)
    {
        try
        {
            var result = await _collectionService.GetCollectionById(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Collection Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Collection Fail",
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Painting By Collection

    [HttpGet("Painting/{id}")]
    public async Task<IActionResult> GetPaintingByCollection([FromRoute]Guid id)
    {
        try
        {
            var result = await _collectionService.GetPaintingByCollection(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = "Get Painting Fail",
                Errors = ex
            });
        }
    }

    #endregion
}