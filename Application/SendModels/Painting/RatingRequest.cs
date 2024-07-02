namespace Application.SendModels.Painting;

public class RatingRequest{
    public Guid ScheduleId { get; set; }
    public List<Guid> Paintings { get; set; }
}