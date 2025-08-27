using Backend.Interfaces;
using Backend._Modules;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;

namespace Backend.Services
{
    public class EmailService : IMailService
    {
        private readonly ISettings _settings;

        public EmailService(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string subject, string body, bool isHtml = false)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("App Mailer", _settings.From));
            //message.To.Add(MailboxAddress.Parse(to));
            //message.Subject = subject;

            //var bodyBuilder = new BodyBuilder
            //{
            //    HtmlBody = isHtml ? body : null,
            //    TextBody = isHtml ? null : body
            //};

            //message.Body = bodyBuilder.ToMessageBody();

            //using var client = new SmtpClient();

            //try
            //{
            //    // Verbinden
            //    await client.ConnectAsync(_settings.Host, _settings.Port, _settings.UseSsl);

            //    // Authenticeren (indien nodig)
            //    if (!string.IsNullOrEmpty(_settings.User))
            //    {
            //        await client.AuthenticateAsync(_settings.User, _settings.Password);
            //    }

            //    // Versturen
            //    await client.SendAsync(message);
            //}
            //finally
            //{
            //    // Altijd netjes afsluiten
            //    await client.DisconnectAsync(true);
            //}
        }
    }
}
