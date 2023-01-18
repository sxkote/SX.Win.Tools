using SX.Shared.Infrastructure.Models;

namespace SX.Shared.Infrastructure.Contracts
{
    public interface IEmailNotificationService
    {
        void SendEmail(EmailNotificationMessage message);
    }
}
