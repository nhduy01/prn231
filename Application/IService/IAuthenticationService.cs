using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;

namespace Application.IService;

public interface IAuthenticationService
{
    Task<LoginResponse> ValidateCompetitor(LoginRequest accountLogin);
    Task<LoginResponse> ValidateAccount(LoginRequest accountLogin);
    Task<RegisterResponse> CreateCompetitor(CreateCompetitorRequest competitor);

    Task<RegisterResponse> CreateAccount(CreateAccountRequest account);

    public Task<string> ReGenerateJwtTokenAccount(RefreshTokenRequest refreshToken);

    public Task<bool> LogoutCompetitor(string id);
    
    public Task<bool> LogoutAccount(string id);


    /*Task<Boolean> Logout(Guid AccountId);
    Task<ResponseAccountAdmin> CreateAccount(RequestAccountToAdmin requestAccountToAdmin);
    Task<ResponseAccountCandidate> CreateAccountCandidate(RequestAccountToCadidate requestAccountToCandidate);
    Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany);
    Task<ResponseAccountHr> CreateAccountHr(RequestAccountToHr requestAccountToHr);
    Task<ResponseAccountInterviewer> CreateAccountInterviewer(RequestAccountToInterviewer requestAccountToInterviewer);
    Task<bool> ForgetPassword(string email);
    Task<bool> ResetPassword(string email, string password, string resetToken);*/
}