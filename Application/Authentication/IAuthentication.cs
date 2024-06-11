using Domain.Models;

namespace Application.Authentication;

public interface IAuthentication
{
    public bool Verify(string HashPassword, string InputPassword);
    public string Hash(string password);
    public string GenerateToken(string name, string id, string role);
    
}