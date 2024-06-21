using System.ComponentModel.DataAnnotations;

namespace Application.SendModels.Authentication;

public class CreateAccountRequest
{
    [MinLength(10, ErrorMessage = "Password must be at least 10 characters long")]
    public string? UserName { get; set; }
    public string FullName { get; set; }
    [EmailAddress] 
    public string Email { get; set; }
    public string Role { get; set; }
    public string Address { get; set; }
    [MinLength(6, ErrorMessage = "Password must be at least 6  characters long")]
    public string Password { get; set; }
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
    public string? Phone { get; set; }

    public bool Gender { get; set; } = true;
    public DateTime Birthday { get; set; }
}