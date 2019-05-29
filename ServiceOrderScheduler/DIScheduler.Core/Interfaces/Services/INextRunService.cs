using DIScheduler.Core.Model;

namespace DIScheduler.Core.Interfaces.Services
{
    public interface INextRunService
    {
        NextRun GetMostRecentNextRun();
        NextRun SaveNextRun(NextRun toSave);
    }
}
