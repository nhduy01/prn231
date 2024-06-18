using Application.IService;
using Application.SendModels.Notification;
using AutoMapper;
using Domain.Models;
using Infracstructures;
using Infracstructures.ViewModels.NotificationViewModels;

namespace Application.Services;

public class NotificationService : INotificationService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreateNotification(NotificationRequest Notification)
    {
        var newNotification = _mapper.Map<Notification>(Notification);
        newNotification.Status = "ACTIVE";
        newNotification.IsReaded = true;
        await _unitOfWork.NotificationRepo.AddAsync(newNotification);
        await _unitOfWork.SaveChangesAsync();
        return newNotification.Id;
    }

    #endregion

    #region Get All

    public async Task<List<NotificationViewModel>> Get5Notification(Guid id)
    {
        var list = await _unitOfWork.NotificationRepo.Get5NotificationOfUser(id);

        return _mapper.Map<List<NotificationViewModel>>(list);
    }

    #endregion

    #region Get By Id

    public async Task<NotificationDetailViewModel?> GetNotificationById(Guid id)
    {
        var Notification = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
        if (Notification == null) return null;
        return _mapper.Map<NotificationDetailViewModel>(Notification);
    }

    #endregion


    #region Is Read

    public async Task<bool?> ReadNotification(Guid id)
    {
        var notification = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
        if (notification == null) return false;

        notification.IsReaded = true;
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
}