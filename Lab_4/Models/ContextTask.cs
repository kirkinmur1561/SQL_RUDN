using Lab_4.Models.Unions;
using Microsoft.EntityFrameworkCore;

namespace Lab_4.Models
{
    public class ContextTask:DbContext
    {
        public DbSet<Total> Totals { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<GroupOfStudent> GroupOfStudents { get; set; }
        public DbSet<EvaluationMethod> EvaluationMethods { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = lab_4.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Lesson>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Lessons)
                .UsingEntity(j => j.ToTable("UStudentLessons"));*/

            modelBuilder
                .Entity<Lesson>()
                .HasMany(q => q.Students)
                .WithMany(q => q.Lessons)
                .UsingEntity<UStudentLesson>(j =>
                        j.HasOne(q => q.Student)
                            .WithMany(q => q.StudentLessons)
                            .HasForeignKey(q => q.StudentId),
                    s =>
                        s.HasOne(q => q.Lesson)
                            .WithMany(q => q.StudentLessons)
                            .HasForeignKey(q => q.LessonId),
                    w => w.ToTable("UnStudsAndLessons"));
            
            modelBuilder
                .Entity<Lesson>()
                .HasMany(q => q.GroupOfStudents)
                .WithMany(q => q.Lessons)
                .UsingEntity<ULessonGroup>(j =>
                        j.HasOne(q => q.GroupOfStudent)
                            .WithMany(q => q.ULessonGroups)
                            .HasForeignKey(q => q.IdGroup),
                    s =>
                        s.HasOne(q => q.Lesson)
                            .WithMany(q => q.ULessonGroups)
                            .HasForeignKey(q => q.IdLesson),
                    w => w.ToTable("UnLessonsAndGrs"));
            
            
            modelBuilder
                .Entity<Student>()
                .HasMany(q => q.GroupOfStudents)
                .WithMany(q => q.Students)
                .UsingEntity<UStudentGroup>(j =>
                        j.HasOne(q => q.GroupOfStudent)
                            .WithMany(q => q.StudentGroups)
                            .HasForeignKey(q => q.IdGroup),
                    s =>
                        s.HasOne(q => q.Student)
                            .WithMany(q => q.StudentGroups)
                            .HasForeignKey(q => q.IdStudent),
                    w => w.ToTable("UnStudsAndGrs"));
            
            
            
            modelBuilder
                .Entity<Total>()
                .HasOne(q => q.Student)
                .WithMany(w => w.Totals)
                .HasForeignKey(e => e.IdStudent);
            
            modelBuilder
                .Entity<Total>()
                .HasOne(q => q.Lesson)
                .WithMany(w => w.Totals)
                .HasForeignKey(e => e.IdLesson);


            
        }
    }
}