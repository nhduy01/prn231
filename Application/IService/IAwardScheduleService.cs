using Application.ViewModels.ScheduleViewModels;

namespace Application.IService;

public interface IAwardScheduleService
{
    public Task<List<AwardScheduleModels>> GetListByScheduleId(Guid id);
    public Task<AwardScheduleModels> GetById(Guid id);
}