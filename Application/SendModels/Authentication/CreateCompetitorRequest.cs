namespace Infracstructures.SendModels.Authentication;

public class CreateCompetitorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public bool Gender { get; set; } = true;
}