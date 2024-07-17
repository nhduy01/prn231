namespace Application.SendModels.Painting;

public class StaffCreatePaintingFinalRoundRequest
{
    public Guid CompetitorId { get; set; }
    public Guid CurrentUserId { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid RoundTopicId { get; set; }
}