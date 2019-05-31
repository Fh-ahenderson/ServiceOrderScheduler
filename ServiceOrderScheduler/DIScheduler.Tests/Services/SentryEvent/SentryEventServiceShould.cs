using DIScheduler.Core.Services;
using NUnit.Framework;

namespace DIScheduler.Tests.Services.SentryEvent
{
    [TestFixture]
    public class SentryEventServiceShould
    {
        private SentryEventService _sentryEventService;

        [SetUp]
        public void SetUp()
        {
            _sentryEventService = new SentryEventService();
        }

        [Test]
        public void CaptureSentryEventdsnFromApplicationConfig()
        {
            var expectedRavenClientdsn = "";

            var actualSentryEventServiceRavenClientdsn = _sentryEventService.RavenClientdsn;

            Assert.AreEqual(expectedRavenClientdsn, actualSentryEventServiceRavenClientdsn);
        }
    }
}
