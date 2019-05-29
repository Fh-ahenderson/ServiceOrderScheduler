using DIScheduler.Core.Model;
using DIScheduler.Core.Model.Sapphire;

namespace DIScheduler.Core.Interfaces.Mappers
{
    public interface IQueueItemMapper
    {
        QueueItem MapFromSapphire(ServiceOrder sapphireObject);
    }
}
