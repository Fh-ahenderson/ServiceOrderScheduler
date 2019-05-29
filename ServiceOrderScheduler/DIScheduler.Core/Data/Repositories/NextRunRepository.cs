using System.Linq;
using DIScheduler.Core.Data.Contexts;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Model;

namespace DIScheduler.Core.Data.Repositories
{
    public class NextRunRepository : INextRunRepository
    {
        public NextRun Create(NextRun nextRunToCreate)
        {
            using (var _db = new SchedulerDbContext())
            {
                _db.NextRuns.Add(nextRunToCreate);
                _db.SaveChanges();
            }

            return nextRunToCreate;
        }

        public NextRun GetMostRecent()
        {
            using (var _db = new SchedulerDbContext())
            {
                return _db.NextRuns
                    .OrderByDescending(n => n.ID)
                    .FirstOrDefault();
            }
        }
    }
}
