namespace Infracstructures.SendModels.Authentication;

public class RequestLogin
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}