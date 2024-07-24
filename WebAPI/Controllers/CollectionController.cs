﻿using Application.BaseModels;
using Application.IService;
using Application.SendModels.Collection;
using Application.Services;
using Domain.Models;
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
            var validationResult = await _collectionService.ValidateCollectionRequest(collection);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                var response = new BaseFailedResponseModel
                {
                    Status = 400,
                    Message = "Validation failed",
                    Result = false,
                    Errors = errors
                };
                return BadRequest(response);
            }
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
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Collection

    [HttpPut]
    public async Task<IActionResult> UpdateCollection(UpdateCollectionRequest updateCollection)
    {
        try
        {
            var validationResult = await _collectionService.ValidateCollectionUpdateRequest(updateCollection);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                var response = new BaseFailedResponseModel
                {
                    Status = 400,
                    Message = "Validation failed",
                    Result = false,
                    Errors = errors
                };
                return BadRequest(response);
            }
            var result = await _collectionService.UpdateCollection(updateCollection);
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
                Message = ex.Message,
                Result = false,
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
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Collection By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCollectionById([FromRoute] Guid id)
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

    #region Get Painting By Collection

    [HttpGet("paintings/{id}")]
    public async Task<IActionResult> GetPaintingByCollection([FromRoute] Guid collectionId,
        [FromQuery] ListModels listPaintingmodel)
    {
        try
        {
            var (list, totalPage) = await _collectionService.GetPaintingByCollection(listPaintingmodel, collectionId);
            if (totalPage < listPaintingmodel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new
                {
                    List = new List<Collection>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion

    #region Get All Collection

    [HttpGet("collections")]
    public async Task<IActionResult> GetAllCollection([FromQuery] ListModels listPaintingmodel)
    {
        try
        {
            var (list, totalPage) = await _collectionService.GetAllCollection(listPaintingmodel);
            if (totalPage < listPaintingmodel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Collection Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new
                {
                    List = new List<Collection>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Collection By AccountId

    [HttpGet("account-id/{id}")]
    public async Task<IActionResult> GetCollectionByAccountId([FromRoute] Guid id,
        [FromQuery] ListModels listPaintingmodel)
    {
        try
        {
            var (list, totalPage) = await _collectionService.GetCollectionByAccountId(listPaintingmodel, id);
            if (totalPage < listPaintingmodel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Collection Success",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new
                {
                    List = new List<Collection>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion

    #region Get 6 Collection tạo bởi Staff (gần nhất)

    [HttpGet("six-staff-collection")]
    public async Task<IActionResult> Get6CollectionCreatedByStaff()
    {
        try
        {
            var result = await _collectionService.Get6StaffCollection();

            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Collection Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new List<Collection>(),
                Errors = ex
            });
        }
    }

    #endregion
}