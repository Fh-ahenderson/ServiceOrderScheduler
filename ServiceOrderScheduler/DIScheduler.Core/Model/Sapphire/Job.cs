using System;
namespace DIScheduler.Core.Model.Sapphire
{
    public class Job
    {
        public int JobRID { get; set; }
        public string JobID { get; set; }
        public int LotRID { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
