using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_3.Models
{
    public class ContextTask:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = lab_3.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Mark>()
                .HasOne(q => q.Student)
                .WithMany(w => w.Marks)
                .HasForeignKey(e => e.StudentId);
        }
    }
}