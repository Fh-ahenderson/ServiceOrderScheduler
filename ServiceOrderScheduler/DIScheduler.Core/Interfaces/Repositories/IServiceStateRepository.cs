using DIScheduler.Core.Model;

namespace DIScheduler.Core.Interfaces.Repositories
{
    public interface IServiceStateRepository
    {
        ServiceStatus GetStatus(string serviceName);
        void SaveState();
    }
}
