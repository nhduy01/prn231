using Application.BaseModels;
using Application.IService;
using Application.SendModels.Schedule;
using Application.ViewModels.ScheduleViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreateSchedule(ScheduleRequest schedule)
    {
        //Get Paintings Of Preliminary roud
        var listPainting = await _unitOfWork.PaintingRepo.ListPaintingForPreliminaryRound(schedule.RoundId);
        
        List<List<Painting>> result = SplitList(listPainting, schedule.ListExaminer.Count);
        
        //Create Schedule by number of Examiner

        for(int i = 0; i < schedule.ListExaminer.Count; i++)
        {
            var newSchedule = new Schedule();
            newSchedule.Id = Guid.NewGuid();
            newSchedule.ExaminerId = schedule.ListExaminer[i];
            newSchedule.RoundId = schedule.RoundId;
            newSchedule.Description = schedule.Description;
            newSchedule.Status = ScheduleStatus.Active.ToString();
            await _unitOfWork.ScheduleRepo.AddAsync(newSchedule);
            foreach (var painting in result[i])
            {
                painting.ScheduleId = newSchedule.Id;
            }
        }
        await _unitOfWork.SaveChangesAsync();
        return null;
    }

    #endregion

    #region Get All

    public async Task<(List<ScheduleViewModel>, int)> GetListSchedule(ListModels listModels)
    {
        var list = await _unitOfWork.ScheduleRepo.GetAllAsync();
        list = (List<Schedule>)list.Where(x => x.Status == "ACTIVE");

        var result = new List<Schedule>();

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<ScheduleViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<ScheduleViewModel?> GetScheduleById(Guid id)
    {
        var Schedule = await _unitOfWork.ScheduleRepo.GetByIdAsync(id);
        if (Schedule == null) return null;
        return _mapper.Map<ScheduleViewModel>(Schedule);
    }

    #endregion

    #region Update

    public async Task<ScheduleViewModel?> UpdateSchedule(ScheduleUpdateRequest updateSchedule)
    {
        var schedule = await _unitOfWork.ScheduleRepo.GetByIdAsync(updateSchedule.Id);
        if (schedule == null) return null;

        _mapper.Map(updateSchedule, schedule);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ScheduleViewModel>(schedule);
    }

    #endregion

    #region Delete

    public async Task<bool?> DeleteSchedule(Guid id)
    {
        var Schedule = await _unitOfWork.ScheduleRepo.GetByIdAsync(id);
        if (Schedule == null) return false;

        Schedule.Status = "INACTIVE";
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
    
    
    public List<List<Painting>> SplitList(List<Painting> list, int n)
    {
        var result = new List<List<Painting>>();
        int chunkSize = (int)Math.Ceiling(list.Count / (double)n);

        for (int i = 0; i < n; i++)
        {
            var chunk = list.Skip(i * chunkSize).Take(chunkSize).ToList();
            if (chunk.Any()) // Nếu chunk có phần tử thì mới thêm vào result
            {
                result.Add(chunk);
            }
        }

        return result;
    }
    
}