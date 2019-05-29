using DIScheduler.Core.Model;

namespace DIScheduler.Core.Interfaces.Repositories
{
    public interface INextRunRepository
    {
        NextRun Create(NextRun nextRunToCreate);
        NextRun GetMostRecent();
    }
}
