using Application.BaseModels;
using Application.IService;
using Application.SendModels.AccountSendModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/accounts/")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    #region Get All Competitor

    [HttpGet("getallcompetitor")]
    public async Task<IActionResult> GetAllCompetitor([FromQuery] ListModels listCompetitorModel)
    {
        try
        {
            var (list, totalPage) = await _accountService.GetListCompetitor(listCompetitorModel);
            if (totalPage < listCompetitorModel.PageNumber)
            {
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Account Success",
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
                Errors = ex
            });
        }
    }

    #endregion

    #region Get All Examiner

    [HttpGet("getallexaminer")]
    public async Task<IActionResult> GetAllExaminer([FromQuery] ListModels listCompetitorModel)
    {
        try
        {
            var (list, totalPage) = await _accountService.GetListExaminer(listCompetitorModel);
            if (totalPage < listCompetitorModel.PageNumber)
            {
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Over number page"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Account Success",
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
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Account By Id

    [HttpGet("getaccountbyid/{id}")]
    public async Task<IActionResult> GetAccountById(Guid id)
    {
        try
        {
            var result = await _accountService.GetAccountById(id);
            if (result == null)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Account Dont Exist"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Account Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region Get Account By Id

    [HttpGet("getaccountbycode/{code}")]
    public async Task<IActionResult> GetAccountByCode(string code)
    {
        try
        {
            var result = await _accountService.GetAccountByCode(code);
            if (result == null)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Account Dont Exist"
                });
            }
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Get Account Success",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region Update Account

    [HttpPut]
    public async Task<IActionResult> UpdateAccount(AccountUpdateRequest update)
    {
        try
        {
            var result = await _accountService.UpdateAccount(update);
            if (result == null) return NotFound(new { Success = false, Message = "Account not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Result = result,
                Message = "Update Successfully"
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }

    #endregion

    #region Delete

    [HttpDelete]
    public async Task<IActionResult> DeleteRound(Guid id)
    {
        try
        {
            var result = await _accountService.DeleteAccount(id);
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
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,              
                Errors = ex
            });
        }
    }

    #endregion
    
    #region Delete

    [HttpGet("getlistwinnerin3nearestcontest")]
    public async Task<IActionResult> ListAccountHaveAwardIn3NearestContest()
    {
        try
        {
            var result = await _accountService.ListAccountHaveAwardIn3NearestContest();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Result = result,
                Message = "Get List Account Success"
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedResponseModel
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new List<Account>(),
                Errors = ex
            });
        }
    }

    #endregion

}