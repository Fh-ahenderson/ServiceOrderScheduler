using StructureMap;

namespace DIScheduler.DependencyResolution
{
    public class SchedulerRegistry : Registry
    {
        public SchedulerRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<Scheduler>(); //DIScheduler
                scan.WithDefaultConventions();
            });
        }
    }
}
