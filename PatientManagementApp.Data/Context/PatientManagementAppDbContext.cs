using Microsoft.EntityFrameworkCore;
using PatientManagementApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementApp.Data.Context
{
    public class PatientManagementAppDbContext : DbContext
    {
        public PatientManagementAppDbContext(DbContextOptions<PatientManagementAppDbContext>options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicDoctorPatientConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicFeatureConfiguration());

            modelBuilder.Entity<SettingEntity>().HasData(
                new SettingEntity
                {
                    Id = 1,
                    MaintenenceMode = false
                });




            base.OnModelCreating(modelBuilder);
        }
        public DbSet<PatientEntity> Patients => Set<PatientEntity>();
        public DbSet<AppointmenEntity> Appointments => Set<AppointmenEntity>();
        public DbSet<ClinicDoctorPatientEntity> ClinicDoctorPatientEntities => Set<ClinicDoctorPatientEntity>();
        public DbSet<ClinicEntity> Clinics => Set<ClinicEntity>();
        public DbSet<DoctorEntity> Doctors => Set<DoctorEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<ClinicFeatureEntity> ClinicFeatures => Set<ClinicFeatureEntity>();
        public DbSet<SettingEntity> Settings => Set<SettingEntity>();

    }
}
