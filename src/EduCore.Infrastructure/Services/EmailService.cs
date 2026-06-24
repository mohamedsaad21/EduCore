using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using EduCore.Application.Abstracts;
using EduCore.Domain.Helpers;

namespace EduCore.Service.Implementation;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    public EmailService(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }

    public async Task<string> SendEmailAsync(string Email, string Message, string? reason)
    {
        try
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                var bodybuilder = new BodyBuilder
                {
                    HtmlBody = $"{Message}",
                    TextBody = "wellcome",
                };
                var message = new MimeMessage
                {
                    Body = bodybuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("EduCore", _emailSettings.FromEmail));
                message.To.Add(new MailboxAddress("testing", Email));
                message.Subject = reason == null ? "No Submitted" : reason;
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            //end of sending email
            return "Success";
        } catch (Exception ex)
        {
            return "Failed";
        }
    }
}
