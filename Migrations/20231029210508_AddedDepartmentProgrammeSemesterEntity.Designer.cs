﻿// <auto-generated />
using System;
using ExScheduler_Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExScheduler_Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231029210508_AddedDepartmentProgrammeSemesterEntity")]
    partial class AddedDepartmentProgrammeSemesterEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExScheduler_Server.Models.Admin", b =>
                {
                    b.Property<Guid>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Department", b =>
                {
                    b.Property<Guid>("departmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("departmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Programme", b =>
                {
                    b.Property<Guid>("programID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("departmentID")
                        .HasColumnType("uuid");

                    b.Property<string>("programName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("semesterID")
                        .HasColumnType("uuid");

                    b.HasKey("programID");

                    b.HasIndex("departmentID");

                    b.HasIndex("semesterID");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Semester", b =>
                {
                    b.Property<Guid>("semesterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("semesterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("semesterID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Students", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Validity")
                        .HasColumnType("boolean");

                    b.Property<Guid>("programID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("semesterID")
                        .HasColumnType("uuid");

                    b.HasKey("StudentID");

                    b.HasIndex("programID");

                    b.HasIndex("semesterID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Programme", b =>
                {
                    b.HasOne("ExScheduler_Server.Models.Department", "department")
                        .WithMany("Programmes")
                        .HasForeignKey("departmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExScheduler_Server.Models.Semester", null)
                        .WithMany("programmes")
                        .HasForeignKey("semesterID");

                    b.Navigation("department");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Students", b =>
                {
                    b.HasOne("ExScheduler_Server.Models.Programme", "program")
                        .WithMany("Students")
                        .HasForeignKey("programID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExScheduler_Server.Models.Semester", "semester")
                        .WithMany("students")
                        .HasForeignKey("semesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("program");

                    b.Navigation("semester");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Department", b =>
                {
                    b.Navigation("Programmes");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Programme", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ExScheduler_Server.Models.Semester", b =>
                {
                    b.Navigation("programmes");

                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}
