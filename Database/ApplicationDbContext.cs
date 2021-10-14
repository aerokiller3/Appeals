using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
    }
}
