using System;
using DIScheduler.Core.Model.Enums;

namespace DIScheduler.Core.Model
{
    public class QueueItem : EntityBase
    {
        public string Activity { get; set; }
        public DateTime? ApprovePaymentDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? CancelledDate { get; set; }
        public string CommunityID { get; set; }
        public DateTime? ESubmittalDate { get; set; }
        public string JobNo { get; set; }
        public int? JobRID { get; set; }
        public string JobSvcOrdType { get; set; }
        public string JobSvcOrdStatus { get; set; }
        public DateTime SapphireLastUpdated { get; set; }
        public DateTime LoadDateTime { get; set; }
        public string ReasonID { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int SapphireObjRId { get; set; }
        public string SapphirePONumber { get; set; }
        public string SiteNumber { get; set; }
        public double? Total { get; set; }
        public string Vendorid { get; set; }
        public QueueItemStatusType Status { get; set; }

    }
}
