namespace Application.SendModels.AccountSendModels;

public class AccountUpdateRequest
{
    public Guid Id { get; set; }
    public DateTime Birthday { get; set; }
    public String FullName { get; set; }
    public String Address { get; set; }
    public String Phone { get; set; }
    public String? Avatar { get; set; }
}