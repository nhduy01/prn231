namespace Application.ViewModels.ContestViewModels;

public class UpdateContestViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
}