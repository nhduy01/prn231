namespace Application.SendModels.Painting;

public class CompetitorCreatePaintingRequest
{
    public Guid AccountId { get; set; }
    public string Image { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid RoundTopicId { get; set; }
}