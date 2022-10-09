using Lab_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Model
{
    public class ContextTask:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = lab_2.db");

        /// <summary>
        /// Связь таблиц
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()/*Выбор таблицы*/
                .HasOne(q => q.User)/*Выбор поля*/
                .WithMany(w => w.InitGame)/*Отношение 1 ко многим*/
                .HasForeignKey(e => e.User_Id);/*внешний ключ*/
        }
    }
}