using System;
using DIScheduler.Core.Interfaces.Mappers;
using DIScheduler.Core.Model;
using DIScheduler.Core.Model.Enums;
using DIScheduler.Core.Model.Sapphire;

namespace DIScheduler.Core.Mappers
{
    public class QueueItemMapper : IQueueItemMapper
    {
        public QueueItem MapFromSapphire(ServiceOrder sapphireObject)
        {
            return new QueueItem
            {
                Activity = "60100",
                ApprovePaymentDate = sapphireObject.DateApproved,
                ApprovalDate = sapphireObject.DateApproved,
                CancelledDate = sapphireObject.DateCancelled,
                CommunityID = ParseCommunityCode(sapphireObject),
                ESubmittalDate = sapphireObject.DateApproved,
                RefNumber = sapphireObject.VPORefNum,
                JobNo = sapphireObject.Lot.LotID,
                JobRID = sapphireObject.Lot.LotRID,
                JobSvcOrdType = "5",
                JobSvcOrdStatus = sapphireObject.Status,
                SapphireLastUpdated = sapphireObject.LastUpdated,
                LoadDateTime = DateTime.Now,
                ReasonID = "66",
                ReleaseDate = sapphireObject.DateOpened,
                SapphireObjRId = sapphireObject.SvcOrdRID,
                SapphirePONumber = sapphireObject.SvcOrdID,
                SiteNumber = sapphireObject.Lot.LotID,
                Total = (double)sapphireObject.AmtTotal,
                Vendorid = sapphireObject.Vendor.VndID,
                Status = QueueItemStatusType.New
            };
        }

        private string ParseCommunityCode(ServiceOrder sapphireObject)
        {
            var communityId = sapphireObject.Lot.Community.CommunityId;

            // Community code is returned from Sapphire db as 8-character string (e.g. 'INR-DESN', 'ABN-MAST')
            // This process should parse out and return the first 3 characters prior to the hyphen as community code
            if (!string.IsNullOrEmpty(communityId) && communityId.IndexOf("-", StringComparison.Ordinal) == 3)
            {
                return communityId.Substring(0, 3);
            }

            throw new Exception($"Failed to Parse Community Code for Sapphire Record ID {sapphireObject.SvcOrdRID} using CommunityId {sapphireObject.Lot.Community.CommunityId}");
        }

        // TEMPLATE: Define business logic methods here to parse sapphire data to DI_Queue table  (i.e. ParseCommunityCode() )

    }

}
