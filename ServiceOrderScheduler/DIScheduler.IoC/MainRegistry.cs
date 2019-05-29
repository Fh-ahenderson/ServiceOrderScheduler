using StructureMap;
using DIScheduler.Core.Interfaces.Repositories;

namespace DIScheduler.IoC
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(scan =>
                {
                    scan.LookForRegistries();
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<INextRunRepository>(); //Scheduler.Core
                    scan.WithDefaultConventions();
                }
                );
        }
    }
}
