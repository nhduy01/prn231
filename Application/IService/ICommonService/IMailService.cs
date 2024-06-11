using Infracstructures.SendModels.Mail;

namespace WebAPI.IService.ICommonService;

public interface IMailService
{
    Task SendEmail(Mail request);
}