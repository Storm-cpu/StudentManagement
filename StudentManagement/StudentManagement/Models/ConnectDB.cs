using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StudentManagement.Models
{
    public partial class ConnectDB : DbContext
    {
        public ConnectDB()
            : base("name=ConnectDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<FacultyCourse> FacultyCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentMark> StudentMarks { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.classID)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.teacherID)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.facultyID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.courseID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.FacultyCourses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentMarks)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.facultyID)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.FacultyCourses)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FacultyCourse>()
                .Property(e => e.facultyID)
                .IsUnicode(false);

            modelBuilder.Entity<FacultyCourse>()
                .Property(e => e.courseID)
                .IsUnicode(false);

            modelBuilder.Entity<FacultyCourse>()
                .Property(e => e.temp)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.studentID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.classID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.facultyID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentMarks)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentMark>()
                .Property(e => e.studentID)
                .IsUnicode(false);

            modelBuilder.Entity<StudentMark>()
                .Property(e => e.courseID)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.teacherID)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.facultyID)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
