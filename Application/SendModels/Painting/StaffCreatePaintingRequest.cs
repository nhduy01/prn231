namespace Application.SendModels.Painting;

public class StaffCreatePaintingRequest
{
    // Information Account
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime Birthday { get; set; }

    // Information Painting
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid RoundTopicId { get; set; }
    public Guid CurrentUserId { get; set; }
}