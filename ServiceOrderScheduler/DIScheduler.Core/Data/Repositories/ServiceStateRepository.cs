using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIScheduler.Core.Data.Contexts;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Model;

namespace DIScheduler.Core.Data.Repositories
{
    public class ServiceStateRepository : IServiceStateRepository
    {
        public ServiceStatus GetStatus(string serviceName)
        {
            using (var _db = new SchedulerDbContext())
            {
                return _db.ServiceStatuses.FirstOrDefault(s => s.ServiceName == serviceName);
            }
        }

        public void SaveState()
        {
            using (var _db = new SchedulerDbContext())
            {
                _db.SaveChanges();
            }
        }
    }
}
