using System.ComponentModel.DataAnnotations;

namespace Application.SendModels.Authentication;

public class CreateAccountRequest
{
    [Required] public string? Username { get; set; }

    [Required] public string FullName { get; set; }

    [EmailAddress] public string Email { get; set; }

    [Required] public string Role { get; set; }

    [Required] public string Password { get; set; }

    [Required] public string? Phone { get; set; }

    [Required] public bool Gender { get; set; } = true;

    [Required] public DateTime Birthday { get; set; }
}