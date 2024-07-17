namespace Application.SendModels.Report;

public class UpdateReportRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid CurrentUserId { get; set; }
}