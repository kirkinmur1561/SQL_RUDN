using Microsoft.EntityFrameworkCore;

namespace Lab_1.Model
{
    public class ContextTask:DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = test.db");

    }
}