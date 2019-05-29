using System.Collections.Generic;
using DIScheduler.Core.Data.Contexts;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Model;

namespace DIScheduler.Core.Data.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        public void Create(QueueItem item)
        {
            using (var _db = new SchedulerDbContext())
            {
                _db.QueueItems.Add(item);
                _db.SaveChanges();
            }
        }

        public void Create(IEnumerable<QueueItem> itemsToAdd)
        {
            using (var _db = new SchedulerDbContext())
            {
                _db.QueueItems.AddRange(itemsToAdd);
                _db.SaveChanges();
            }
        }
    }
}
