using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using DIScheduler.Interfaces;
using DIScheduler.Core.Interfaces.Services;

namespace DIScheduler
{
    public partial class SchedulerService : ServiceBase
    {
        private bool inProcess = false;
        private readonly IScheduler _scheduler;
        private readonly ISentryEventService _sentryEventService;
        private readonly IEmailService _emailService;

        private int PollingInterval
        {
            get
            {
                try
                {
                    string pollInterval = ConfigurationManager.AppSettings["PollingInterval"];

                    return string.IsNullOrEmpty(pollInterval) ? 1800000 : Convert.ToInt32(pollInterval);
                }
                catch
                {
                    return 1800000; // 30 Minutes
                }
            }
        }

        public SchedulerService(IScheduler scheduler, ISentryEventService sentryEventService, IEmailService emailService)
        {
            _scheduler = scheduler;
            _sentryEventService = sentryEventService;
            _emailService = emailService;
            InitializeComponent();
        }

        private void PollSapphireQueue(object stateInfo)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        inProcess = true;
                        _scheduler.PollSapphireQueue();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("ServiceOrder_Scheduler", "Exception " + ex.Message,
                            EventLogEntryType.Error);
                        EventLog.WriteEntry("ServiceOrder_Scheduler_Scheduler", "Inner Exception " + ex.InnerException,
                            EventLogEntryType.Error);
                        EventLog.WriteEntry("ServiceOrder_Scheduler_Scheduler", "stack " + ex.StackTrace,
                            EventLogEntryType.Error);
                        _sentryEventService.LogError(ex);
                        _emailService.SendEmail("ServiceOrder_Scheduler Scheduler Failure", ex.Message);
                    }
                    finally
                    {
                        inProcess = false;
                        Thread.Sleep(PollingInterval);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ServiceOrder_Scheduler", "Exception" + ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PollSapphireQueue));

            //Main thread has to sleep for worker thread to pick up control
            Thread.Sleep(1000);
        }

        protected override void OnStop()
        {
            if (inProcess)
            {
                Thread.Sleep(60000);//1 min
            }
        }
    }
}
