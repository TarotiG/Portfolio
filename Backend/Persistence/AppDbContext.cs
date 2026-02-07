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
        public DbSet<Technology> Technologies { get; set; }

        // Content
        public DbSet<Content.Introduction> Introductions { get; set; }
        public DbSet<Content.AboutMe> AboutMes { get; set; }
        public DbSet<Content.AchievedCertificates> AchievedCertificates { get; set; }
        public DbSet<Content.HighlightedProjects> HighlightedProjects { get; set; }
        public DbSet<Content.Contact> Contacts { get; set; }
        public DbSet<Content.SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Certificate>()
                .HasOne(c => c.CertificateFile)
                .WithOne()
                .HasForeignKey<Certificate>(c => c.CertificateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
                .HasMany(p => p.Technologies)
                .WithOne(t => t.Project!)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Content.Introduction>();
            builder.Entity<Content.AboutMe>();
            builder.Entity<Content.AchievedCertificates>();
            builder.Entity<Content.HighlightedProjects>();
            builder.Entity<Content.Contact>();
            builder.Entity<Content.SocialMedia>();

        }
    }
}
