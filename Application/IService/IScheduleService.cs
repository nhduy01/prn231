using Application.BaseModels;
using Application.SendModels.Painting;
using Application.SendModels.Schedule;
using Application.ViewModels.ScheduleViewModels;

namespace Application.IService;

public interface IScheduleService
{
    public Task<bool> CreateScheduleForPreliminaryRound(ScheduleRequest Schedule);
    public Task<bool> CreateScheduleForFinalRound(ScheduleRequest Schedule);
    public Task<(List<ScheduleViewModel>, int)> GetListSchedule(ListModels listModels);
    public Task<ScheduleViewModel?> GetScheduleById(Guid id);
    public Task<bool> RatingPreliminaryRound(RatingRequest ratingPainting);
    public Task<bool> RatingFirstPrize(RatingRequest ratingPainting);
    public Task<bool> RatingSecondPrize(RatingRequest ratingPainting);
    public Task<bool> RatingConsolationPrize(RatingRequest ratingPainting);
    public Task<bool> RatingThirdPrize(RatingRequest ratingPainting);
    public Task<bool> UpdateSchedule(ScheduleUpdateRequest updateSchedule);
    public Task<bool> DeleteSchedule(Guid id);
}