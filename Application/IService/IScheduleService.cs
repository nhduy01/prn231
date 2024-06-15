using Application.BaseModels;
using Application.SendModels.Schedule;
using Application.ViewModels.ScheduleViewModels;

namespace Application.IService;

public interface IScheduleService
{
    public Task<Guid?> CreateSchedule(ScheduleRequest Schedule);
    public Task<(List<ScheduleViewModel>, int)> GetListSchedule(ListModels listModels);
    public Task<ScheduleViewModel?> GetScheduleById(Guid id);
    public Task<ScheduleViewModel?> UpdateSchedule(ScheduleUpdateRequest updateSchedule);
    public Task<bool?> DeleteSchedule(Guid id);
}