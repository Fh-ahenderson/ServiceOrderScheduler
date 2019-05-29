using System;
using DIScheduler.Core.Model.Enums;

namespace DIScheduler.Core.Model
{
    public class NextRun : EntityBase
    {
        public DateTime RunComplete { get; set; }
        public NextRunStatusType Status { get; set; }
    }
}
