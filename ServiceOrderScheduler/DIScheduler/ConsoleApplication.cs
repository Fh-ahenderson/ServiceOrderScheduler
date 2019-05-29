using DIScheduler.Interfaces;

namespace DIScheduler
{
    public class ConsoleApplication
    {
        private readonly IScheduler _scheduler;

        public ConsoleApplication(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Run()
        {
            _scheduler.PollSapphireQueue();
        }
    }
}
