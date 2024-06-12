using Infracstructures.SendModels.Mail;

namespace Application.IService.ICommonService;

public interface IMailService
{
    Task SendEmail(Mail request);
}