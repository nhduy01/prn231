﻿using Application.BaseModels;
using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;

namespace Application.IService;

public interface ITopicService
{
    public Task<Guid?> CreateTopic(TopicRequest Topic);
    public Task<(List<TopicViewModel>, int)> GetListTopic(ListModels listModels);
    public Task<TopicViewModel?> GetTopicById(Guid id);
    public Task<TopicViewModel?> UpdateTopic(TopicUpdateRequest updateTopic);
    public Task<bool?> DeleteTopic(Guid id);
}