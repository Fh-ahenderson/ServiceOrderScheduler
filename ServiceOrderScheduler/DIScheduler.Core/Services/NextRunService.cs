using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Interfaces.Services;
using DIScheduler.Core.Model;
using DIScheduler.Core.Model.Enums;

namespace DIScheduler.Core.Services
{
    public class NextRunService : INextRunService
    {
        private readonly INextRunRepository _nextRunRepository;
        private readonly IServiceStateRepository _serviceStateRepository;

        public NextRunService(INextRunRepository nextRunRepository, IServiceStateRepository serviceStateRepository)
        {
            _nextRunRepository = nextRunRepository;
            _serviceStateRepository = serviceStateRepository;

        }

        public NextRun GetMostRecentNextRun()
        {
            var mostRecentNextRun = _nextRunRepository.GetMostRecent();

            if (mostRecentNextRun != null)
            {
                return mostRecentNextRun;
            }

            ServiceStatus currentStatus = _serviceStateRepository.GetStatus("DIScheduler");
            if (currentStatus.Status == ServiceStatusTypeValues.Healthy)
            {
                currentStatus.Status = ServiceStatusTypeValues.Error;
                _serviceStateRepository.SaveState();
            }

            return null;
        }

        public NextRun SaveNextRun(NextRun toSave)
        {
            if (toSave.ID == 0)
            {
                return _nextRunRepository.Create(toSave);
            }

            return toSave;
        }
    }
}
