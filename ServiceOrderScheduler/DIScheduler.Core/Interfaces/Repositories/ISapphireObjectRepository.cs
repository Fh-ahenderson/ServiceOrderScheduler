using System;
using System.Collections.Generic;
using DIScheduler.Core.Model.Sapphire;

namespace DIScheduler.Core.Interfaces.Repositories
{
    public interface ISapphireObjectRepository
    {
        IList<ServiceOrder> ListByLastRunDate(DateTime lastRunDate);
    }
}
