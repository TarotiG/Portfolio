using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;

        [Required]
        public DateTime IssueDate { get; set; }
        public string Description { get; set; } = default!;
        public Guid CertificateId { get; set; }
        public Bestand CertificateFile { get; set; }

        public Certificate()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
        }
    }

    public class Bestand
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public byte[] FileData { get; set; } = Array.Empty<byte>();


    }
}
