using Application.IService;
using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    #region Login

    [AllowAnonymous]
    [HttpPost]
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid input data. " + string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)),
                RefreshToken = null,
                JwtToken = ""
            };
        var result = request.Role == Role.COMPETITOR.ToString()
            ? await _authenticationService.ValidateCompetitor(request)
            : await _authenticationService.ValidateAccount(request);
        return result;
    }

    #endregion

    #region CreateAccount

    [AllowAnonymous]
    [HttpPost]
    public async Task<RegisterResponse> CreateAccount(CreateAccountRequest account)
    {
        if (!ModelState.IsValid)
            return new RegisterResponse
            {
                Success = false,
                Message = "Invalid input data. " + string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)),
                Data = ""
            };
        return await _authenticationService.CreateAccount(account);
    }

    #endregion

    #region CreateCompetitor

    [AllowAnonymous]
    [HttpPost]
    public async Task<RegisterResponse> CreateCompetitor(CreateCompetitorRequest competitor)
    {
        if (!ModelState.IsValid)
            return new RegisterResponse
            {
                Success = false,
                Message = "Invalid input data. " + string.Join("; ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)),
                Data = ""
            };
        return await _authenticationService.CreateCompetitor(competitor);
    }

    #endregion

    #region ReGenerateJwtToken

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<string>> ReGenerateJwtToken(RefreshTokenRequest token)
    {
        if (!ModelState.IsValid)
            return Unauthorized("Invalid input data. " + string.Join("; ",
                ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
        if (token.Expried < DateTime.Now) return Unauthorized("Token Expried");

        /*var result = token.Role == Role.COMPETITOR.ToString() ?
            await _authenticationService.ValidateCompetitor(request) :
            await _authenticationService.ValidateAccount(request);*/

        var result = await _authenticationService.ReGenerateJwtTokenAccount(token);
        if (result == "") return Unauthorized("Invaild Refresh Token");
        return result;
    }

    #endregion
}