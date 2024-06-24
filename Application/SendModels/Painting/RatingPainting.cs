namespace Application.SendModels.Painting;

public class RatingPainting
{
    public Guid ScheduleId { get; set; }
    public List<Guid> Paintings { get; set; }
}