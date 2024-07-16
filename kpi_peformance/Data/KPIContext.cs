using LogKPI.Models;
using System.Data.Entity;

namespace LogKPI.Data
{
    public class KPIContext : DbContext
    {
        public KPIContext() : base("name=KPIContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LOGISTIC_KPI");
        }

        public DbSet<TB_KPI> TB_KPIs { get; set; }
        public DbSet<TB_LIMITOVERALL> TB_LIMITOVERALLs { get; set; }
        public DbSet<TB_LIMITPERITEM> TB_LIMIPERITEMs { get; set; }
    }
}