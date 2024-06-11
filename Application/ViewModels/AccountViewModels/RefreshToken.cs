namespace Application.ViewModels.AccountViewModels;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime CreateTime = DateTime.Now;
    public DateTime Expired = Current.AddDays(10);
    
    private static DateTime Current = DateTime.Now; 
}