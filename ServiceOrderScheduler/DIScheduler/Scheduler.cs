using System;
using System.Collections.Generic;
using System.Linq;
using DIScheduler.Core.Interfaces.Mappers;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Interfaces.Services;
using DIScheduler.Core.Model;
using DIScheduler.Core.Model.Enums;
using DIScheduler.Core.Model.Sapphire;
using DIScheduler.Interfaces;

namespace DIScheduler
{
    public class Scheduler : IScheduler
    {
        private readonly ISapphireObjectRepository _sapphireObjectRepository;
        private readonly INextRunService _nextRunService;
        private readonly IQueueItemMapper _mapper;
        private readonly IQueueRepository _queueRepository;
       // private readonly ISentryEventService _sentryEventService;

        public Scheduler(ISapphireObjectRepository sapphireObjectRepository, INextRunService nextRunService, IQueueItemMapper mapper, IQueueRepository queueRepository)//, /ISentryEventService sentryEventService)
        {
            _sapphireObjectRepository = sapphireObjectRepository;
            _nextRunService = nextRunService;
            _mapper = mapper;
            _queueRepository = queueRepository;
            //_sentryEventService = sentryEventService;
        }

        public void PollSapphireQueue()
        {
            NextRun mostRecentNextRun = _nextRunService.GetMostRecentNextRun();
            if (mostRecentNextRun == null) { return; }

            IList<ServiceOrder> batchToProcess = _sapphireObjectRepository.ListByLastRunDate(mostRecentNextRun.RunComplete.AddHours(-1));
            if (batchToProcess == null) { return; }

            IEnumerable<QueueItem> mappedBatch = batchToProcess.Select(_mapper.MapFromSapphire);

            _queueRepository.Create(mappedBatch);

            var currentNextRun = new NextRun { RunComplete = DateTime.Now };
            currentNextRun.Status = NextRunStatusType.Processed;
            _nextRunService.SaveNextRun(currentNextRun);
        }
    }
}
