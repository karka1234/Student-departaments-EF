using Microsoft.EntityFrameworkCore;
using Student_departaments_EF.Database.EF;
using Student_departaments_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Database
{
    internal class DepartaentContext : DbContext
    {
        public DbSet<DepartamentModel> DepartamentModels { get; set; }
        public DbSet<LectureModel> LectureModels { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }

        public DbSet<DepartamentLectureModel> DepartamentLectureModels { get; set; }
        public DbSet<LectureStudentModel> LectureStudentModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfig.connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MtM
            modelBuilder.Entity<DepartamentLectureModel>()
                .HasKey(dl => new { dl.DepartamentModelId, dl.LectureModelId });

            modelBuilder.Entity<DepartamentLectureModel>()
                .HasOne<DepartamentModel>(dl => dl.DepartamentModel)
                .WithMany(d => d.DepartamentLectureModels)
                .HasForeignKey(dl => dl.DepartamentModelId);

            modelBuilder.Entity<DepartamentLectureModel>()
                .HasOne<LectureModel>(dl => dl.LectureModel)
                .WithMany(l => l.DepartamentLectureModels)
                .HasForeignKey(dl => dl.LectureModelId);

            // MtM
            modelBuilder.Entity<LectureStudentModel>()
                .HasKey(sl => new { sl.LectureModelId, sl.StudentIModelId });

            modelBuilder.Entity<LectureStudentModel>()
                .HasOne<LectureModel>(sl => sl.LectureModel)
                .WithMany(l => l.LectureStudentModels)
                .HasForeignKey(sl => sl.LectureModelId);

            modelBuilder.Entity<LectureStudentModel>()
                .HasOne<StudentModel>(sl => sl.StudentModel)
                .WithMany(s => s.LectureStudentModels)
                .HasForeignKey(sl => sl.StudentIModelId);
            
            modelBuilder.Entity<StudentModel>()
                .HasIndex(s => s.FullName)
                .IsUnique();

            // OtM
            modelBuilder.Entity<StudentModel>()
                .HasOne(s => s.DepartamentModel)
                .WithMany(s => s.StudentModels)
                .HasForeignKey(s => s.DepartamentId);
        }
      
    }
}
