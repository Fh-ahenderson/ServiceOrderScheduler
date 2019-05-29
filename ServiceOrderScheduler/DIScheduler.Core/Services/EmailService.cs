using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using DIScheduler.Core.Interfaces.Services;

namespace DIScheduler.Core.Services
{
    public class EmailService : IEmailService
    {
        //private string _smtpClient = ConfigurationManager.AppSettings["SmtpClient"].ToString();
        //private string _smtpPort = ConfigurationManager.AppSettings["SmtpPort"];
        //private string _emailAlertFrom = ConfigurationManager.AppSettings["EmailAlertFrom"].ToString();
        //private string _emailAlertRecipient = ConfigurationManager.AppSettings["EmailAlertRecipient"].ToString();

        private const string _smtpClient = "smtp-relay.gmail.com";
        private const int _smtpPort = 25;
        private const string _emailAlertFrom = "Alert@fischerhomes.com";
        private const string _emailAlertRecipient = "webmaster@fischerhomes.com";

        public string SmtpClient { get => _smtpClient; }
        public int SmtpPort { get => _smtpPort; }
        public string EmailAlertFrom { get => _emailAlertFrom; }
        public string EmailAlertRecipient { get => _emailAlertRecipient; }

        public void SendEmail(string subject, string messageBodyText)
        {
            SendEmail(_emailAlertRecipient, subject, messageBodyText);
        }

        public void SendEmail(string recipient, string subject, string messageBodyText)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailAlertFrom),
                Subject = subject,
                To = { recipient }
            };

            mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(messageBodyText, null, MediaTypeNames.Text.Plain));

            var smtp = new SmtpClient(ConfigurationManager.AppSettings.GetValues("SmtpClient").ToString(),
                                      int.Parse(ConfigurationManager.AppSettings.GetValues("SmtpPort").ToString()));
            smtp.Send(mail);
        }
    }
}
