using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DIScheduler.Core.Model;

namespace DIScheduler.Core.Data.Contexts
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext()
       : base("AWS_DIProcessor")
        {
            Database.SetInitializer<SchedulerDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<NextRun> NextRuns { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<QueueItem> QueueItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            EfMapNextRun(modelBuilder);
            EfMapQueueItem(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void EfMapNextRun(DbModelBuilder modelBuilder)
        {
            var nr = modelBuilder.Entity<NextRun>();
            nr.ToTable("ServiceOrder_NextRun");
        }

        private static void EfMapQueueItem(DbModelBuilder modelBuilder)
        {
            var item = modelBuilder.Entity<QueueItem>();
            item.ToTable("ServiceOrder_Queue");
        }
    }
}
