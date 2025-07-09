namespace Backend.Models
{
    /// <summary>
    /// Dit is het model voor projecten
    /// </summary>
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Function { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Technology { get; set; } = default!;
        public bool PersonalProject { get; set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            Function = string.Empty;
            Technology = string.Empty;
            PersonalProject = false;
        }
    }
}
