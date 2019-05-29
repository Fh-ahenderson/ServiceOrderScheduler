using System;

namespace DIScheduler.Core.Model.Sapphire
{
    public class ServiceOrder
    {
        public int SvcOrdRID { get; set; }
        public decimal AmtTotal { get; set; }
        public string Status { get; set; }
        public string RefNumber { get; set; }
        public string SvcOrdID { get; set; }
        public DateTime LastUpdated { get; set; }

        public int JobRID { get; set; }
        public virtual Job Job { get; set; }

        public int ActRID { get; set; }
        public virtual Activity Activity { get; set; }

        public int VndRID { get; set; }
        public virtual Vendor Vendor { get; set; }


        private DateTime? _dateCancelled;
        public DateTime? DateCancelled
        {
            get => _dateCancelled;
            set => _dateCancelled = value == new DateTime(1900, 1, 1) ? null : value;
        }

        private DateTime? _dateApproved;
        public DateTime? DateApproved
        {
            get => _dateApproved;
            set => _dateApproved = value == new DateTime(1900, 1, 1) ? null : value;
        }

        private DateTime? _dateOpened;
        public DateTime? DateOpened
        {
            get => _dateOpened;
            set => _dateOpened = value == new DateTime(1900, 1, 1) ? null : value;
        }
    }
}
