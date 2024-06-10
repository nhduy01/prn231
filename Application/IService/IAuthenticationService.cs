using Application.ViewModels.AccountViewModels;
using Infracstructures.SendModels.Authentication;

namespace Application.IService;

public interface IAuthenticationService
{
    Task<LoginResponse> ValidateCompetitor(RequestLogin accountLogin);
    Task<LoginResponse> ValidateAccount(RequestLogin accountLogin);
    Task<RegisterResponse> CreateCompetitor(CreateCompetitorRequest competitor);
    /*Task<Boolean> Logout(Guid AccountId);
    Task<ResponseAccountAdmin> CreateAccount(RequestAccountToAdmin requestAccountToAdmin);
    Task<ResponseAccountCandidate> CreateAccountCandidate(RequestAccountToCadidate requestAccountToCandidate);
    Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany);
    Task<ResponseAccountHr> CreateAccountHr(RequestAccountToHr requestAccountToHr);
    Task<ResponseAccountInterviewer> CreateAccountInterviewer(RequestAccountToInterviewer requestAccountToInterviewer);
    Task<bool> ForgetPassword(string email);
    Task<bool> ResetPassword(string email, string password, string resetToken);*/

}