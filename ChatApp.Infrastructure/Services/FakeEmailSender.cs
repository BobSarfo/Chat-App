using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace ChatApp.Infrastructure.Services
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Email: {email};  subject: {subject};  MailContent: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}
