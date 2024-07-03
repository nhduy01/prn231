using Application.BaseModels;
using Application.IService;
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

    [HttpGet]
    public async Task<IActionResult> GetAllAward([FromQuery] ListModels listAwardModel)
    {
        try
        {
            var (list, totalPage) = await _accountService.GetListCompetitor(listAwardModel);
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

    #region Get Account

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAwardById(Guid id)
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