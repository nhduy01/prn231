using Application.ViewModels.ScheduleViewModels;

namespace Application.IService;

public interface IAwardScheduleService
{
    public Task<List<AwardScheduleListModels>> GetListByScheduleId(Guid id);

}