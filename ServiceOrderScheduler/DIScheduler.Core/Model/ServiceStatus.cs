using DIScheduler.Core.Model.Enums;

namespace DIScheduler.Core.Model
{
    public class ServiceStatus : EntityBase
    {
        public string ServiceName { get; set; }
        public ServiceStatusTypeValues Status { get; set; }
    }
}
