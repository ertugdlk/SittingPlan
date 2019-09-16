using SittingPlan.Data.Entities;
using SittingPlan.Data.Initializers;
using System.Data.Entity;

namespace SittingPlan.Data
{
    public class SittingPlanContext : DbContext
    {
        public SittingPlanContext() : base("SittingPlan")
        {
            //disabled seed 
            //Database.SetInitializer(new SittingPlanInitializer());
        }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Desk> Desk { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Person> People { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //relations between entities
            modelBuilder.Entity<Chair>().HasRequired<Desk>(x => x.Desk).WithMany(x => x.Chairs).HasForeignKey(x => x.DeskId);
            modelBuilder.Entity<Desk>().HasRequired<Floor>(x => x.Floor).WithMany(x => x.Desks).HasForeignKey(x => x.FloorId);
        }

    }
}
