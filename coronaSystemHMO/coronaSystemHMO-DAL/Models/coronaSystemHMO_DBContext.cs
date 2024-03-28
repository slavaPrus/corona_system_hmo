using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coronaSystemHMO_DAL.Models
{
    public partial class coronaSystemHMO_DBContext : DbContext
    {
        public coronaSystemHMO_DBContext()
        {
        }

        public coronaSystemHMO_DBContext(DbContextOptions<coronaSystemHMO_DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Vaccine> Vaccines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-H37566O\\MSSQLSERVER01;Database=coronaSystemHMO_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(20)
                    .HasColumnName("id_number");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(15)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(10)
                    .HasColumnName("street_number");

                entity.Property(e => e.PositiveTestDate)
                  .HasColumnType("date")
                  .HasColumnName("positive_test_date");

                entity.Property(e => e.RecoveryDate)
                    .HasColumnType("date")
                    .HasColumnName("recovery_date");

                entity.Property(e => e.Image)
                .HasColumnType("VARBINARY(MAX)")
                    .HasColumnName("image");

            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.Property(e => e.VaccineId).HasColumnName("vaccine_id");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.VaccinationDate)
                    .HasColumnType("date")
                    .HasColumnName("vaccination_date");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Vaccines)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Vaccines__member__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
