﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Backend5.Data;

namespace Backend5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170621211813_AddPlacements")]
    partial class AddPlacements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend5.Models.Analysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("LabId");

                    b.Property<int>("PatientId");

                    b.Property<string>("Status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.HasIndex("PatientId");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("Backend5.Models.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Complications");

                    b.Property<string>("Details");

                    b.Property<int>("PatientId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Backend5.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Specialty");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Backend5.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("Backend5.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Backend5.Models.HospitalDoctor", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("DoctorId");

                    b.HasKey("HospitalId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("HospitalDoctors");
                });

            modelBuilder.Entity("Backend5.Models.HospitalLab", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("LabId");

                    b.HasKey("HospitalId", "LabId");

                    b.HasIndex("LabId");

                    b.ToTable("HospitalLabs");
                });

            modelBuilder.Entity("Backend5.Models.HospitalPhone", b =>
                {
                    b.Property<int>("HospitalId");

                    b.Property<int>("PhoneId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("HospitalId", "PhoneId");

                    b.ToTable("HospitalPhones");
                });

            modelBuilder.Entity("Backend5.Models.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("Backend5.Models.LabPhone", b =>
                {
                    b.Property<int>("LabId");

                    b.Property<int>("PhoneId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("LabId", "PhoneId");

                    b.ToTable("LabPhones");
                });

            modelBuilder.Entity("Backend5.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Backend5.Models.Placement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bed");

                    b.Property<int>("PatientId");

                    b.Property<int>("WardId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("WardId");

                    b.ToTable("Placements");
                });

            modelBuilder.Entity("Backend5.Models.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HospitalId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("Backend5.Models.WardStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Position")
                        .HasMaxLength(200);

                    b.Property<int>("WardId");

                    b.HasKey("Id");

                    b.HasIndex("WardId");

                    b.ToTable("WardStaffs");
                });

            modelBuilder.Entity("Backend5.Models.Analysis", b =>
                {
                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("Analyses")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("Analyses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.Diagnosis", b =>
                {
                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("Diagnoses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.DoctorPatient", b =>
                {
                    b.HasOne("Backend5.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("Doctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.HospitalDoctor", b =>
                {
                    b.HasOne("Backend5.Models.Doctor", "Doctor")
                        .WithMany("Hospitals")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.HospitalLab", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Labs")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("Hospitals")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.HospitalPhone", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Phones")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.LabPhone", b =>
                {
                    b.HasOne("Backend5.Models.Lab", "Lab")
                        .WithMany("Phones")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.Placement", b =>
                {
                    b.HasOne("Backend5.Models.Patient", "Patient")
                        .WithMany("Placements")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend5.Models.Ward", "Ward")
                        .WithMany("Placements")
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.Ward", b =>
                {
                    b.HasOne("Backend5.Models.Hospital", "Hospital")
                        .WithMany("Wards")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend5.Models.WardStaff", b =>
                {
                    b.HasOne("Backend5.Models.Ward", "Ward")
                        .WithMany("WardStaffs")
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
