﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coronaSystemHMO_DAL.Models;

#nullable disable

namespace coronaSystemHMO_DAL.Migrations
{
    [DbContext(typeof(coronaSystemHMO_DBContext))]
    partial class coronaSystemHMO_DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("coronaSystemHMO_DAL.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("member_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("IdNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("id_number");

                    b.Property<byte[]>("Image")
                        .HasColumnType("VARBINARY(MAX)")
                        .HasColumnName("image");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("mobile_phone");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("phone");

                    b.Property<DateTime?>("PositiveTestDate")
                        .HasColumnType("date")
                        .HasColumnName("positive_test_date");

                    b.Property<DateTime?>("RecoveryDate")
                        .HasColumnType("date")
                        .HasColumnName("recovery_date");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("street");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("street_number");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("coronaSystemHMO_DAL.Models.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vaccine_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccineId"), 1L, 1);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("manufacturer");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("member_id");

                    b.Property<DateTime?>("VaccinationDate")
                        .HasColumnType("date")
                        .HasColumnName("vaccination_date");

                    b.HasKey("VaccineId");

                    b.HasIndex("MemberId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("coronaSystemHMO_DAL.Models.Vaccine", b =>
                {
                    b.HasOne("coronaSystemHMO_DAL.Models.Member", "Member")
                        .WithMany("Vaccines")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK__Vaccines__member__398D8EEE");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("coronaSystemHMO_DAL.Models.Member", b =>
                {
                    b.Navigation("Vaccines");
                });
#pragma warning restore 612, 618
        }
    }
}
