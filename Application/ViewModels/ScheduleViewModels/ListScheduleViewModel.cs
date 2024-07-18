using Domain.Models;

namespace Application.ViewModels.ScheduleViewModels;

public class ListScheduleViewModel
{
    public Guid RoundId { get; set; }
    public string RoundName { get; set; } = null!;
    public string EducationName { get; set; } = null!;
    public List<Schedule>? Schedules { get; set; }
}