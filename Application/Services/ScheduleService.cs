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

    public async Task<Guid?> CreateSchedule(ScheduleRequest Schedule)
    {
        var newSchedule = _mapper.Map<Schedule>(Schedule);
        newSchedule.Status = ScheduleStatus.ACTIVE.ToString();
        await _unitOfWork.ScheduleRepo.AddAsync(newSchedule);
        await _unitOfWork.SaveChangesAsync();
        return newSchedule.Id;
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
}