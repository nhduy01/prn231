namespace Application.SendModels.Painting;

public class PaintingRequest
{
    public Guid? AccountId { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid RoundId { get; set; }
    public Guid TopicId { get; set; }
    public Guid CurrentUserId { get; set; }

}