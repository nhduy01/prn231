namespace Application.ViewModels.AuthenticationViewModels;

public class LoginResponse
{
    public string? JwtToken { get; set; }
    public RefreshToken? RefreshToken { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}