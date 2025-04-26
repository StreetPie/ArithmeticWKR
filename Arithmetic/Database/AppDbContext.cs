using Microsoft.EntityFrameworkCore;
using Arithmetic.Models;

namespace Arithmetic.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<SchoolTask> SchoolTasks { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestTask> TestTasks { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<TaskResult> TaskResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Локальное подключение
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-36VM1D0;Database=ArithmeticTasksDB;Integrated Security=True;");
            }
        }
    }
}
