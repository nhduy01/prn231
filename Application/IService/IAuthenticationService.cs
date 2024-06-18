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

    public Task<bool> LogoutCompetitor(Guid id);
    
    public Task<bool> LogoutAccount(Guid id);

    public Task<bool?> VerifyAccount(Guid id);
    
}