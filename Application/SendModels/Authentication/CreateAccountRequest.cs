using System.ComponentModel.DataAnnotations;

namespace Application.SendModels.Authentication;

public class CreateAccountRequest
{
    public DateTime Birthday { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Role { get; set; }
    public string Address { get; set; }
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
    public string Phone { get; set; }
    public bool Gender { get; set; } = true;
    [RegularExpression(@"^\d{12}$", ErrorMessage = "Identify number must be 12 digits")]
    public string IdentifyNumber { get; set; }
}