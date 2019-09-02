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

        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relations between entities
            modelBuilder.Entity<Desk>().HasMany<Chair>(x => x.Chairs);
            modelBuilder.Entity<Chair>().HasRequired<Person>(x => x.Person);
        }

    }
}
