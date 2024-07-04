namespace Application.SendModels.Contest;

public class ContestRequest
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
}