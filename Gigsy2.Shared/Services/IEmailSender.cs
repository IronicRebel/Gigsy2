
namespace Gigsy2.Shared.Services
{
    public interface IEmailSender
        {
            Task SendEmailAsync(string toEmail, string subject, string htmlContent);
        }
}

