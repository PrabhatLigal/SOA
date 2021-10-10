using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthMicroservice.Model
{
    public class DBContext : DbContext
    {
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {
            //Seed();
        }

        void Seed()
        {

            Consultants.AddRange(new List<Consultant>() {
            new Consultant { Id = 1, Name = "Dr John Chen", Institution = "Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification = "M.D" },
            new Consultant { Id = 2, Name = "Dr Juliya Pitt", Institution = "Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification = "M.D" },
            new Consultant { Id = 3, Name = "Dr Mark vega", Institution = "Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification = "M.D" }
            });
            this.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationForm>()
           .HasMany(e => e.Sessions).WithOne();
            modelBuilder.Entity<ApplicationForm>()
           .HasOne(e => e.AssignedConsultant).WithOne();

            //modelBuilder.Entity<Consultant>()

            modelBuilder.Entity<Consultant>().HasData(
            new Consultant { Id = 1, Name="Dr John Chen", Institution="Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification="M.D" },
            new Consultant { Id = 2, Name = "Dr Juliya Pitt", Institution = "Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification = "M.D" },
            new Consultant { Id = 3, Name = "Dr Mark vega", Institution = "Liverpool Hospital, NSW", Role = "Psychiatrist", Qualification = "M.D" });


        }
    }
}
