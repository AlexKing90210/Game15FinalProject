using Microsoft.EntityFrameworkCore;

namespace DBClass
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Winners> Winners { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Game15.db");
        }
    }
}