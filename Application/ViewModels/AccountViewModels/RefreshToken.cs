namespace Application.ViewModels.AccountViewModels;

public class RefreshToken
{
    private static readonly DateTime Current = DateTime.Now;
    public DateTime CreateTime = DateTime.Now;
    public DateTime Expired = Current.AddDays(10);
    public string Token { get; set; }
}