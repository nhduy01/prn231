using Application.ViewModels.AccountViewModels;

namespace Application.SendModels.Authentication;

public class RefreshTokenRequest
{
    public string? Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime Expried { get; set; }
}