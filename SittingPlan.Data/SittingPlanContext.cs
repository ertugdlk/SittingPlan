﻿using SittingPlan.Data.Entities;
using SittingPlan.Data.Initializers;
using System.Data.Entity;

namespace SittingPlan.Data
{
    public class SittingPlanContext : DbContext
    {
        public SittingPlanContext() : base("SittingPlan")
        {
            //Database.SetInitializer(new SittingPlanInitializer());
        }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Desk> Desk { get; set; }

        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Person> People { get; set; }
        
        public DbSet<ChairPeople> StPeople { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChairPeople>().HasKey(x => x.ChairId);
            modelBuilder.Entity<Chair>().HasOptional<ChairPeople>(x => x.StPeople).WithMany();
            //modelBuilder.Entity<ChairPeople>().HasRequired<Chair>(x => x.Chair).WithMany();

            modelBuilder.Entity<Person>().HasOptional<ChairPeople>(x => x.StPeople).WithMany();
            //modelBuilder.Entity<ChairPeople>().HasRequired<Person>(x => x.Person).WithMany();




            //relations between entities
            modelBuilder.Entity<Chair>().HasRequired<Desk>(x => x.Desk).WithMany(x => x.Chairs).HasForeignKey(x => x.DeskId);
            modelBuilder.Entity<Desk>().HasRequired<Floor>(x => x.Floor).WithMany(x => x.Desks).HasForeignKey(x => x.FloorId);
        }

    }
}
