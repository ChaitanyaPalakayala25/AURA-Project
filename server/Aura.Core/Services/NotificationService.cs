using Aura.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Aura.Core.Services;

public class NotificationService : INotificationService
{
    private readonly string _apiKey;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public NotificationService(IConfiguration configuration)
    {
        _apiKey = configuration["SendGrid:ApiKey"] ?? string.Empty;
        _fromEmail = configuration["SendGrid:FromEmail"] ?? "no-reply@aura.com";
        _fromName = configuration["SendGrid:FromName"] ?? "AURA System";
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            Console.WriteLine($"SendGrid API Key not found. Email to {to} suppressed. Body: {body}");
            return;
        }

        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_fromEmail, _fromName);
        var toAddress = new EmailAddress(to);
        var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, body, body);
        
        var response = await client.SendEmailAsync(msg);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Body.ReadAsStringAsync();
            Console.WriteLine($"Failed to send email: {error}");
        }
    }
}
