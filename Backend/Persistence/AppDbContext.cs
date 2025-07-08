using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}
