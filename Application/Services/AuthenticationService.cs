using System.Security.Cryptography;
using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.AuthenticationViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthentication _authentication;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public AuthenticationService(IUnitOfWork unitOfWork, IAuthentication authentication, IMapper mapper,
        IMailService mailService, IClaimsService claimsService)
    {
        _claimsService = claimsService;
        _mailService = mailService;
        _authentication = authentication;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    #region Login

    public async Task<LoginResponse> Login(LoginRequest accountLogin)
    {
        var response = new LoginResponse();
        var account = await _unitOfWork.AccountRepo.Login(accountLogin.Username);
        //check null
        if (account != null)
        {
            //Verify Password
            var check = _authentication.Verify(account.Password, accountLogin.Password);
            if (check is true)
            {
                response.Success = true;
                response.Message = "Login Success";
                response.JwtToken =_authentication.GenerateToken(account.UserName, account.Id.ToString(), account.Role);
                response.RefreshToken = new RefreshToken();
                response.RefreshToken.Token = RefreshToken();

                //add refresh token to DB
                account.RefreshToken = response.RefreshToken.Token;
                _unitOfWork.AccountRepo.Update(account);
                await _unitOfWork.SaveChangesAsync();

                return response;
            }

            response.Success = false;
            response.Message = "Invalid Password";
            return response;
        }

        response.Success = false;
        response.Message = "Username Not Exist";
        return response;
    }

    #endregion

    #region Create Account

    public async Task<RegisterResponse> CreateAccount(CreateAccountRequest account)
    {
        var response = new RegisterResponse();
        var a = _mapper.Map<Account>(account);
        if (!Enum.IsDefined(typeof(Role), account.Role))
        {
            response.Message = "Role is not Exist!";
            response.Success = false;
            return response;
        }
        if (await _unitOfWork.AccountRepo.CheckDuplicate(account.Email, account.Phone, account.UserName))
        {
            response.Message = "Email or Phone or UserName is Exist !";
            response.Success = false;
            return response;
        }

        //if not exist
        a.Password = _authentication.Hash(account.Password);
        a.Status = AccountStatus.Active.ToString();

        await _unitOfWork.AccountRepo.AddAsync(a);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            response.Message = "Create Fail !";
            response.Success = true;
            return response;
        }

        response.Message = "Create Success !";
        response.Success = true;

        var mail = new MailModel();
        mail.To = a.Email;
        mail.Subject = "Active Account";
        mail.Body = $"Link ID {a.Id}";
        await _mailService.SendEmail(mail);

        return response;
    }

    #endregion

    #region ReGenerate JwtToken Account

    public async Task<string> ReGenerateJwtToken(RefreshTokenRequest refreshToken)
    {
        var account = await _unitOfWork.AccountRepo.GetByIdAsync(refreshToken.Id);
        if (account != null)
            return _authentication.GenerateToken(account.UserName, account.Id.ToString(), account.Role);
        return "";
    }

    #endregion

    #region Logout Account

    public async Task<bool> Logout(Guid id)
    {
        var account = await _unitOfWork.AccountRepo.GetByIdAsync(id);
        if (account != null)
        {
            account.RefreshToken = "";
            return true;
        }

        return false;
    }

    #endregion

    #region Refresh Token

    public string RefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    #endregion
    
    public async Task<bool?> VerifyEmail(Guid id)
    {
        var account = await _unitOfWork.AccountRepo.GetByIdAsync(id);
        if (account == null) return false;
        account.Status = AccountStatus.Active.ToString();
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}