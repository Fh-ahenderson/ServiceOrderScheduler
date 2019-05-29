using System;

namespace DIScheduler.Core.Interfaces.Services
{
    public interface ISentryEventService
    {
        void LogCustomInfoEvent(string messageForEvent, dynamic eventObj);
        void LogError(Exception exception);
    }
}
