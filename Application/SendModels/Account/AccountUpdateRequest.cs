namespace Application.SendModels.AccountSendModels;

public class AccountUpdateRequest
{
    public DateTime Birthday { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string? Avatar { get; set; }
    public bool Gender { get; set; } = true;
    public string? RefreshToken { get; set; }
}