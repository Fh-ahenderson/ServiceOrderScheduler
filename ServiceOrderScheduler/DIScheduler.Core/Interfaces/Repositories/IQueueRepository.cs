using System.Collections.Generic;
using DIScheduler.Core.Model;

namespace DIScheduler.Core.Interfaces.Repositories
{
    public interface IQueueRepository
    {
        void Create(QueueItem item);
        void Create(IEnumerable<QueueItem> itemsToAdd);
    }
}
