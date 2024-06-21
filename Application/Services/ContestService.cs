using System;
using Application.IService;
using Application.IService.ICommonService;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class ContestService : IContestService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ContestService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
        IConfiguration configuration, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Add Contest

    public async Task<bool> AddContest(AddContestViewModel addContestViewModel)
    {
        var contest = _mapper.Map<Contest>(addContestViewModel);
        contest.CreatedBy = _claimsService.GetCurrentUserId();
        contest.Status = "ACTIVE";
        await _unitOfWork.ContestRepo.AddAsync(contest);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Delete Contest

    public async Task<bool> DeleteContest(Guid contestId)
    {
        var contest = await _unitOfWork.ContestRepo.GetByIdAsync(contestId);
        if (contest == null) throw new Exception("Khong tim thay Contest"); 

        contest.Status = "INACTIVE";

        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion

    #region Update Contest

    public async Task<bool> UpdateContest(UpdateContestViewModel updateContest)
    {
        var contest = await _unitOfWork.ContestRepo.GetByIdAsync(updateContest.Id);
        if (contest == null) throw new Exception("Khong tim thay Contest");

        /*contest.Name = updateContest.Name;
        contest.StartTime = updateContest.StartTime;
        contest.EndTime = updateContest.EndTime;
        contest.Description = updateContest.Description;
        contest.Content = updateContest.Content;*/
        contest = _mapper.Map<Contest>(updateContest);
        contest.UpdatedBy = _claimsService.GetCurrentUserId();
        contest.UpdatedTime = _currentTime.GetCurrentTime();


        return await _unitOfWork.SaveChangesAsync() > 0 ;

    }

    #endregion

    #region Get Contest By Id
    public async Task<Contest?> GetContestById(Guid awardId)
    {
        var contest = await _unitOfWork.ContestRepo.GetAllContestInformationAsync(awardId);
        if (contest == null) throw new Exception("Khong tim thay Contest");

        return _mapper.Map<Contest>(contest);
    }
    #endregion
    
    #region Get 5 recent contest year
    public async Task<List<int>> Get5RecentYear()
    {
        return await _unitOfWork.ContestRepo.Get5RecentYearAsync();
    }

    #endregion

    
}