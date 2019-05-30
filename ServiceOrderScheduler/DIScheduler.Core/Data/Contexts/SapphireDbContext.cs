﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DIScheduler.Core.Model.Sapphire;

namespace DIScheduler.Core.Data.Contexts
{
    public class SapphireDbContext : DbContext
    {
        public SapphireDbContext()
        : base("SapphireDbContext")
        {
            Database.SetInitializer<SapphireDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        public DbSet<Lot> Lot { get; set; }
        public DbSet<Vendor> Vendor { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            EfMapServiceOrder(modelBuilder);
            EfMapLot(modelBuilder);
            EfMapCommunity(modelBuilder);
            EfMapVendor(modelBuilder);
        }


        private static void EfMapServiceOrder(DbModelBuilder modelBuilder)
        {
            var sapphireObject = modelBuilder.Entity<ServiceOrder>();
            sapphireObject.ToTable("SvcOrds");
            sapphireObject.HasKey(k => k.SvcOrdRID);
        }

        private static void EfMapCommunity(DbModelBuilder modelBuilder)
        {
            var com = modelBuilder.Entity<Community>();
            com.ToTable("Communities");
            com.HasKey(k => k.CommunityRID);
        }

        private static void EfMapLot(DbModelBuilder modelBuilder)
        {
            var lot = modelBuilder.Entity<Lot>();
            lot.ToTable("Lots");
            lot.HasKey(k => k.LotRID);
        }

        private static void EfMapVendor(DbModelBuilder modelBuilder)
        {
            var vnd = modelBuilder.Entity<Vendor>();
            vnd.ToTable("Vnds");
            vnd.HasKey(k => k.VndRID);
        }
    }
}
