﻿using Application.BaseModels;
using Application.IService;
using Application.SendModels.Painting;
using Application.SendModels.Topic;
using Application.Services;
using Domain.Models;
using Infracstructures.SendModels.Painting;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/paintings/")]
public class PaintingController : Controller
{
    private readonly IPaintingService _paintingService;

    public PaintingController(IPaintingService paintingService)
    {
        _paintingService = paintingService;
    }


    #region Draft Painting For Preliminary Round

    [HttpPost("draft-first-round")]
    public async Task<IActionResult> DraftPaintingForPreliminaryRound(CompetitorCreatePaintingRequest paintingrequest)
    {
        var validationResult = await _paintingService.ValidateCompetitorCreateRequest(paintingrequest);
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
        try
        {
            var result = await _paintingService.DraftPaintingForPreliminaryRound(paintingrequest);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Draft Painting Success",
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

    #region Submit Painting For Preliminary Round

    [HttpPost("submit-first-round")]
    public async Task<IActionResult> SubmitPaintingForPreliminaryRound(
        CompetitorCreatePaintingRequest paintingRequest)
    {
        try
        {
            var validationResult = await _paintingService.ValidateCompetitorCreateRequest(paintingRequest);
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
            var result = await _paintingService.SubmitPaintingForPreliminaryRound(paintingRequest);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Submit Painting Success",
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

    #region Staff Submit Painting For Preliminary Round

    [HttpPost("submit-first-round-competitor")]
    public async Task<IActionResult> SubmitPaintingForPreliminaryRoundForCompetitor(
        StaffCreatePaintingRequest staffCreatePainting)
    {
        try
        {
            var validationResult = await _paintingService.ValidateStaffCreateRequest(staffCreatePainting);
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
            var result = await _paintingService.StaffSubmitPaintingForPreliminaryRound(staffCreatePainting);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Submit Painting Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedResponseModel
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Errors = ex,
                Result = false
            });
        }
    }

    #endregion

    #region Staff Submit Painting For Final Round

    [HttpPost("create-final-round-painting")]
    public async Task<IActionResult> CreatePaintingForFinalRound(StaffCreatePaintingFinalRoundRequest request)
    {
        try
        {
            //Chưa validate
            var result = await _paintingService.StaffSubmitPaintingForFinalRound(request);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });

            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Create Painting For Final Round Success",
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

    #region Update Painting

    [HttpPut]
    public async Task<IActionResult> UpdatePainting(UpdatePaintingRequest updatePainting)
    {
        try
        {
            var validationResult = await _paintingService.ValidateUpdatePaintingRequest(updatePainting);
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
            var result = await _paintingService.UpdatePainting(updatePainting);
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

    #region Delete Painting

    [HttpPatch]
    public async Task<IActionResult> DeletePainting(Guid id)
    {
        try
        {
            var result = await _paintingService.DeletePainting(id);
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

    /*#region Submitted Painting

    [HttpPost("submit")]
    public async Task<IActionResult> SubmittedPainting(Guid id)
    {
        var result = await _paintingService.SubmitPainting(id);
        if (result == null) return NotFound();
        return Ok(new BaseResponseModel
        {
            Status = Ok().StatusCode,
            Result = result,
            Message = "Delete Successfully"
        });
    }

    #endregion*/

    #region Review Decision of Painting

    [HttpPatch("review")]
    public async Task<IActionResult> ReviewDecisionOfPainting(PaintingUpdateStatusRequest request)
    {
        try
        {
            var validationResult = await _paintingService.ValidatePaintingUpdateStatusRequest(request);
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
            var result = await _paintingService.ReviewDecisionOfPainting(request);
            if (result == null) return NotFound();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Result = result,
                Message = "Review Successfully"
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

    #region Final Decision of Painting

    [HttpPatch("final-decision")]
    public async Task<IActionResult> FinalDecisionOfPainting(PaintingUpdateStatusRequest request)
    {
        try
        {
            var validationResult = await _paintingService.ValidatePaintingUpdateStatusRequest(request);
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
            var result = await _paintingService.FinalDecisionOfPainting(request);
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

    #region Get Painting By Code

    [HttpGet("{code}")]
    public async Task<IActionResult> GetPaintingByCode([FromRoute] string code)
    {
        try
        {
            var result = await _paintingService.GetPaintingByCode(code);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
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

    #region Get Painting By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaintingById([FromRoute] Guid id)
    {
        try
        {
            var result = await _paintingService.GetPaintingById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Painting not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
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

    #region Get All Painting

    [HttpGet]
    public async Task<IActionResult> GetAllAward([FromQuery] ListModels listPaintingModel)
    {
        try
        {
            var (list, totalPage) = await _paintingService.GetListPainting(listPaintingModel);
            if (totalPage < listPaintingModel.PageNumber)
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
                    List = new List<Painting>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion

    #region List 16 Wining Painting

    [HttpGet("list-16-winning-paintings")]
    public async Task<IActionResult> List16WiningPainting()
    {
        try
        {
            var result = await _paintingService.List16WiningPainting();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Painting Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new List<Painting>(),
                Errors = ex
            });
        }
    }

    #endregion

    #region List Painting By Account Id

    [HttpGet("account-id/{id}")]
    public async Task<IActionResult> ListPaintingByAccountId([FromQuery] ListModels listPaintingModel,
        [FromRoute] Guid id)
    {
        try
        {
            var (list, totalPage) = await _paintingService.ListPaintingByAccountId(id, listPaintingModel);
            if (totalPage < listPaintingModel.PageNumber)
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
                    List = new List<Painting>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion

    #region Filter Painting

    [HttpPost("filter-painting")]
    public async Task<IActionResult> ListPaintingByAccountId(FilterPaintingRequest filterPainting,
        [FromQuery] ListModels listPaintingModel)
    {
        try
        {
            var validationResult = await _paintingService.ValidateFilterPaintingRequest(filterPainting);
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
            var (list, totalPage) = await _paintingService.FilterPainting(filterPainting, listPaintingModel);
            if (totalPage < listPaintingModel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Filter Painting Success",
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
                    List = new List<Painting>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }

    #endregion
}