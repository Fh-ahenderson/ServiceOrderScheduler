using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DIScheduler.Core.Data.Contexts;
using DIScheduler.Core.Exceptions;
using DIScheduler.Core.Interfaces.Repositories;
using DIScheduler.Core.Interfaces.Services;
using DIScheduler.Core.Model.Sapphire;

namespace DIScheduler.Core.Data.Repositories
{
    public class SapphireObjectRepository : ISapphireObjectRepository
    {
        //private readonly ISentryEventService _sentryEventService;
        private readonly IEmailService _emailService;

        public SapphireObjectRepository(/*ISentryEventService sentryEventService,*/ IEmailService emailService)
        {
            //_sentryEventService = sentryEventService;
            _emailService = emailService;
        }

        public IList<ServiceOrder> ListByLastRunDate(DateTime lastRunDate)
        {
            List<ServiceOrder> listFromSapphire = new List<ServiceOrder>();
            using (var _db = new SapphireDbContext())
            {
                listFromSapphire = _db.ServiceOrder
                    .Include(p => p.Lot)
                    .Include(p => p.Lot.Community)
                    .Include(p => p.Vendor)
                    .Where(p => p.LastUpdated > lastRunDate).ToList();
            }
            var returnList = new List<ServiceOrder>();
            foreach (var batchItem in listFromSapphire)
            {
                try
                {
                    ValidateSapphireData(batchItem);

                    returnList.Add(batchItem);
                }
                catch (SapphireDataException ex)
                {
                    //_sentryEventService.LogError(ex);
                    _emailService.SendEmail("Service Order Scheduler Sapphire Data Validation Failure", ex.Message);
                }
            }

            return returnList;
        }

        private void ValidateSapphireData(ServiceOrder svcOrdToValidate)
        {

            if (svcOrdToValidate.Lot == null)
            {
                throw new MissingLotException($"Missing Lot for SvcOrdRID {svcOrdToValidate.SvcOrdRID}  and LotRID {svcOrdToValidate.LotRID}");
            }

            if (svcOrdToValidate.Lot.Community == null)
            {
                throw new MissingCommunityException($"Missing Community for SvcOrdRID {svcOrdToValidate.SvcOrdRID} and LotRID {svcOrdToValidate.LotRID} and CommunityRID {svcOrdToValidate.Lot.CommunityRID}");
            }

            if (svcOrdToValidate.Vendor == null)
            {
                throw new MissingVendorException($"Missing Vendor for JobRID {svcOrdToValidate.LotRID} and VndRID {svcOrdToValidate.Vendor.VndRID}");
            }

        }
    }
}