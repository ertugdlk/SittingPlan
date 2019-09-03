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

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Desk> Desk { get; set; }

        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relations between entities
            modelBuilder.Entity<Desk>().HasMany<Chair>(x => x.Chairs);
            modelBuilder.Entity<Floor>().HasMany<Desk>(x => x.Desks);

            modelBuilder.Entity<Chair>().HasRequired<Person>(x => x.Person);
        }

    }
}
