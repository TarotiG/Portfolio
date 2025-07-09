namespace Backend.Models
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public string Description { get; set; } = default!;

        public Certificate()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
