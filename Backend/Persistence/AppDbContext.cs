using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class AppDbContext : IdentityDbContext<FrontendUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Bestand> Bestanden { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Certificate>()
                .HasOne(c => c.CertificateFile)
                .WithOne()
                .HasForeignKey<Certificate>(c => c.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
