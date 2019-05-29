using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DIScheduler.DependencyResolution;

namespace DIScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            var container = DependencyResolution.IoC.Initialize();
            var application = container.GetInstance<ConsoleApplication>();
            application.Run();
#else
            var container = IoC.Initialize();
            var application = container.GetInstance<Application>();
            application.Run();
#endif
        }
        public class Application
        {
            private readonly SchedulerService _schedulerService;

            public Application(SchedulerService schedulerService)
            {
                _schedulerService = schedulerService;
            }

            public void Run()
            {
                var servicesToRun = new List<ServiceBase> { _schedulerService };
                ServiceBase.Run(servicesToRun.ToArray());
            }
        }
    }
}
