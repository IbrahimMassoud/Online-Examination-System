using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data
{
    public class FacultyDBContext : DbContext
    {
        public FacultyDBContext(DbContextOptions<FacultyDBContext> options) :base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>().HasKey(sc => new { sc.StudentId, sc.SubjectId });
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
    }
}
