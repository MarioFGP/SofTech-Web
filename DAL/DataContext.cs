using Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DataContext:DbContext
    {
        DbContextOptions<DataContext> Options;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SaborColombiano;Trusted_Connection=True; MultipleActiveResultSets = true");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Person> Person { get; set; }

        public DataContext()
        {
            
        }
    }
}