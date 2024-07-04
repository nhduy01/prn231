namespace Application.SendModels.AccountSendModels;

public class SubAccountRequest
{
    public DateTime Birthday { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public bool Gender { get; set; } = true;
}