using SittingPlan.Data.Entities;
using SittingPlan.Data.Initializers;
using System.Data.Entity;

namespace SittingPlan.Data
{
    public class SittingPlanContext : DbContext
    {
        public SittingPlanContext() : base("SittingPlan")
        {
            Database.SetInitializer(new SittingPlanInitializer());
        }

        public DbSet<Desk> Desk { get; set; }
    }
}
