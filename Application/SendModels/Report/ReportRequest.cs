namespace Application.SendModels.Report;

public class ReportRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CurrentUserId { get; set; }
}