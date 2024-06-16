namespace Application.SendModels.Authentication;

public class RefreshTokenRequest
{
    public Guid Id { get; set; }
    public string? Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime Expried { get; set; }
}