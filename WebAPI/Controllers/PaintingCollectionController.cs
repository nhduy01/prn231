﻿using Application.BaseModels;
using Application.IService;
using Application.SendModels.PaintingCollection;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/paintingcollections/")]
public class PaintingCollectionController : Controller
{
    private readonly IPaintingCollectionService _paintingCollectionService;

    public PaintingCollectionController(IPaintingCollectionService paintingCollectionService)
    {
        _paintingCollectionService = paintingCollectionService;
    }


    #region Add Painting To Collection

    [HttpPost("addpaintingtocollection")]
    public async Task<IActionResult> AddPaintingToCollection(PaintingCollectionRequest addPaintingCollectionViewModel)
    {
        try
        {
            var result = await _paintingCollectionService.AddPaintingToCollection(addPaintingCollectionViewModel);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Painting Collection Success",
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


    #region Delete Painting Collection

    [HttpDelete("deletepaintingcollection/{id}")]
    public async Task<IActionResult> DeletePainting([FromRoute] Guid id)
    {
        try
        {
            var result = await _paintingCollectionService.DeletePaintingInCollection(id);
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