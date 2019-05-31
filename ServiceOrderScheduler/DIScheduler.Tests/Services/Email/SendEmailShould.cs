using Moq;
using NUnit.Framework;
using DIScheduler.Core.Services;

namespace DIScheduler.Tests.Services.Email
{
    [TestFixture]
    public class SendEmailShould
    {
        private EmailService _emailService;
        private Mock<EmailService> _mockEmailService;

        [SetUp]
        public void SetUp()
        {
            _emailService = new EmailService();
            _mockEmailService = new Mock<EmailService>();
        }

        [Test]
        public void CaptureEmailAlertFromAddressFromConfig()
        {
            var expectedEmailAlertFromAddress = "Alert@fischerhomes.com";

            var actualEmailServiceEmailAlertFromAddress = _emailService.EmailAlertFrom;

            Assert.AreEqual(expectedEmailAlertFromAddress, actualEmailServiceEmailAlertFromAddress);
        }
    }
}
