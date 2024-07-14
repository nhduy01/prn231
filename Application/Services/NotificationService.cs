using Application.IService;
using Application.SendModels.Notification;
using AutoMapper;
using Domain.Enums;
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

    public async Task<bool> CreateNotification(NotificationRequest Notification)
    {
        var newNotification = _mapper.Map<Notification>(Notification);
        newNotification.Status = NotificationStatus.Active.ToString();
        newNotification.IsReaded = false;
        await _unitOfWork.NotificationRepo.AddAsync(newNotification);
        
        return await _unitOfWork.SaveChangesAsync()>0;
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
        var notification = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
        if (notification == null) throw new Exception("Khong tim thay Notification");
        await ReadNotification(id);
        return _mapper.Map<NotificationDetailViewModel>(notification);
    }

    #endregion


    #region Is Read

    public async Task<bool> ReadNotification(Guid id)
    {
        var notification = await _unitOfWork.NotificationRepo.GetByIdAsync(id);
        if (notification == null) throw new Exception("Khong tim thay Notification");
        notification.IsReaded = true;

        return await _unitOfWork.SaveChangesAsync()>0;

    }

    #endregion
}