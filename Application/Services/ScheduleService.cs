using Application.BaseModels;
using Application.IService;
using Application.SendModels.Painting;
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

    public async Task<bool> CreateScheduleForPreliminaryRound(ScheduleRequest schedule)
    {
        //Get Paintings Of Preliminary round
        var listPainting = await _unitOfWork.PaintingRepo.ListPaintingForPreliminaryRound(schedule.RoundId);

        var award = _unitOfWork.RoundRepo.GetRoundDetail(schedule.RoundId).Result?.EducationalLevel.Award
            .FirstOrDefault(a => a.Rank == RankAward.Preliminary.ToString());

        int quantityAward = award.Quantity;
        
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
            
            //Add award schudele
            var newAwardSchedule = new AwardSchedule();
            newAwardSchedule.Id = Guid.NewGuid();
            newAwardSchedule.ScheduleId = newSchedule.Id;
            newAwardSchedule.AwardId = award.Id;
            
            if (i == schedule.ListExaminer.Count - 1)
            {
                newAwardSchedule.Quantity = quantityAward;
            }
            else
            {
                newAwardSchedule.Quantity = (int)Math.Ceiling(quantityAward / (double)schedule.ListExaminer.Count);
                quantityAward =- newAwardSchedule.Quantity;
            }

            newSchedule.AwardSchedule = new List<AwardSchedule>();
            newSchedule.AwardSchedule.Add(newAwardSchedule);
            
            await _unitOfWork.ScheduleRepo.AddAsync(newSchedule);
            foreach (var painting in result[i])
            {
                painting.ScheduleId = newSchedule.Id;
            }
        }
        return await _unitOfWork.SaveChangesAsync()>0;
        
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
        var Schedule = await _unitOfWork.ScheduleRepo.GetById(id);
        if (Schedule == null) throw new Exception("Khong tim thay Schedule");
        return _mapper.Map<ScheduleViewModel>(Schedule);
    }

    #endregion
    
    public async Task<bool> RatingPreliminaryRound(RatingPainting ratingPainting)
    {
        var schedules = await _unitOfWork.ScheduleRepo.GetById(ratingPainting.ScheduleId);
        if (schedules.Painting.Any(p => p.Status != PaintingStatus.Accepted.ToString()))
        {
            return false;
        }
        var listPass = schedules.Painting.Where(p => ratingPainting.Paintings.Contains(p.Id)).ToList();
        var listNotPass = schedules.Painting.Where(p => !ratingPainting.Paintings.Contains(p.Id)).ToList();
        
        listPass.ForEach(p => p.Status = PaintingStatus.Pass.ToString());
        listNotPass.ForEach(p => p.Status = PaintingStatus.NotPass.ToString());
        
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    #region Update

    public async Task<bool> UpdateSchedule(ScheduleUpdateRequest updateSchedule)
    {
        var schedule = await _unitOfWork.ScheduleRepo.GetByIdAsync(updateSchedule.Id);
        if (schedule == null) throw new Exception("Khong tim thay Schedule");
        _mapper.Map(updateSchedule, schedule);
        
        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion

    #region Delete

    public async Task<bool> DeleteSchedule(Guid id)
    {
        var Schedule = await _unitOfWork.ScheduleRepo.GetByIdAsync(id);
        if (Schedule == null) throw new Exception("Khong tim thay Schedule"); 
        Schedule.Status = "INACTIVE";

        
        return await _unitOfWork.SaveChangesAsync()>0;
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