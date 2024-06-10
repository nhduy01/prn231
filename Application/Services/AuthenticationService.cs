using Application.IService;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.Authentication;
using Infracstructures.SendModels.Authentication;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthentication _authentication;
    private readonly IMapper _mapper;

    public AuthenticationService(IUnitOfWork unitOfWork, IAuthentication authentication, IMapper mapper)
    {
        _authentication = authentication;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LoginResponse> ValidateAccount(RequestLogin accountLogin)
    {
        var response = new LoginResponse();
        var account = await _unitOfWork.AccountRepo.Login(accountLogin.UserName);
        //check null
        if (account != null)
        {
            //Verify Password
            Boolean check = _authentication.Verify(account.Password, accountLogin.Password);
            if (check is true)
            {
                response.Success = true;
                response.Messenger = "Login Success";
                response.Data = _authentication.GenerateToken(account.LastName, account.Id.ToString(), account.Role);
                return response;
            }

            response.Success = false;
            response.Messenger = "Invalid Password";
            return response;
        }

        response.Success = false;
        response.Messenger = "Username Not Exist";
        return response;
    }

    public async Task<LoginResponse> ValidateCompetitor(RequestLogin accountLogin)
    {
        var response = new LoginResponse();

        var competitor = await _unitOfWork.CompetitorRepo.Login(accountLogin.UserName);

        //check null
        if (competitor != null)
        {
            //Verify Password
            Boolean check = _authentication.Verify(competitor.Password, accountLogin.Password);
            if (check is true)
            {
                response.Success = true;
                response.Messenger = "Login Success";
                response.Data = _authentication.GenerateToken(competitor.LastName, competitor.Id.ToString(),Role.COMPETITOR.ToString());
                return response;
            }
            response.Success = false;
            response.Messenger = "Invalid Password";
            return response;
        }

        response.Success = false;
        response.Messenger = "Username Not Exist";
        return response;
    }


    public async Task<RegisterResponse> CreateCompetitor(CreateCompetitorRequest competitor)
    {
        var response = new RegisterResponse();
        var c = _mapper.Map<Competitor>(competitor);
        if (await _unitOfWork.CompetitorRepo.CheckDuplicate(competitor.Email, competitor.Phone))
        {
            response.Messenger = "Email or Password is Exist !";
            response.Success = false;
            return response;
        }
        
        //if not exist
        
        c.Status = AccountStatus.ACTIVE.ToString();
        c.CreatedTime = DateTime.Now;
        
        await _unitOfWork.CompetitorRepo.AddAsync(c);

        response.Messenger = "Create Success !";
        response.Success = true;
        return response;
    }
    
    /*public async Task<RegisterResponse> CreateAccount(CreateAccountRequest account)
    {
        var response = new RegisterResponse();
        var c = _mapper.Map<Competitor>(competitor);
        if (await _unitOfWork.CompetitorRepo.CheckDuplicate(competitor.Email, competitor.Phone))
        {
            response.Messenger = "Email or Password is Exist !";
            response.Success = false;
            return response;
        }
        
        //if not exist
        
        c.Status = AccountStatus.ACTIVE.ToString();
        c.CreatedTime = DateTime.Now;
        
        await _unitOfWork.CompetitorRepo.AddAsync(c);

        response.Messenger = "Create Success !";
        response.Success = true;
        return response;
    }*/
}