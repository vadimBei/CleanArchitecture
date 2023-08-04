using Email.Interfaces;
using Microsoft.Extensions.Logging;

namespace Email.MailHandler
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task Send(string address, string subject, string body)
        {
            _logger.LogInformation($"Email to {address} subject '{subject}' body '{body}'");
            return Task.CompletedTask;
        }
    }
}
