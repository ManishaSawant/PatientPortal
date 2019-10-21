using EFDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo.Domain.DataAccess
{
  public class EFDemoContext:DbContext
    {
        public EFDemoContext() 
        {

        }
        public EFDemoContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MKRVCC8\\SQLEXPRESS;Database=PatientDemoEFDb;Trusted_Connection=True") ;
        }

        //To map the table & column names with the Dbset and entity properties.
        //You can use this configuration if your dbset or entity property names are different than table or column names or else
        //EF can automatically maps.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(
                patient=>
                {
                    patient.ToTable("Patient");
                    patient.HasKey("PatientId");
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
