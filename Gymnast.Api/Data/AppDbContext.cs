using Microsoft.EntityFrameworkCore;

namespace Gymnast.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
        public DbSet<Models.Gymnast> Gymnasts { get; set; }
        public DbSet<Models.Match> Matches { get; set; }
    }
}