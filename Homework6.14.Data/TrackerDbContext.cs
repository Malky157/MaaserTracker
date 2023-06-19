using Microsoft.EntityFrameworkCore;

namespace Homework6._14.Data
{
    public class TrackerDbContext : DbContext
    {
        private string _connectionString;

        public TrackerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Maaser> Maasers { get; set; }
        public DbSet<Source> Sources { get; set; }

    }
}
