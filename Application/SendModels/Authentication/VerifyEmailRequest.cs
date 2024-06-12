namespace Application.SendModels.Authentication;

public class VerifyEmailRequest
{
    public string? Id { get; set; }
    public string? VerifyToken { get; set; }
}