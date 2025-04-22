using DMS_3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMS_3.Data
{
    public class DMS_3Context : IdentityDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DMS_3Context(DbContextOptions<DMS_3Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Doctors)
                .WithOne(dr => dr.Department)
                .HasForeignKey(dr => dr.DepartmentId);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PatientId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Patient)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.PatientId);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.MedicalRecord)
                .WithMany(mr => mr.Reports)
                .HasForeignKey(r => r.MedicalRecordId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
