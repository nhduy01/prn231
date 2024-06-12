using System.Net;
using System.Net.Mail;
using Application.BaseModels;
using Application.IService.ICommonService;
using Microsoft.Extensions.Configuration;

namespace Application.Services.CommonService;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(MailModel request)
    {
        var emailHost = _configuration["Email:EmailHost"];
        var emailUsername = _configuration["Email:EmailUsername"];
        var emailPassword = _configuration["Email:EmailPassword"];

        var fromAddress = new MailAddress(emailUsername);
        var toAddress = new MailAddress(request.To);

        var smtpClient = new SmtpClient(emailHost, 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(emailUsername, emailPassword),
            EnableSsl = true
        };

        var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = request.Subject,
            Body = request.Body
        };

        await smtpClient.SendMailAsync(message);
    }
}