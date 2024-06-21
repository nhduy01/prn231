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
        if (Topic == null) throw new Exception("Khong tim thay Topic");
        return _mapper.Map<TopicViewModel>(Topic);
    }

    #endregion

    #region Update

    public async Task<bool> UpdateTopic(TopicUpdateRequest updateTopic)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(updateTopic.Id);
        if (Topic == null) throw new Exception("Khong tim thay Sponsor");

        _mapper.Map(updateTopic, Topic);
        return await _unitOfWork.SaveChangesAsync()>0;

    }

    #endregion

    #region Delete

    public async Task<bool> DeleteTopic(Guid id)
    {
        var Topic = await _unitOfWork.TopicRepo.GetByIdAsync(id);
        if (Topic == null) throw new Exception("Khong tim thay Sponsor");

        Topic.Status = "INACTIVE";
        return await _unitOfWork.SaveChangesAsync()>0;
    }

    #endregion
}