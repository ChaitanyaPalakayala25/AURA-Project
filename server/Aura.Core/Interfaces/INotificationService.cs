namespace Aura.Core.Interfaces;

public interface INotificationService
{
    Task SendEmailAsync(string to, string subject, string body);
}
