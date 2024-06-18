using Application.BaseModels;
using Application.IService;
using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class TopicService : ITopicService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreateTopic(TopicRequest Topic)
    {
        var newTopic = _mapper.Map<Topic>(Topic);
        newTopic.Status = TopicStatus.ACTIVE.ToString();
        await _unitOfWork.TopicRepo.AddAsync(newTopic);
        await _unitOfWork.SaveChangesAsync();
        return newTopic.Id;
    }

    #endregion

    #region Get All

    public async Task<(List<TopicViewModel>, int)> GetListTopic(ListModels listModels)
    {
        var list = await _unitOfWork.TopicRepo.GetAllAsync();
        list = (List<Topic>)list.Where(x => x.Status == "ACTIVE");

        var result = new List<Topic>();

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<TopicViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<TopicViewModel?> GetTopicById(Guid id)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(id);
        if (Topic == null) return null;
        return _mapper.Map<TopicViewModel>(Topic);
    }

    #endregion

    #region Update

    public async Task<TopicViewModel?> UpdateTopic(TopicUpdateRequest updateTopic)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(updateTopic.Id);
        if (Topic == null) return null;

        _mapper.Map(updateTopic, Topic);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TopicViewModel>(Topic);
    }

    #endregion

    #region Delete

    public async Task<bool?> DeleteTopic(Guid id)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(id);
        if (Topic == null) return false;

        Topic.Status = "INACTIVE";
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
}