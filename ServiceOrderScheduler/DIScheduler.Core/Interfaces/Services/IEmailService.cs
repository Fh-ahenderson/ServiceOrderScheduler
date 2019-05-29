namespace DIScheduler.Core.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(string subject, string messageBodyText);
        void SendEmail(string recipient, string subject, string messageBodyText);
    }
}
