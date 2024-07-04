using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class TopicService : ITopicService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TopicService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
        IConfiguration configuration, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _claimsService = claimsService;
    }

    #region Create

    public async Task<bool> CreateTopic(TopicRequest Topic)
    {
        var newTopic = _mapper.Map<Topic>(Topic);
        newTopic.Status = TopicStatus.Active.ToString();
        await _unitOfWork.TopicRepo.AddAsync(newTopic);

        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion

    #region Get All

    public async Task<(List<TopicViewModel>, int)> GetListTopic(ListModels listModels)
    {
        var list = await _unitOfWork.TopicRepo.GetAllAsync();
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<TopicViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<TopicViewModel?> GetTopicById(Guid id)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(id);
        if (Topic == null) throw new Exception("Khong tim thay Topic");
        return _mapper.Map<TopicViewModel>(Topic);
    }

    #endregion

    #region Update

    public async Task<bool> UpdateTopic(TopicUpdateRequest updateTopic)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(updateTopic.Id);
        if (Topic == null) throw new Exception("Khong tim thay Topic");

        _mapper.Map(updateTopic, Topic);
        Topic.UpdatedTime = _currentTime.GetCurrentTime(); 
        return await _unitOfWork.SaveChangesAsync()>0;

    }

    #endregion

    #region Delete

    public async Task<bool> DeleteTopic(Guid id)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(id);
        if (Topic == null) throw new Exception("Khong tim thay Topic");

        Topic.Status = TopicStatus.Inactive.ToString();
        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion
}