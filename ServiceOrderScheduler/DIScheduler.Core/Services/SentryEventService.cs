using System;
using System.Configuration;
using SharpRaven;
using SharpRaven.Data;
using DIScheduler.Core.Interfaces.Services;

namespace DIScheduler.Core.Services
{
    public class SentryEventService : ISentryEventService
    {
        private readonly RavenClient _ravenClient;

        private string _ravenClientdsn;
        public string RavenClientdsn { get => _ravenClientdsn; }

        public SentryEventService()
        {
            _ravenClientdsn = ConfigurationManager.AppSettings["RavenClientdsn"].ToString();
            _ravenClient = new RavenClient(_ravenClientdsn);
        }

        public void LogError(Exception exception)
        {
            _ravenClient.Capture(new SentryEvent(exception));
        }

        public void LogCustomInfoEvent(string messageForEvent, dynamic eventObj)
        {
            _ravenClient.Capture(new SentryEvent(messageForEvent)
            {
                Level = ErrorLevel.Info,
                Extra = eventObj
            });
        }
    }
}
