﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_departaments_EF.Database;

#nullable disable

namespace Student_departaments_EF.Migrations
{
    [DbContext(typeof(DepartaentContext))]
    partial class DepartaentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Student_departaments_EF.Models.DepartamentLectureModel", b =>
                {
                    b.Property<Guid>("DepartamentModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LectureModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartamentModelId", "LectureModelId");

                    b.HasIndex("LectureModelId");

                    b.ToTable("DepartamentLectureModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.DepartamentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DepartamentModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.LectureModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LectureModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.LectureStudentModel", b =>
                {
                    b.Property<Guid>("LectureModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentIModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LectureModelId", "StudentIModelId");

                    b.HasIndex("StudentIModelId");

                    b.ToTable("LectureStudentModels");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.StudentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("StudentModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.DepartamentLectureModel", b =>
                {
                    b.HasOne("Student_departaments_EF.Models.DepartamentModel", "DepartamentModel")
                        .WithMany("DepartamentLectureModels")
                        .HasForeignKey("DepartamentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_departaments_EF.Models.LectureModel", "LectureModel")
                        .WithMany("DepartamentLectureModels")
                        .HasForeignKey("LectureModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartamentModel");

                    b.Navigation("LectureModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.LectureStudentModel", b =>
                {
                    b.HasOne("Student_departaments_EF.Models.LectureModel", "LectureModel")
                        .WithMany("LectureStudentModels")
                        .HasForeignKey("LectureModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_departaments_EF.Models.StudentModel", "StudentModel")
                        .WithMany("LectureStudentModels")
                        .HasForeignKey("StudentIModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LectureModel");

                    b.Navigation("StudentModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.StudentModel", b =>
                {
                    b.HasOne("Student_departaments_EF.Models.DepartamentModel", "DepartamentModel")
                        .WithMany("StudentModels")
                        .HasForeignKey("DepartamentId");

                    b.Navigation("DepartamentModel");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.DepartamentModel", b =>
                {
                    b.Navigation("DepartamentLectureModels");

                    b.Navigation("StudentModels");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.LectureModel", b =>
                {
                    b.Navigation("DepartamentLectureModels");

                    b.Navigation("LectureStudentModels");
                });

            modelBuilder.Entity("Student_departaments_EF.Models.StudentModel", b =>
                {
                    b.Navigation("LectureStudentModels");
                });
#pragma warning restore 612, 618
        }
    }
}
