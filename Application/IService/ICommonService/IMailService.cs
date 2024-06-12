using Application.BaseModels;

namespace Application.IService.ICommonService;

public interface IMailService
{
    Task SendEmail(MailModel request);
}