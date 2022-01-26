using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrasructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.Infrasructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<EmailSettings> settings, 
            ILogger<EmailService> logger
        )
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_settings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var body = email.Body;

            var from = new EmailAddress
            {
                Email = _settings.FromAddress,
                Name = _settings.FromName
            };

            var message = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                body,
                body
            );

            var response = await client.SendEmailAsync(message);

            _logger.LogInformation("E-mail sent.");

            if (response.StatusCode is HttpStatusCode.Accepted or HttpStatusCode.OK)
            {
                return true;
            }

            _logger.LogError("E-mail failed.");

            return false;
        }
    }
}
