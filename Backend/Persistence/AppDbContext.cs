using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Persistence
{
    public class AppDbContext : IdentityDbContext<FrontendUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}
