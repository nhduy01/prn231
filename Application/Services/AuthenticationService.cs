using System.Security.Cryptography;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthentication _authentication;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(IUnitOfWork unitOfWork, IAuthentication authentication, IMapper mapper)
    {
        _authentication = authentication;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LoginResponse> ValidateAccount(LoginRequest accountLogin)
    {
        var response = new LoginResponse();
        var account = await _unitOfWork.AccountRepo.Login(accountLogin.UserName);
        //check null
        if (account != null)
        {
            //Verify Password
            var check = _authentication.Verify(account.Password, accountLogin.Password);
            if (check is true)
            {
                response.Success = true;
                response.Message = "Login Success";
                response.JwtToken =
                    _authentication.GenerateToken(account.LastName, account.Id.ToString(), account.Role);
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

    public async Task<string> ReGenerateJwtTokenAccount(string refreshToken)
    {
        var account = await _unitOfWork.AccountRepo.GetByRefreshToken(refreshToken);
        if (account != null)
            return _authentication.GenerateToken(account.LastName, account.Id.ToString(), account.Role);
        return "";
    }

    public async Task<LoginResponse> ValidateCompetitor(LoginRequest accountLogin)
    {
        var response = new LoginResponse();

        var competitor = await _unitOfWork.CompetitorRepo.Login(accountLogin.UserName);

        //check null
        if (competitor != null)
        {
            //Verify Password
            var check = _authentication.Verify(competitor.Password, accountLogin.Password);
            if (check is true)
            {
                response.Success = true;
                response.Message = "Login Success";
                response.JwtToken = _authentication.GenerateToken(competitor.LastName, competitor.Id.ToString(),
                    Role.COMPETITOR.ToString());
                response.RefreshToken = new RefreshToken();
                response.RefreshToken.Token = RefreshToken();

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


    public async Task<RegisterResponse> CreateCompetitor(CreateCompetitorRequest competitor)
    {
        var response = new RegisterResponse();
        var c = _mapper.Map<Competitor>(competitor);
        if (await _unitOfWork.CompetitorRepo.CheckDuplicate(competitor.Email, competitor.Phone))
        {
            response.Message = "Email or Phone is Exist !";
            response.Success = false;
            return response;
        }

        //if not exist
        c.Password = _authentication.Hash(competitor.Password);
        c.Status = AccountStatus.INACTIVE.ToString();
        c.CreatedTime = DateTime.Now;

        await _unitOfWork.CompetitorRepo.AddAsync(c);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            response.Message = "Create Fail !";
            response.Success = true;
            return response;
        }

        response.Message = "Create Success !";
        response.Success = true;
        return response;
    }

    public async Task<RegisterResponse> CreateAccount(CreateAccountRequest account)
    {
        var response = new RegisterResponse();
        var a = _mapper.Map<Account>(account);
        if (await _unitOfWork.AccountRepo.CheckDuplicate(account.Email, account.Phone))
        {
            response.Message = "Email or Phone is Exist !";
            response.Success = false;
            return response;
        }

        //if not exist
        a.Password = _authentication.Hash(account.Password);
        a.Status = AccountStatus.INACTIVE.ToString();

        await _unitOfWork.AccountRepo.AddAsync(a);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        Console.WriteLine(a.Id);

        if (check is false)
        {
            response.Message = "Create Fail !";
            response.Success = true;
            return response;
        }

        response.Message = "Create Success !";
        response.Success = true;
        return response;
    }

    public string RefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}