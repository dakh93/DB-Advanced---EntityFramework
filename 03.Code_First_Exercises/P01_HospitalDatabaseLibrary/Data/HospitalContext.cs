using System;
using Microsoft.EntityFrameworkCore;


using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    

    public class HospitalContext : DbContext
    {
        public HospitalContext() { }

        public HospitalContext (DbContextOptions options)
            :base (options)
        { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(entity =>
                {
                    entity.HasKey(e => e.PatientId);

                    entity.Property(e => e.FirstName)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasMaxLength(50);

                    entity.Property(e => e.LastName)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasMaxLength(50);

                    entity.Property(e => e.Address)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasMaxLength(250);

                    entity.Property(e => e.Email)
                        .IsRequired()
                        .IsUnicode(false)
                        .HasMaxLength(80);

                    entity.Property(e => e.HasInsurance)
                        .HasDefaultValue(true);

                    
                });

            builder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .IsUnicode()
                    .HasMaxLength(250);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(e => e.PatientId)
                    .HasConstraintName("FK_Visitation_Patient");

                entity.Property(e => e.DoctorId)
                    .IsRequired(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(d => d.DoctorId);

            });

            builder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .IsUnicode()
                    .HasMaxLength(250);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(e => e.PatientId)
                    .HasConstraintName("FK_Diagnose_Patient");
            });

            builder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

            });

            builder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new {e.PatientId, e.MedicamentId});

                entity.HasOne(e => e.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId);

                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(e => e.PatientId);
            });

            builder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity.Property(d => d.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(d => d.Specialty)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);
            });
        }
    }
}
