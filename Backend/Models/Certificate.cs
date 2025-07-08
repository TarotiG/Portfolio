namespace Backend.Models
{
    public class Certificate
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public string Description { get; set; } = default!;
    }
}
