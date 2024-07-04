namespace Infracstructures.SendModels.Painting;

public class PaintingUpdateStatusRequest
{
    public Guid Id { get; set; }
    public Boolean IsPassed { get; set; }
}