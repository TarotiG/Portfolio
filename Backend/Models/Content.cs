namespace Backend.Models
{
    public class Content
    {
        public class Introduction
        {
            public Guid Id {  get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime DateCreated { get; set; }

            public Introduction()
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        public class AboutMe
        {
            public Guid Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime DateCreated { get; set; }

            public AboutMe()
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        public class AchievedCertificates
        {
            public Guid Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime DateCreated { get; set; }

            public AchievedCertificates()
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        public class HighlightedProjects
        {
            public Guid Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime DateCreated { get; set; }

            public HighlightedProjects()
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        public class Contact
        {
            public Guid Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime DateCreated { get; set; }

            public Contact()
            {
                Id = Guid.NewGuid();
                DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        public class SocialMedia
        {
            public Guid Id { get; set; }
            public SocialMediaType Type { get; set; }
            public string Url { get; set; } = string.Empty;

            public SocialMedia()
            {
                Id = Guid.NewGuid();
            }

            public enum SocialMediaType
            {
                LinkedIn,
                GitHub
            }
        }
    }
}
